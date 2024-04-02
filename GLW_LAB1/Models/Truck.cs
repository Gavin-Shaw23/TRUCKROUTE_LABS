using System.ComponentModel.DataAnnotations;

namespace GLW_LAB1.Models
{
    public class Truck
    {
        public int Truck_num { get; set; }

        [Required(ErrorMessage = "The make field is required.")]
        public string T_make { get; set; }

        [Required(ErrorMessage = "The model field is required.")]
        public string T_model { get; set; }

        [Required(ErrorMessage = "The year field is required.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The route number field is required.")]
        public int Route_number { get; set; }
    }
}
