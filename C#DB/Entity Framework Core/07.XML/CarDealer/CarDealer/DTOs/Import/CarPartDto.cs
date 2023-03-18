using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("PartId")]
    public class CarPartDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
