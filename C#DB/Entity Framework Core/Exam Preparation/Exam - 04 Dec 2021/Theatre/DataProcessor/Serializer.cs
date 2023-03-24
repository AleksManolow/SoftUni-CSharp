namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var exportPlays = context
               .Theatres
               .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
               .ToArray()
               .Select(t => new
               {
                   Name = t.Name,
                   Halls = t.NumberOfHalls,
                   TotalIncome = t.Tickets
                       .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                       .Sum(ti => ti.Price),
                   Tickets = t.Tickets.Select(ti => new
                   {
                       Price = ti.Price,
                       RowNumber = ti.RowNumber
                   })
                       .Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                       .OrderByDescending(ti => ti.Price)
                       .ToArray()
               })
               .OrderByDescending(t => t.Halls)
               .ThenBy(t => t.Name)
               .ToArray();

            return JsonConvert.SerializeObject(exportPlays, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            var plays = context.Plays
                .Where(p => p.Rating <= raiting)
                .ToArray()
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportActorDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()

                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayDto[]), new XmlRootAttribute("Plays"));

            using var write = new StringWriter();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, plays, xmlNamespaces);

            return write.ToString();
        }
    }
}
