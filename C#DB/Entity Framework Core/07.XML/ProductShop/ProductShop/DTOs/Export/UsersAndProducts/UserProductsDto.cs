using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.UsersAndProducts
{
    [XmlType("User")]
    public class UserProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        [XmlElement("age")]
        public int? Age { get; set; }
        [XmlElement("SoldProducts")]
        public SoldProductsDto ProductsSold { get; set; }
    }
}
