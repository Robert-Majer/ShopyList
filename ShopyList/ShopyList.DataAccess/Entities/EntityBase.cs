﻿using System.ComponentModel.DataAnnotations;

namespace ShopyList.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}