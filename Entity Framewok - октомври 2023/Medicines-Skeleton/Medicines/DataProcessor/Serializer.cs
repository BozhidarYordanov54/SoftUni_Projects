namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {


            return string.Empty;
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => m.Category == (Medicines.Data.Models.Enums.Category)medicineCategory)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price,
                    Pharmacy = new
                    {
                       Name = m.Pharmacy.Name,
                       PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .OrderBy(m => m.Name)
                .ToList();

            string json = JsonConvert.SerializeObject(medicines, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../ExportResults/medicines.json", json);

            return json;
        }
    }
}
