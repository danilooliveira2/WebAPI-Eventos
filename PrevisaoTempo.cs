namespace WebAPI_Aprendizado
{
    public class PrevisaoTempo
    {
        public DateTime Data { get; set; }

        public int TemperaturaCelsius { get; set; }

        public int TemperatureF => 32 + (int)(TemperaturaCelsius / 0.5556);

        public string? SumarioExplicativo { get; set; }
    }
}