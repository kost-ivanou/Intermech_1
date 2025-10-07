using Task_10_Serialization;

CitizenAttributes citizenAttributes = new CitizenAttributes
{
    Id = 1,
    Name = "Konstantin",
    Email = "123abc@gmail.com"
};
CitizenElement citizenElement = new CitizenElement 
{
    Id = 2,
    Name = "Artem",
    Email = "abc123@gmail.com"
};

XmlHelper.SerializeToXml(citizenAttributes, typeof(CitizenAttributes), "ca.xml");
XmlHelper.SerializeToXml(citizenElement, typeof(CitizenElement), "ce.xml");

var ca = XmlHelper.DeserializeFromXml<CitizenAttributes>("ca.xml");
var ce = XmlHelper.DeserializeFromXml<CitizenElement>("ce.xml");

Console.WriteLine($"Десериализация CitizenAttributes: {ca.Id}, {ca.Name}, {ca.Email}");
Console.WriteLine($"Десериализация CitizenElement: {ce.Id}, {ce.Name}, {ce.Email}");