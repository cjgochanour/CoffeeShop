using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }
        [Required]
        public int BeanVarietyId { get; set; }
        public BeanVariety BeanVariety { get; set; }
    }
}
