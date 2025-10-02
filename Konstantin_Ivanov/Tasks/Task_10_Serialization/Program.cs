using System.Xml.Serialization;
using Task_10_Serialization;

CitizenAttributes citizenAttributes = new CitizenAttributes
{
    id = 1,
    name = "Konstantin",
    email = "123abc@gmail.com"
};
CitizenElement citizenElement = new CitizenElement 
{
    id = 2,
    name = "Artem",
    email = "abc123@gmail.com"
};

SerializeToXml(citizenElement, typeof(CitizenElement), "ce.xml");
SerializeToXml(citizenAttributes, typeof(CitizenAttributes), "ca.xml");

static void SerializeToXml(object obj, Type type, string filename)
{
    XmlSerializer xmlSerializer = new XmlSerializer(type);
    using (TextWriter tw = new StreamWriter(filename))
    {
        xmlSerializer.Serialize(tw, obj);
    }
}
