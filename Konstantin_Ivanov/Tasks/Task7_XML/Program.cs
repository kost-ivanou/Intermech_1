using System.Xml;

XmlDocument doc = new XmlDocument();
doc.Load("../../../../../Resources/TelephoneBook.xml"); 

XmlNodeList phones = doc.GetElementsByTagName("Phone");

foreach (XmlNode phone in phones)
{
    Console.WriteLine(phone.InnerText);
}