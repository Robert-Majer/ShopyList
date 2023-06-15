using System.ComponentModel.DataAnnotations;

namespace ShopyList.DataAccess.Entities
{
    public class ShoppingList : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; }
        public int NumberOfProducts { get; set; }
    }
}