using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("CategoryProduct")]
    public class CategoryProductDto
    {
        [XmlElement]
        public int CategoryId { get; set; }

        [XmlElement]
        public int ProductId { get; set; }
    }
}
