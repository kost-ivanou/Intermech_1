using System.Xml.Serialization;

namespace Task_10_Serialization;

public class CitizenAttributes
{
    [XmlAttribute("id")]
    public int id { get; set; }

    [XmlAttribute("name")]
    public string name { get; set; }

    [XmlAttribute("email")]
    public string email { get; set; }
}
