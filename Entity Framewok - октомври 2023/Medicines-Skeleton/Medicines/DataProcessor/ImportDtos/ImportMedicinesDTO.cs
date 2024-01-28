using Medicines.Data.Models.Enums;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicinesDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Price")]
        public decimal Price { get; set; }
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; }
        [XmlElement("ExpiryDate")]
        public string ExpirationDate { get; set; }
        [XmlElement("Producer")]
        public string Producer { get; set; }
    }
}
