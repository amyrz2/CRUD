 using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    // model for categories with ID number and name
	public class Category
	{
        [Key]
        [Required]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}

