using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.Entities
{
    public class Shop : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeOfSection { get; set; }

        [Required]
        public int SectionNumber { get; set; }
    }
}