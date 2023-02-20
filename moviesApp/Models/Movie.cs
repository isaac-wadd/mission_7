
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesApp.Models {

// 'Movie' class to record data
    public class Movie {
        [Key]
        [Required]
        public int movieID { get; set; }

// fkey rel to category
        [Required(ErrorMessage = "you must add a movie category")]
        public int categoryID { get; set; }
        public Category category { get; set; }

// fkey rel to rating
        [Required(ErrorMessage = "you must add a movie rating")]
        public int ratingID { get; set; }
        public Rating rating { get; set; }

        [Required(ErrorMessage = "you must add a movie title")]
        public string title { get; set; }

        [Required(ErrorMessage = "you must add a movie year")]
        public string year { get; set; }

        [Required(ErrorMessage = "you must add a movie director")]
        public string director { get; set; }

        [Required]
        public bool edited { get; set; } = false;

        public string lentTo { get; set; }

        [StringLength(25)]
        public string notes { get; set; }
    }
}
