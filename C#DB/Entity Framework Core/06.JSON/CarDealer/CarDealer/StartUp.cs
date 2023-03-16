using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();

            /*string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            string result = ImportSuppliers(dbContext, inputJson);*/

            /*string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            string result = ImportParts(dbContext, inputJson);*/

            /*string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            string result = ImportCars(dbContext, inputJson);*/

            /*string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            string result = ImportCustomers(dbContext, inputJson);*/

            /*string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            string result = ImportSales(dbContext, inputJson);*/

            //string result = GetOrderedCustomers(dbContext);

            //string result = GetCarsFromMakeToyota(dbContext);

            //string result = GetLocalSuppliers(dbContext);

            //string result = GetCarsWithTheirListOfParts(dbContext);

            string result = GetTotalSalesByCustomer(dbContext);

            Console.WriteLine(result);
        }
        //Task09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var suppliersDtos = JsonConvert.DeserializeObject<SupplierDto[]>(inputJson);

            ICollection<Supplier> suppliers = mapper.Map<Supplier[]>(suppliersDtos);
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }
        //Task10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var partsDtos = JsonConvert.DeserializeObject<PartDto[]>(inputJson);
            
            ICollection<Part> parts = new HashSet<Part>();
            foreach (var partDto in partsDtos)
            {
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }
                Part part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }
            context.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }
        //Task11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<CarDto> cars = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            foreach (var car in cars)
            {
                Car currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.PartsId)
                {
                    bool isValid = currentCar.PartsCars.FirstOrDefault(x => x.PartId == part) == null;
                    bool isPartValid = context.Parts.FirstOrDefault(p => p.Id == part) != null;

                    if (isValid && isPartValid)
                    {
                        currentCar.PartsCars.Add(new PartCar()
                        {
                            PartId = part
                        });
                    }
                }

                context.Cars.Add(currentCar);
            }

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }
        //Task12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var customresDtos = JsonConvert.DeserializeObject<CustomerDto[]>(inputJson);

            ICollection<Customer> customers = mapper.Map<Customer[]>(customresDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }
        //Task13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var salesDtos = JsonConvert.DeserializeObject<SalesDto[]>(inputJson);

            ICollection<Sale> sales = mapper.Map<Sale[]>(salesDtos);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        //Task14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new 
                { 
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
        //Task15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .AsNoTracking()
                .ToArray();
            
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
        //Task16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();
            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }
        //Task17
        public static string GetCarsWithTheirListOfParts(CarDealerContext dbContext)
        {
            var carsAndParts = dbContext.Cars
                .Select(c => new
                {
                    car = new
                    {

                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TravelledDistance,
                    },
                    parts = c.PartsCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = $"{p.Part.Price:f2}"
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
        }
        //Task18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.SelectMany(x => x.Car.PartsCars.Select(c => c.Part.Price))
                })
                .AsNoTracking()
                .ToArray();

            var totalSalesByCustomer = customers.Select(t => new
            {
                t.fullName,
                t.boughtCars,
                spentMoney = t.spentMoney.Sum()
            })
            .OrderByDescending(t => t.spentMoney)
            .ThenByDescending(t => t.boughtCars)
            .ToArray();

            return JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);
        }
    }
}