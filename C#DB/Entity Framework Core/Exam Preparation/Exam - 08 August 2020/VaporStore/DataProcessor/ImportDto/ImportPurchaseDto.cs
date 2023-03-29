using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlAttribute("title")]
        public string GameTitle { get; set; } = null!;
        [XmlElement("Type")]
        [Required]
        public string Type { get; set; } = null!;
        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string ProductKey { get; set; } = null!;
        [Required]
        [XmlElement("Card")]
        public string CardNumber { get; set; } = null!;
        [XmlElement("Date")]
        [Required]
        public string Date { get; set; } = null!;
        
    }
}
