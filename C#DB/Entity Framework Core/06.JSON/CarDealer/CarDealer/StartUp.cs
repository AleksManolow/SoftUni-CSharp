﻿using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

            string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            string result = ImportCustomers(dbContext, inputJson);
            
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
    }
}