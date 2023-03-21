using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.UsersAndProducts
{
    [XmlType("SoldProducts")]
    public class SoldProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public ProductUserDto[] Products { get; set; } = null!;
    }
}
