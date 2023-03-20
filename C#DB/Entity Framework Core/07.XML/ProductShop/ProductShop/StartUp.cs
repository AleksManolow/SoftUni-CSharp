﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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

            string result = GetProductsInRange(context);

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
    }
}