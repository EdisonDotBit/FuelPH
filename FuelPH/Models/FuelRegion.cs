namespace FuelPH.Models;

public class FuelRegion
{
    public string Name { get; set; } = string.Empty;
    public double South { get; set; }
    public double West { get; set; }
    public double North { get; set; }
    public double East { get; set; }
}