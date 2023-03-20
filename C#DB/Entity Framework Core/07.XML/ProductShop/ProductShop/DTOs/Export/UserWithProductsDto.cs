using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class UserWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;
        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;
        [XmlArray("soldProducts")]
        public ProductsOnUserDto[] products { get; set; } = null!;
    }
}
