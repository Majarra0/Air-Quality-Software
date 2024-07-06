using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class Readings
    {
        [Key] public DateTime CreatedAt { get; set; }
        public string DeviceName { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int AirQ { get; set; }
        public int CO2 { get; set; }
        public int VOC { get; set; }
        public int NH3 { get; set; }
    }
}
