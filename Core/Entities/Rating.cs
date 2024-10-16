﻿using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Rating : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public double Rate { get; set; }   
        public User User { get; set; }  
        public Product Product { get; set; }

    }
}
