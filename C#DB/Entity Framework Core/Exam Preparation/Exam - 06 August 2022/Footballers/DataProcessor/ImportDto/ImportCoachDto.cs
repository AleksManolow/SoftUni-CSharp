﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [XmlElement("Nationality")]
        [Required]
        public string Nationality { get; set; } = null!;
        [XmlArray("Footballers")]
        public ImportFootballerDto[] FootballerDtos { get; set; } = null!;
    }
}
