using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}