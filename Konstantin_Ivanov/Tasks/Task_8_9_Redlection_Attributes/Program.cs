using System.Reflection;

Assembly asm = null;

try
{
    asm = Assembly.LoadFrom("TemperatureLibrary.dll");
}
catch
{
    Console.WriteLine("Файл TemperatureLibrary.dll не найден");
    return;
}

foreach (Type t in asm.GetTypes().Where(t => t.IsPublic))
{
    Console.WriteLine($"Тип: {t.FullName}");
    PrintAttributes(t);//аттрибуты самого типа

    Console.WriteLine("Чьи аттрибуты смотрим?");
    Console.WriteLine("1 - Методы, 2 - Свойства, 3 - Поля");
    string choice = Console.ReadLine();

    BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    switch (choice)
    {
        case "1":
            foreach (MethodInfo m in t.GetMethods(flags))
            {
                Console.WriteLine($"{m.ToString()} {m.Name}()");
                PrintAttributes(m);
            }
            break;
        case "2":
            foreach (PropertyInfo p in t.GetProperties(flags))
            {
                Console.WriteLine($"{p.PropertyType.Name} {p.Name}");
                PrintAttributes(p);
            }
            break;
        case "3":
            foreach (FieldInfo f in t.GetFields(flags))
            {
                Console.WriteLine($"{f.FieldType.Name} {f.Name}");
                PrintAttributes(f);
            }
            break;
        default:
            Console.WriteLine("от 1 до 3");
            break;
    }
}

Type converterType = asm.GetType("TemperatureLibrary.TemperatureConverter");
if (converterType == null)
{
    Console.WriteLine("Нет такого типа");
    return;
}

object converterInstance = Activator.CreateInstance(converterType);

MethodInfo method = converterType.GetMethod("CelsiusToFahrenheit");
if (method == null)
{
    Console.WriteLine("Нет метода с такой сигнатурой");
    return;
}

Console.Write("Введите температуру в Цельсиях: ");
double celsius;
if(!double.TryParse(Console.ReadLine(), out celsius))
{
    Console.WriteLine("Введите число градусов");
    return;
}

object result = method.Invoke(converterInstance, new object[] { celsius });

Console.WriteLine($"{celsius} °C = {result} °F");

static void PrintAttributes(ICustomAttributeProvider provider)
{
    object[] attrs = provider.GetCustomAttributes(false);
    foreach (object attr in attrs)
    {
        Console.WriteLine($"[Атрибут: {attr}]");
    }
}
