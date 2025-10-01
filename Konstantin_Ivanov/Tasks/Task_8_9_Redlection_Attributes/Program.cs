using System.Reflection;

Assembly asm = Assembly.LoadFrom("TemperatureLibrary.dll");

foreach (Type t in asm.GetTypes())
{
    Console.WriteLine($"Тип: {t.FullName}");
    PrintTypeAttributes(t);//аттрибуты самого типа

    Console.WriteLine("Чьи аттрибуты смотрим?");
    Console.WriteLine("1 - Методы, 2 - Свойства, 3 - Поля");
    string choice = Console.ReadLine();

    BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    switch (choice)
    {
        case "1":
            foreach (MethodInfo m in t.GetMethods(flags))
            {
                Console.WriteLine($"{m.ReturnType.Name} {m.Name}()");
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

object converterInstance = Activator.CreateInstance(converterType);

MethodInfo method = converterType.GetMethod("CelsiusToFahrenheit");

Console.Write("Введите температуру в Цельсиях: ");
double celsius = double.Parse(Console.ReadLine());

object result = method.Invoke(converterInstance, [celsius]);

Console.WriteLine($"{celsius} °C = {result} °F");

static void PrintAttributes(MemberInfo member)
{
    object[] attrs = member.GetCustomAttributes(false);
    foreach (object attr in attrs)
    {
        Console.WriteLine($"[Атрибут: {attr}]");
    }
}

static void PrintTypeAttributes(Type type)
{
    object[] attrs = type.GetCustomAttributes(false);
    foreach (object attr in attrs)
    {
        Console.WriteLine($"[Атрибут: {attr}]");
    }
}
