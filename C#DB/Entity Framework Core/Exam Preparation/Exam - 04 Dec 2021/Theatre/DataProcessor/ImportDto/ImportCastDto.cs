using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [XmlElement("FullName")]
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; } = null!;
        [XmlElement("IsMainCharacter")]
        [Required]
        public bool IsMainCharacter { get; set; }
        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"^\+44-[0-9]{2}-[0-9]{3}-[0-9]{4}$")]
        public string PhoneNumber { get; set; } = null!;
        [XmlElement("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
