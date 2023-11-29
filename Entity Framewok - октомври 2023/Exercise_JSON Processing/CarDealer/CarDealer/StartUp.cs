using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        const string _jsonWritePath = @"D:\SoftUni_Projects\Entity Framewok - октомври 2023\Exercise_JSON Processing\CarDealer\CarDealer\Datasets\";

        public static void Main()
        {
            const string supplierJSONPath = @"D:\SoftUni_Projects\Entity Framewok - октомври 2023\Exercise_JSON Processing\CarDealer\CarDealer\Datasets\suppliers.json";
            const string partJSONPath = @"D:\SoftUni_Projects\Entity Framewok - октомври 2023\Exercise_JSON Processing\CarDealer\CarDealer\Datasets\parts.json";
            const string carJSONPath = @"D:\SoftUni_Projects\Entity Framewok - октомври 2023\Exercise_JSON Processing\CarDealer\CarDealer\Datasets\cars.json";
            const string customerJSONPath = @"D:\SoftUni_Projects\Entity Framewok - октомври 2023\Exercise_JSON Processing\CarDealer\CarDealer\Datasets\customers.json";
            const string saleJSONPath = @"D:\SoftUni_Projects\Entity Framewok - октомври 2023\Exercise_JSON Processing\CarDealer\CarDealer\Datasets\sales.json";

            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(ImportSuppliers(context, supplierJSONPath));
            Console.WriteLine(ImportParts(context, partJSONPath));
            Console.WriteLine(ImportCars(context, carJSONPath));
            Console.WriteLine(ImportCustomers(context, customerJSONPath));
            Console.WriteLine(ImportSales(context, saleJSONPath));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            if (suppliers != null)
            {
                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }

            return $"Successfully imported {suppliers?.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            if (parts != null)
            {
                context.Parts.AddRange(parts);
                context.SaveChanges();
            }

            return $"Successfully imported {parts?.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);

            if (cars != null)
            {
                context.Cars.AddRange(cars);
                context.SaveChanges();
            }

            return $"Successfully imported {cars?.Length}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            if (customers != null)
            {
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            return $"Successfully imported {customers?.Length}";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            if (sales != null)
            {
                context.Sales.AddRange(sales);
                context.SaveChanges();
            }

            return $"Successfully imported {sales?.Length}";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
            .Select(c => new 
            {
                c.Name,
                c.BirthDate,
                c.IsYoungDriver
            })
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .ToList();

            string customersToJSON = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "ordered-customers.json", customersToJSON);

            return customersToJSON;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
            .Where(c => c.Make == "Toyota")
            .Select(c => new 
            {
                c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance
            })
            .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
            .ToList();

            string carsToJSON = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "toyota-cars.json", carsToJSON);

            return carsToJSON;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new 
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            })
            .ToList();

            string suppliersToJSON = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "local-suppliers.json", suppliersToJSON);

            return suppliersToJSON;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
            .Select(c => new 
            {
                car = new 
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                },
                parts = c.PartsCars.Select(p => new 
                {
                    p.Part.Name,
                    Price = p.Part.Price.ToString("F2")
                })
            })
            .ToList();

            string carsWithPartsToJSON = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "cars-and-parts.json", carsWithPartsToJSON);

            return carsWithPartsToJSON;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new 
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price)) 
                })
                .ToList();
                
            string customersToJSON = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(_jsonWritePath + "customers-total-sales.json", customersToJSON);

            return customersToJSON;
        }
    }
}