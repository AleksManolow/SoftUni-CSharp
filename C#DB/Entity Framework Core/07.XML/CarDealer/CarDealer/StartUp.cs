using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
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

            string result = ImportSuppliers(dbContext, @"../../../Datasets/suppliers.xml");

            Console.WriteLine(result);
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(SupplierDto[]), xmlRoot);

            StreamReader reader = new StreamReader(inputXml);
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
    }
}