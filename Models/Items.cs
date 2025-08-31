using System.ComponentModel.DataAnnotations;

namespace Swapps.Models
{
    public class Items
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Category { get; set; } // Clothes, Toys, Skills, Food

        public string ImagePath { get; set; }

        public bool IsApproved { get; set; } = false;
    }
}
