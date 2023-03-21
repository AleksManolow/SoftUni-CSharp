﻿using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.UsersAndProducts
{
    [XmlType ("Product")]
    public class ProductUserDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;
        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
