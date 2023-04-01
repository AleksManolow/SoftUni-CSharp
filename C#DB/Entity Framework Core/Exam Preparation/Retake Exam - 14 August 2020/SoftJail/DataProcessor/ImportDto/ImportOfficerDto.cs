using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [XmlElement("FullName")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FullName { get; set; } = null!;
        [XmlElement("Salary")]
        [Required]
        public string Salary { get; set; }
        [XmlElement("Position")]
        [Required]
        public string Position { get; set; } = null!;
        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; } = null!;
        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }
        [XmlArray("Prisoners")]
        public ImportPrisonerIdDto[] Prisoners { get; set; }
    }
}
