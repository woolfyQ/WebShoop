﻿using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Category : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    
 
    }
}
