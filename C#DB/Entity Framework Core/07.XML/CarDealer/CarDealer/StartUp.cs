using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.IO;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();
            /*dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();*/

            /*string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            string result = ImportSuppliers(dbContext, inputXml);*/

            string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            string result = ImportParts(dbContext, inputXml);

            //string result = ImportCars(dbContext, @"../../../Datasets/cars.xml");

            Console.WriteLine(result);
        }
        //Task09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(SupplierDto[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            SupplierDto[] supplierDtos = (SupplierDto[])xmlSerializer.Deserialize(reader);

            //This is for convenience!!!
            /*XmlHelper xmlHelper = new XmlHelper();
            SupplierDto[] supplierDtos = xmlHelper.Deserialize<SupplierDto[]>(inputXml, "Suppliers");*/

            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }
                //Manual mapping without AutoMapper
                /*Supplier supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };*/

                Supplier supplier = mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
        //Task10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(PartDto[]), xmlRoot);

            StringReader reader = new StringReader(inputXml);
            PartDto[] partDtos = (PartDto[])xmlSerializer.Deserialize(reader);

            ICollection<Part> parts = new HashSet<Part>();
            foreach (var partDto in partDtos)
            {
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
        /*public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(CarDto[]), xmlRoot);

            StreamReader reader = new StreamReader(inputXml);
            CarDto[] partDtos = (CarDto[])xmlSerializer.Deserialize(reader);

            ICollection<Car> parts = new HashSet<Car>();
            foreach (var partDto in partDtos)
            {

            }
            return "";
        }*/
    }
}