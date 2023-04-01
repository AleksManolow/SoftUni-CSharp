namespace SoftJail.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder(); 
            var departmentDtos = JsonConvert.DeserializeObject < ImportDepartmentDto[]>(jsonString);

            ICollection<Department> departments = new HashSet<Department>();

            foreach (var departmentDto in  departmentDtos)
            {
                if (!IsValid(departmentDto)
                    || !departmentDto.Cells.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department department = new Department() 
                { 
                    Name = departmentDto.Name,
                };

                ICollection<Cell> cells = new List<Cell>();
                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        cells = null;
                        break;
                    }
                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,
                    };
                    cells.Add(cell);
                }
                if (cells == null)
                {
                    continue;
                }
                department.Cells = cells;
                departments.Add(department);

                sb.AppendLine(string.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPrisonerDto[] prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            ICollection<Prisoner> prisoners = new HashSet<Prisoner>();
            foreach (var prisonerDto in prisonerDtos)
            {
                DateTime validIncarcerationDate;
                bool isValidIncarcerationDate = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out validIncarcerationDate);

                DateTime? validReleaseDate = null;
                bool isReleaseDateValid = true;
                if (prisonerDto.ReleaseDate != null)
                {
                    isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedReleaseDate);
                    validReleaseDate = parsedReleaseDate;
                }

                if (!IsValid(prisonerDto)
                    || !isValidIncarcerationDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = validIncarcerationDate,
                    ReleaseDate = validReleaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                };

                ICollection<Mail> mails = new HashSet<Mail>();
                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        mails = null;
                        break;
                    }
                    Mail mail = new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    };
                    mails.Add(mail);
                }
                if (mails == null)
                {
                    continue;
                }   
                prisoner.Mails = mails;
                prisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            StringReader reader = new StringReader(xmlString);  
            var officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(reader);

            ICollection<Officer> officers= new HashSet<Officer>();
            foreach (var officerDto in officerDtos)
            {
                bool isValidPosition = Enum.TryParse<Position>(officerDto.Position, out Position validPosition);
                bool isValidWeapon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon validWeapon);
                if (!IsValid(officerDto)
                    || !isValidPosition
                    || !isValidWeapon
                    || decimal.Parse(officerDto.Salary) < 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Officer officer = new Officer()
                { 
                    FullName = officerDto.FullName,
                    Salary = decimal.Parse(officerDto.Salary),
                    Position = validPosition,
                    Weapon = validWeapon,
                    DepartmentId = officerDto.DepartmentId
                };
                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    Prisoner prisoner = context.Prisoners.FirstOrDefault(p => p.Id == prisonerDto.Id);

                    officer.OfficerPrisoners.Add(new OfficerPrisoner()
                    {
                        Officer = officer,
                        Prisoner = prisoner
                    });
                }
                officers.Add(officer);
                sb.AppendLine(string.Format(SuccessfullyImportedOfficer, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}