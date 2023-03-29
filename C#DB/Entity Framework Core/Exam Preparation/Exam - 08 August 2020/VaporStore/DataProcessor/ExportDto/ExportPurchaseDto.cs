using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string Card { get; set; } = null!;
        [XmlElement("Cvc")]
        public string Cvc { get; set; } = null!;
        [XmlElement("Date")]
        public string Date { get; set; } = null!;
        [XmlElement("Game")]
        public ExportGameDto Game { get; set; } = null!;
    }
}
