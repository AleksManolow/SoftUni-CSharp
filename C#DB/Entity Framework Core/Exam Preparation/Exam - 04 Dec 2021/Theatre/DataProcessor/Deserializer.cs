﻿namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), new XmlRootAttribute("Plays"));
            StringReader reader = new StringReader(xmlString);
            var playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(reader);

            ICollection<Play> plays = new HashSet<Play>();

            foreach (var playDto in playDtos)
            {
                TimeSpan time;
                Genre genre;
                if (!IsValid(playDto) 
                    || !TimeSpan.TryParse(playDto.Duration, out time)
                    || time < TimeSpan.FromHours(1) 
                    || !Enum.TryParse(playDto.Genre, out genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                plays.Add(new Play()
                {
                    Title = playDto.Title,
                    Duration = time,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter,
                });
                sb.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, genre.ToString(), $"{playDto.Rating}"));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), new XmlRootAttribute("Casts"));
            StringReader reader = new StringReader(xmlString);
            var castDtos = (ImportCastDto[])xmlSerializer.Deserialize(reader);

            ICollection<Cast> casts= new HashSet<Cast>();
            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                casts.Add(new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId,
                });
                sb.AppendLine(string.Format(SuccessfulImportActor, castDto.FullName, castDto.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTheatreDto[] theaterDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            ICollection<Theatre> theatres = new HashSet<Theatre>();
            foreach (var theatreDto in theaterDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                List<Ticket> tickets = new List<Ticket>();
                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        PlayId = ticketDto.PlayId,
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber
                    };
                    tickets.Add(ticket);
                }

                Theatre theatre = new Theatre()
                {
                    Director = theatreDto.Director,
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Tickets = tickets
                };
                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }
            context.Theatres.AddRange(theatres);
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
