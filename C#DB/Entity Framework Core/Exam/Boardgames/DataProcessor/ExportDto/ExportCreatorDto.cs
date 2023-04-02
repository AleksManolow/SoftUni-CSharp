using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorDto
    {
        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }
        [XmlElement("CreatorName")]
        public string CreatorName { get; set; } = null!;
        [XmlArray("Boardgames")]
        public ExportBoardgameDto[] BoardgameDtos { get; set; }
    }
}
