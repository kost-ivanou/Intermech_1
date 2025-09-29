using System.Globalization;
using System.Text;

string[] lines = File.ReadAllLines("../../../../../Resources/check.txt", Encoding.UTF8);

var lookup = lines
            .Select(line =>
            {
                var parts = line.Split(';');
                return new
                {
                    Product = parts[0],
                    Date = DateTime.Parse(parts[1], CultureInfo.InvariantCulture)
                };
            })
            .ToLookup(x => x.Product, x => x.Date);

Console.WriteLine("Локаль пользователя:");
CultureInfo userCulture = CultureInfo.CurrentCulture;
PrintCheck(lookup, userCulture);

Console.WriteLine("\nЛокаль en-US:");
CultureInfo engCulture = new CultureInfo("en-US");
PrintCheck(lookup, engCulture);

static void PrintCheck(ILookup<string, DateTime> productsInfo, CultureInfo culture)
{
    foreach (var product in productsInfo)
    {
        foreach(var date in product)
        {
            Console.WriteLine($"{product.Key}, {date.ToString(culture)}");
        }
    }
}
