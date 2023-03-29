namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Game> games = new List<Game>();
            List<Genre> genres = new List<Genre>();
            List<Developer> developers = new List<Developer>();
            List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validReleaseDate);
                if (!IsValid(gameDto)
                    || !isReleaseDateValid
                    || !gameDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Game game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = validReleaseDate
                };

                Genre genre = genres.Find(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre() { Name = gameDto.Genre };
                    genres.Add(genre);
                }
                game.Genre = genre;

                Developer developer = developers.Find(d => d.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer() { Name = gameDto.Developer };
                    developers.Add(developer);
                }
                game.Developer = developer;

                foreach (string tagName in gameDto.Tags)
                {
                    if (string.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    Tag tag = tags.Find(t => t.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag() { Name = tagName };
                        tags.Add(tag);
                    }
                    game.GameTags.Add(new GameTag() { Game = game, Tag = tag });
                }

                games.Add(game);
                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count()));
            }

            context.AddRange(games);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto)
                    || string.IsNullOrEmpty(userDto.Email)
                    || !userDto.Cards.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                User user= new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                };
                List<Card> currentUserCards = new List<Card>();
                foreach (var cardDto in userDto.Cards)
                {
                    bool isCardTypeValid = Enum.TryParse<CardType>(cardDto.Type, out CardType validCardType);

                    if (!IsValid(cardDto)
                        || !isCardTypeValid)
                    {
                        currentUserCards = null;
                        break;
                    }

                    Card card = cards.Find(c => c.Number == cardDto.Number);
                    if (card == null)
                    {
                        card = new Card()
                        {
                            Number = cardDto.Number,
                            Cvc = cardDto.Cvc,
                            Type = validCardType
                        };
                        cards.Add(card);
                    }

                    currentUserCards.Add(card);
                }
                if (currentUserCards == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                user.Cards = currentUserCards;
                users.Add(user);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]) , new XmlRootAttribute("Purchases"));
            StringReader reader = new StringReader(xmlString);
            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(reader);

            ICollection<Purchase> purchases = new HashSet<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                bool isPurchaseDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validPurchaseDate);
                bool isPurchaseTypeValid = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType validPurchaseType);

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.GameTitle);
                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);

                if (!IsValid(purchaseDto)
                    || !isPurchaseDateValid
                    || !isPurchaseTypeValid
                    || game == null 
                    || card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Purchase purchase = new Purchase()
                {
                    Type = validPurchaseType,
                    ProductKey = purchaseDto.ProductKey,
                    Date =  validPurchaseDate,
                    Card = card,
                    Game = game
                };

                purchases.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}