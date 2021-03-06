﻿using System.ComponentModel.DataAnnotations;

namespace YelpCamps.ViewModels
{
    public class CampgroundFormVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public string Description { get; set; }
    }
}