using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        const string _jsonWritePath = @"D:\SoftUni_Projects\Entity Framewok - октомври 2023\Exercise_JSON Processing\PorductShop\ProductShop\Datasets\";

        public static void Main()
        {
            const string? categoriesJSON = "D:\\SoftUni_Projects\\Entity Framewok - октомври 2023\\Exercise_JSON Processing\\PorductShop\\ProductShop\\Datasets\\categories.json";
            const string? categoriesProductsJSON = "D:\\SoftUni_Projects\\Entity Framewok - октомври 2023\\Exercise_JSON Processing\\PorductShop\\ProductShop\\Datasets\\categories-products.json";
            const string? productsJSON = "D:\\SoftUni_Projects\\Entity Framewok - октомври 2023\\Exercise_JSON Processing\\PorductShop\\ProductShop\\Datasets\\products.json";
            const string? usersJSON = "D:\\SoftUni_Projects\\Entity Framewok - октомври 2023\\Exercise_JSON Processing\\PorductShop\\ProductShop\\Datasets\\users.json";


            ProductShopContext context = new ProductShopContext();

            //string userJson = File.ReadAllText(usersJSON);
            //Console.WriteLine(ImportUsers(context, userJson));
            //
            //string productJson = File.ReadAllText(productsJSON);
            //Console.WriteLine(ImportProducts(context, productJson));

            //string categoryJson = File.ReadAllText(categoriesJSON);
            //Console.WriteLine(ImportCategories(context, categoryJson));

            //string categoryProductJson = File.ReadAllText(categoriesProductsJSON);
            //Console.WriteLine(ImportCategoryProducts(context, categoryProductJson));

            //Console.WriteLine(GetProductsInRange(context));

            //Console.WriteLine(GetSoldProducts(context));

            //Console.WriteLine(GetCategoriesByProductsCount(context));

            Console.WriteLine(GetUsersWithProducts(context));

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            if (users != null)
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"Successfully imported {users?.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            if (products != null)
            {
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            return $"Successfully imported {products?.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var allCategories = JsonConvert.DeserializeObject<Category[]>(inputJson);
            var validCategories = allCategories.Where(c => c.Name != null).ToArray();

            if (validCategories != null)
            {
                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                return $"Successfully imported {validCategories?.Length}";
            }
            
            return $"Successfully imported 0";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(pp => pp.price)
                .ToList();

            string productsToJson = JsonConvert.SerializeObject(products.ToArray(), Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "exported-products.json", productsToJson);

            return productsToJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(s => s.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                .Select(s => new
                {
                    firstName = s.FirstName,
                    lastName = s.LastName,
                    soldProducts = s.ProductsSold
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName

                    }).ToArray()
                })
                .ToArray();


            string soldProductsJson = JsonConvert.SerializeObject(sellers, Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "users-sold-products.json", soldProductsJson); 

            return soldProductsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts
                        .Average(cp => cp.Product.Price).ToString("f2"),
                    totalRevenue = c.CategoriesProducts
                        .Sum(cp => cp.Product.Price).ToString("f2")
                    
                })
                .OrderByDescending(x => x.productCount)
                .ToArray();

            string categoriesByProductCountJSON = JsonConvert.SerializeObject(categoriesByProductCount, Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "categories-by-products.json", categoriesByProductCountJSON);

            return categoriesByProductCountJSON;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersAndProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price
                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.soldProducts.Length)
                .ToArray();

            var usersJSON = new
            {
                userCount = usersAndProducts.Count(),
                user = usersAndProducts.Select(u => new
                {
                    u.firstName,
                    u.lastName,
                    u.age,
                    soldProducts = new
                    {
                        count = u.soldProducts.Count(),
                        products = u.soldProducts
                    }
                })
            };

            string usersAndProductsJSON = JsonConvert.SerializeObject(usersJSON, new JsonSerializerSettings 
            {  
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore 
            });
            File.WriteAllText(_jsonWritePath + "users-and-products.json", usersAndProductsJSON);

            return usersAndProductsJSON;
        }
    }
}