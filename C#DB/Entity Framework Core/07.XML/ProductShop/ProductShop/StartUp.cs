using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Export.UsersAndProducts;
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

            /*string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
            string result = ImportUsers(context, inputXml);*/

            /*string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            string result = ImportProducts(context, inputXml);*/

            /*string inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");
            string result = ImportCategories(context, inputXml);*/

            /*string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            string result = ImportCategoryProducts(context, inputXml);*/

            //string result = GetProductsInRange(context);

            //string result = GetSoldProducts(context);

            //string result = GetCategoriesByProductsCount(context);

            string result = GetUsersWithProducts(context);

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
        //Task02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("Products"));

            StringReader reader = new StringReader(inputXml);
            var productDtos = (ProductDto[])xmlSerializer.Deserialize(reader);

            ICollection<Product> products = mapper.Map<Product[]>(productDtos);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
        //Task03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));

            StringReader reader = new StringReader(inputXml);
            var categoryDtos = (CategoryDto[])xmlSerializer.Deserialize(reader);

            ICollection<Category> categories = mapper.Map<Category[]>(categoryDtos);

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        //Task04
        public static string GetProductsInRange(ProductShopContext context, string inputXml)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            StringReader reader = new StringReader(inputXml);
            var categoryProductDtos = (CategoryProductDto[])xmlSerializer.Deserialize(reader);

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

            foreach (var cpDto in categoryProductDtos)
            {
                if (context.Categories.Find(cpDto.CategoryId) == null || context.Products.Find(cpDto.ProductId) == null)
                {
                    continue;
                }

                categoryProducts.Add(new CategoryProduct
                {
                    CategoryId = cpDto.CategoryId,
                    ProductId = cpDto.ProductId
                });
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        //Task05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Include(p => p.Buyer)
                .Select(p => new ProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = $"{p.Buyer.FirstName} " + p.Buyer.LastName
                })
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);


            var serializer = new XmlSerializer(typeof(ProductsInRangeDto[]), new XmlRootAttribute("Products"));
            using var writer = new StringWriter();

            serializer.Serialize(writer, products, namespaces);

            return writer.ToString();
        }
        //Task06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserWithProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    products = u.ProductsSold
                                .Where(p => p.Buyer != null)
                                .Select(p => new ProductsOnUserDto()
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                })
                                .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            var serializer = new XmlSerializer(typeof(UserWithProductsDto[]), new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, null);

            using var writer = new StringWriter();

            serializer.Serialize(writer, users, namespaces);

            return writer.ToString();
        }
        //Task07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Include(c => c.CategoryProducts)
                .Select(c => new CategoryByProductDto() 
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            var serializer = new XmlSerializer(typeof(CategoryByProductDto[]), new XmlRootAttribute("Categories"));

            using var writer = new StringWriter();

            serializer.Serialize(writer, categories, namespaces);

            return writer.ToString();
        }
        //Task08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = new UserCountDto
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = context.Users
                   .Where(u => u.ProductsSold.Any())
                   .OrderByDescending(u => u.ProductsSold.Count)
                   .Select(u => new UserProductsDto
                   {
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Age = u.Age,
                       ProductsSold = new SoldProductsDto
                       {
                           Count = u.ProductsSold.Count,
                           Products = u.ProductsSold.Select(p => new ProductUserDto
                           {
                               Name = p.Name,
                               Price = p.Price
                           })
                           .OrderByDescending(p => p.Price)
                           .ToArray()
                       }
                   })
                   .Take(10)
                   .ToArray()
            };

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, null);

            var serializer = new XmlSerializer(typeof(UserCountDto), new XmlRootAttribute("Users"));

            using var writer = new StringWriter();

            serializer.Serialize(writer, usersWithProducts, namespaces);

            return writer.ToString();

        }
    }
}