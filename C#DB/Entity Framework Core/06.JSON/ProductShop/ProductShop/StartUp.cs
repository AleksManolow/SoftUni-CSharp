using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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

            /*string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            string result = ImportCategoryProducts(dbContext, inputJson);*/

            //string result = GetProductsInRange(dbContext);

            //string result = GetSoldProducts(dbContext);

            //string result = GetCategoriesByProductsCount(dbContext);

            string result = GetUsersWithProducts(dbContext);

            Console.WriteLine(result);
        }
        //task01
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
        //task02
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
        //task03
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
        //task04
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
        //task05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .AsNoTracking()
                .ToArray();
            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
        //task06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new 
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    }).ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }
        //task07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = Math.Round((double)c.CategoriesProducts.Average(p => p.Product.Price), 2),
                    totalRevenue = Math.Round((double)c.CategoriesProducts.Sum(p => p.Product.Price), 2)
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }
        //task08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold
                .Where(p => p.Buyer != null)
                .Count())
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Count(),
                        products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })

                    }
                })
                .AsNoTracking()
                .ToArray();

            var usersInfo = new
            {
                usersCount = users.Count(),
                users = users
            };
            return JsonConvert.SerializeObject(usersInfo, Formatting.Indented);
        }
    }
}