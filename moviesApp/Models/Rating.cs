
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesApp.Models {

// 'Movie' class to record data
    public class Rating {
        [Key]
        [Required]
        public int ratingID { get; set; }

        [Required]
        public string term { get; set; }
    }
}
