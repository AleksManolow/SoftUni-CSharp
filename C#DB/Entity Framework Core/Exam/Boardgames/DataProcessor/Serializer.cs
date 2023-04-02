namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                        .Select(bs => new
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Mechanics = bs.Boardgame.Mechanics,
                            Category = bs.Boardgame.CategoryType.ToString()

                        })
                        .OrderByDescending(bs => bs.Rating)
                        .ThenBy(bs => bs.Name)
                        .ToList()
                })
                .OrderByDescending(s => s.Boardgames.Count)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToList();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }

        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorDto()
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count,
                    BoardgameDtos = c.Boardgames
                        .Select(b => new ExportBoardgameDto()
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished,
                        })
                        .OrderBy(b => b.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCreatorDto[]), new XmlRootAttribute("Creators"));

            using var write = new StringWriter();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, creators, xmlNamespaces);

            return write.ToString();
        }
    }
}