namespace Core_Proje.Areas.Writer.Models
{
    public class WeatherViewModel
    {
        public int cloud_pct { get; set; }
        public int temp { get; set; }
        public int feels_like { get; set; }
        public int humidity { get; set; }
        public int min_temp { get; set; }
        public int max_temp { get; set; }
        public float wind_speed { get; set; }
        public int wind_degrees { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
