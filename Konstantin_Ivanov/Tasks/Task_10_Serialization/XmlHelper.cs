using System.Xml.Serialization;

namespace Task_10_Serialization;

public class XmlHelper
{
    public static void SerializeToXml(object obj, Type type, string filename)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(type);
        using (TextWriter tw = new StreamWriter(filename))
        {
            xmlSerializer.Serialize(tw, obj);
        }
    }

    public static T DeserializeFromXml<T>(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (TextReader reader = new StreamReader(fileName))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
}
