using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TemperatureLibrary;

[Serializable]
public class TemperatureConverter
{
    [Required]
    private double multiplier { get; set; }

    [DebuggerStepThrough]
    public TemperatureConverter()
    {
        multiplier = 9 / 5;
    }

    public double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * multiplier) + 32;
    }

    [Obsolete("Устаревший метод")]
    public double CeliusToFahrenheitOld(double temp)
    {
        return (temp * (temp - 32));
    }
}
