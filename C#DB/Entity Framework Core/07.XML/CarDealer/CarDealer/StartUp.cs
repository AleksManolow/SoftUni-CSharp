using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
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

            /*string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            string result = ImportParts(dbContext, inputXml);*/

            /*string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            string result = ImportCars(dbContext, inputXml);*/

            /*string inputXml = File.ReadAllText(@"../../../Datasets/customers.xml");
            string result = ImportCustomers(dbContext, inputXml);*/

            /*string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            string result = ImportSales(dbContext, inputXml);*/

            //string result = GetCarsWithDistance(dbContext);

            //string result = GetCarsFromMakeBmw(dbContext);

            //string result = GetLocalSuppliers(dbContext);

            //string result = GetCarsWithTheirListOfParts(dbContext);

            string result = GetTotalSalesByCustomer(dbContext);

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
        //Task11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);
            var carDtos = (ImportCarDto[])serializer.Deserialize(reader);

            var cars = carDtos
                .Select(c => new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    PartsCars = c.PartsCars
                    .Select(p => p.PartId)
                    .Distinct()
                    .Select(i => new PartCar
                    {
                        PartId = i
                    })
                   .ToList()
                })
                .ToList();


            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        //Task12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("Customers"));

            StringReader reader = new StringReader(inputXml);
            CustomerDto[] customerDtos = (CustomerDto[])serializer.Deserialize(reader);

            ICollection<Customer> customers = new HashSet<Customer>();
            foreach (var customerDto in customerDtos)
            {
                Customer customer = mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }
        //Task13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            XmlSerializer serializer = new XmlSerializer(typeof(SaleDto[]), new XmlRootAttribute("Sales"));

            StringReader reader = new StringReader(inputXml);
            SaleDto[] saleDtos = (SaleDto[])serializer.Deserialize(reader);
            
            ICollection<Sale> sales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                if (!context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);
                sales.Add(sale);
            }
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        //Task14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var carDtos = cars
                .Select(c => new CarWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();


            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            var serializer = new XmlSerializer(typeof(CarWithDistanceDto[]), new XmlRootAttribute("cars"));
            using var writer = new StringWriter();
            serializer.Serialize(writer, carDtos, namespaces);

            return writer.ToString();
        }
        //Task15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .AsNoTracking()
                .ToArray();

            var carDtos = cars
                .Select(c => new CarsFromMakeBmw()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            var serializer = new XmlSerializer(typeof(CarsFromMakeBmw[]), new XmlRootAttribute("cars"));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, carDtos, namespaces);

            return writer.ToString();
        }
        //Task16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Parts = s.Parts.Count
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            XmlSerializer serializer = new XmlSerializer(typeof(LocalSupplierDto[]), new XmlRootAttribute("suppliers"));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, suppliers, namespaces);

            return writer.ToString();
        }
        //Task17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarsWithParts()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                            .OrderByDescending(p => p.Part.Price)
                            .Select(p => new PartsOnCar()
                            {
                                Name = p.Part.Name,
                                Price = p.Part.Price
                            })
                            .ToArray()
                })
                .ToArray();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            XmlSerializer serializer = new XmlSerializer(typeof(CarsWithParts[]), new XmlRootAttribute("cars"));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, carsWithParts, namespaces);
            return writer.ToString();
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersDb = context.Customers
               .Where(c => c.Sales.Any())
               .Select(c => new
               {
                   Name = c.Name,
                   BoughtCars = c.Sales.Count,
                   Sales = c.Sales.Select(s => new
                   {
                       Price = c.IsYoungDriver
                       ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                       : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                   })
                   .ToArray()
               })
               .ToArray();

            var customers = customersDb
                .OrderByDescending(c => c.Sales.Sum(s => s.Price))
                .Select(c => new SalesByCustomer
                {
                    Name = c.Name,
                    BoughtCars = c.BoughtCars,
                    SpentMoney = c.Sales.Sum(s => s.Price).ToString("f2")
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            XmlSerializer serializer = new XmlSerializer(typeof(SalesByCustomer[]), new XmlRootAttribute("customers"));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, customers, namespaces);
            return writer.ToString();
        }
    }
}