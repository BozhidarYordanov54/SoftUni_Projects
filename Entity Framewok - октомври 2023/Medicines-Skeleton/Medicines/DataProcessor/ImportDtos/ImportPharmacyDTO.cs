using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDTO
    {
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlArray("Medicines")]
        public List<ImportMedicinesDTO>? Medicines { get; set; }
    }
}
