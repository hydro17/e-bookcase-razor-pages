using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBookcase.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(@"[^\d]*", ErrorMessage = "Digits are not allowed")]
        public string Author { get; set; }

        [RegularExpression(@"[\d-]*", ErrorMessage = "Only digits and \"-\" are allowed")]
        public string ISBN { get; set; }
    }
}
