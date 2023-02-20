
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesApp.Models {

// 'Movie' class to record data
    public class Category {
        [Key]
        [Required]
        public int categoryID { get; set; }

        [Required]
        public string name { get; set; }
    }
}
