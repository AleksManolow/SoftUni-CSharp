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

            /*string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            string result = ImportUsers(dbContext, inputJson);*/

            /*string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            string result = ImportProducts(dbContext, inputJson);*/

            /*string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            string result = ImportCategories(dbContext, inputJson);*/

            string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            string result = ImportCategoryProducts(dbContext, inputJson);

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
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var productsDto = JsonConvert.DeserializeObject<ProductDto[]>(inputJson);

            Product[] products = mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var categoriesDto = JsonConvert.DeserializeObject<CategoryDto[]>(inputJson);

            ICollection<Category> categories = new HashSet<Category>();
            foreach (var categoryDto in categoriesDto)
            {
                if (String.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);

                categories.Add(category);
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cmf =>
            {
                cmf.AddProfile<ProductShopProfile>();
            }));

            var categoriesProductsDto = JsonConvert.DeserializeObject<CategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> categoriesProducts = new HashSet<CategoryProduct>();
            foreach (var categoryProductDto in categoriesProductsDto)
            {
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
                categoriesProducts.Add(categoryProduct);
            }
            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }
    }
}