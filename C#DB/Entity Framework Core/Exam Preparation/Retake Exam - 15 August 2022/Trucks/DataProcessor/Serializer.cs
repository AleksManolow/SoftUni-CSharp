﻿namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count(),
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportDespatcherDto[]), new XmlRootAttribute("Despatchers"));

            using var write = new StringWriter();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, despatchers, xmlNamespaces);

            return write.ToString();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            VinNumber = ct.Truck.VinNumber,
                            TankCapacity = ct.Truck.TankCapacity,
                            CargoCapacity = ct.Truck.CargoCapacity,
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType = ct.Truck.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Count())
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
