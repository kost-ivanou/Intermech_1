using System.Xml.Serialization;

namespace Task_10_Serialization;

public class CitizenAttributes
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("email")]
    public string Email { get; set; }
}
