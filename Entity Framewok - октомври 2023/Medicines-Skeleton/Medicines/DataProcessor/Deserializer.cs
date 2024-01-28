namespace Medicines.DataProcessor
{
    using AutoMapper;
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.DataProcessor.ImportDtos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            return string.Empty;
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportPharmacyDTO[]), new XmlRootAttribute("Pharmacies"));

            using StringReader reader = new StringReader(xmlString);

            ImportPharmacyDTO[] pharmacyDTOs = (ImportPharmacyDTO[])serializer.Deserialize(reader);

            var mapper = GetMapper();
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            foreach (var pharmacyDTO in pharmacyDTOs)
            {
                string value = pharmacyDTO.ToString();
                Boolean parseValue;

                if (string.IsNullOrWhiteSpace(pharmacyDTO.Name) || string.IsNullOrEmpty(pharmacyDTO.PhoneNumber) || pharmacyDTO.IsNonStop == "tru")
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = mapper.Map<Pharmacy>(pharmacyDTO);
                List<Medicine> medicines = new List<Medicine>();

                foreach (var medicin in pharmacyDTO.Medicines.ToArray())
                {
                    if (string.IsNullOrEmpty(medicin.Name)
                        || medicin.Price < 0
                        || string.IsNullOrEmpty(medicin.Producer)
                        || !IsValidDateFormat(DateTime.ParseExact(medicin.ProductionDate, ), "yyyy-MM-dd")
                        || !IsValidDateFormat(medicin.ExpirationDate, "yyyy-MM-dd"))
                    {
                        result.AppendLine(ErrorMessage);
                    }
                    else
                    {
                        medicines.Add(new Medicine
                        {
                            Name = medicin.Name,
                            Price = medicin.Price,
                            ProductionDate = medicin.ProductionDate,
                            ExpiryDate = medicin.ExpirationDate,
                            Producer = medicin.Producer
                        });
                    }
                }


                pharmacy.Medicines = medicines;
                pharmacies.Add(pharmacy);
                result.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, medicines.Count));

            }

            context.AddRange(pharmacies);
            context.SaveChanges();



            return string.Join(Environment.NewLine, result);
        }

        private static bool IsValidDateFormat(DateTime date, string format)
        {
            return DateTime.TryParseExact(date.ToString(format), format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MedicinesProfile>());

            var mapper = new Mapper(config);

            return mapper;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
