using System.ComponentModel.DataAnnotations;

namespace Swapps.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string DonorName { get; set; }

        [Required(ErrorMessage = "Please enter an amount")]
        [Range(1, 10000, ErrorMessage = "Donation must be between 1 and 10,000")]
        public decimal Amount { get; set; }

        public string Message { get; set; }

    }
}
