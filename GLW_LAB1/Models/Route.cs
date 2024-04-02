using System.ComponentModel.DataAnnotations;

namespace GLW_LAB1.Models
{
    public class Route
    {
        public int Route_number { get; set; }

        [Required(ErrorMessage = "The origin field is required.")]
        public string Route_name { get; set; }

        [Required(ErrorMessage = "The destination field is required.")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "The distance field is required.")]
        public double R_length { get; set; }

        [Required(ErrorMessage = "The pay per KM field is required.")]
        public double R_pay_per_km { get; set; }
    }
}
