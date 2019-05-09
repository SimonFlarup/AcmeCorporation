using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeCorporation.Models
{
    public class DrawEntry
    {
        public int ID { get; set; }

        [Display(Name = "First name")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        public String FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(60, MinimumLength = 3)]
        public String LastName { get; set; }
        [Display(Name = "Email address")]
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [RegularExpression(@"ACME#[0-5][0-9]-(0[1-9]|1[0-2])(0[1-9]|1[0-4]|[4-9][0-9])-[WR]", ErrorMessage = "Invalid serial - Format is ACME#-XX-XXXX-Y <br>X is a number and Y is a letter")]
        [StringLength(14)]
        public String Serial { get; set; }
    }
}
