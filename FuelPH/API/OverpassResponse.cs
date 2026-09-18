namespace FuelPH.API
{
    public class OverpassResponse
    {
        public List<OverpassElement> Elements { get; set; } = [];
    }

    public class OverpassElement
    {
        public string Type { get; set; } = string.Empty;

        public long Id { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public Dictionary<string, string>? Tags { get; set; }
    }
}
