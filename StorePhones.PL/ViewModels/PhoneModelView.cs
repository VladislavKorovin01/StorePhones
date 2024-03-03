using System.ComponentModel.DataAnnotations;

namespace StorePhones.PL.ViewModels
{
    public class PhoneModelView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
