using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }
        [XmlElement("ProjectName")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string ProjectName { get; set; } = null!;
        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; } = null!;
        [XmlArray("Tasks")]
        public ExportTaskDto[] TaskDtos { get; set; } = null!;
    }
}
