using System.ComponentModel.DataAnnotations;

namespace GLW_LAB1.Models
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public required string First_name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public required string Last_name { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email_address { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format 999-999-9999")]
        public required string Phone_number { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }


    }
}