using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.UsersAndProducts
{
    [XmlType("Users")]
    public class UserCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        public UserProductsDto[] Users { get; set; }
    }
}
