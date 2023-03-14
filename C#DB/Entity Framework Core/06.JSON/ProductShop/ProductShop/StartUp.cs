using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();
            /*dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();*/

            string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            string result = ImportUsers(dbContext, inputJson);

            Console.WriteLine(result);
        }
        public static string ImportUsers(ProductShopContext dbContext, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var userDtos = JsonConvert.DeserializeObject<UserDto[]>(inputJson);

            ICollection<User> users = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                users.Add(user);
            }
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}