using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Data;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            string inputSuppliersXml = File.ReadAllText("./../../../Datasets/suppliers.xml");
            string inputPartsXml = File.ReadAllText("./../../../Datasets/parts.xml");
            string inputCarsXml = File.ReadAllText("./../../../Datasets/cars.xml");
            string inputCustomersXml = File.ReadAllText("./../../../Datasets/customers.xml");
            string inputSalesXml = File.ReadAllText("./../../../Datasets/sales.xml");

            CarDealerContext context = new CarDealerContext();



            //Console.WriteLine(ImportSuppliers(context, inputSuppliersXml));
            //Console.WriteLine(ImportParts(context, inputPartsXml));
        }

        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = new Mapper(config);

            return mapper;
        }

        public static void GetSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Select(s => new
            {
                s.Id,
                s.Name,
                s.Parts.Count
            }).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, suppliers));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDTO[]), new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);

            ImportSupplierDTO[] supplierDTOs = (ImportSupplierDTO[])serializer.Deserialize(reader);

            var mapper = GetMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierDTOs);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartsDTO[]), new XmlRootAttribute("Parts"));

            using StringReader reader = new StringReader(inputXml);

            ImportPartsDTO[] partDTOs = (ImportPartsDTO[])serializer.Deserialize(reader);

            var suppliersIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var mapper = GetMapper();
            Part[] parts = mapper.Map<Part[]>(partDTOs.Where(p => suppliersIds.Contains(p.SupplierId)));

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarsDTO[]), new XmlRootAttribute("Cars"));

            using StringReader reader = new StringReader(inputXml);

            ImportCarsDTO[] carDTOs = (ImportCarsDTO[])serializer.Deserialize(reader);

            var mapper = GetMapper();
            List<Car> cars = new List<Car>();

            foreach (var carDTO in carDTOs)
            {
                Car car = mapper.Map<Car>(carDTOs);

                int[] carPartIds = carDTO.PartsIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach (var part in carPartIds)
                {
                    carParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = part
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}";
        }
    }
}