using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            string result = ImportUsers(context, inputXml);

            Console.WriteLine(result);
        }
        //Task01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));

            StringReader reader = new StringReader(inputXml);
            var userDtos = (UserDto[])xmlSerializer.Deserialize(reader);

            ICollection<User> users = mapper.Map<User[]>(userDtos);
            context.AddRange(users);
            context.SaveChanges();
            
            return $"Successfully imported {users.Count}";
        }
    }
}