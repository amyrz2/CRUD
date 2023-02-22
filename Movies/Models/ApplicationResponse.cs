using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
	public class ApplicationResponse
	{
        [Key]
        [Required]
        public int ApplicationID { get; set; }

        // Foreign key relationship
        //[Required(ErrorMessage = "Please enter Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter Director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter Rating")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        public string Notes { get; set; }
    }
}

