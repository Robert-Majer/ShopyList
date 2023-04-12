using System.ComponentModel.DataAnnotations;

namespace ShopyList.DataAccess.Entities
{
    public class Product : EntityBase
    {
        public List<ShoppingList> ShoppingLists { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        public double Price { get; set; }
    }
}