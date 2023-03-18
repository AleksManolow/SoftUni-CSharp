using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class CarDto
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;
        [XmlElement("model")]
        public string Model { get; set; } = null!;
        [XmlElement("traveledDistance")]
        public long TravelledDistance { get; set; }
        [XmlArray("parts")]
        public CarPartDto[] Parts { get; set; } = null!;
    }
}
