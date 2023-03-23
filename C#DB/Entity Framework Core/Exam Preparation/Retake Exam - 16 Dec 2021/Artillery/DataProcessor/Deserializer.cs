namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Countries");
            XmlSerializer  xmlSerializer =
                new XmlSerializer(typeof(ImportCountryDto[]), xmlRoot);

            StringReader reader = new StringReader(xmlString);
            ImportCountryDto[] countryDtos = (ImportCountryDto[])xmlSerializer.Deserialize(reader);

            ICollection<Country> countries = new HashSet<Country>();
            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                countries.Add(new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize,
                });
                sb.AppendLine(string.Format(SuccessfulImportCountry, countryDto.CountryName, countryDto.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Manufacturers");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportManufacturerDto[]), xmlRoot);

            StringReader reader = new StringReader(xmlString);
            ImportManufacturerDto[] manufacturerDtos = (ImportManufacturerDto[])xmlSerializer.Deserialize(reader);

            ICollection<Manufacturer> manufacturer = new HashSet<Manufacturer>();
            foreach (var manufacturerDto in manufacturerDtos)
            {
                if (!IsValid(manufacturerDto) || manufacturer.Any(c => c.ManufacturerName == manufacturerDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }
                manufacturer.Add(new Manufacturer()
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                });
                string[] foundeds = manufacturerDto.Founded.Split(", ");
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturerDto.ManufacturerName, $"{foundeds[foundeds.Length - 2]}, {foundeds[foundeds.Length - 1]}"));
            }
            context.Manufacturers.AddRange(manufacturer);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Shells");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportShellDto[]), xmlRoot);

            StringReader reader = new StringReader(xmlString);
            ImportShellDto[] shellDtos = (ImportShellDto[])xmlSerializer.Deserialize(reader);

            ICollection<Shell> shells = new HashSet<Shell>();
            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                shells.Add(new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber,
                });
                sb.AppendLine(string.Format(SuccessfulImportShell, shellDto.Caliber, shellDto.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var gunDtos = JsonConvert.DeserializeObject<InportGunDto[]>(jsonString);
            ICollection<Gun> guns = new HashSet<Gun>();

            foreach (var gunDto in gunDtos)
            {
                bool isGunTypeValid = Enum.TryParse<GunType>(gunDto.GunType, out GunType validGunType);

                if (!IsValid(gunDto) || !isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    BarrelLength = gunDto.BarrelLength,
                    GunType = validGunType,
                    GunWeight = gunDto.GunWeight,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    ShellId = gunDto.ShellId,
                    ManufacturerId = gunDto.ManufacturerId
                };

                foreach (var countryDto in gunDto.countyIdDtos)
                {
                    gun.CountriesGuns.Add(new CountryGun()
                    {
                        CountryId = countryDto.Id,
                        Gun = gun
                    });
                }
                guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, validGunType, gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(guns);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}