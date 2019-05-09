using System;
using System.ComponentModel.DataAnnotations;

namespace AcmeCorporation.Models
{
    public class Serial
    {
        [RegularExpression(@"ACME#[0-5][0-9]-(0[1-9]|1[0-2])(0[1-9]|1[0-4]|[4-9][0-9])-[WR]", ErrorMessage = "Invalid serial - Format is ACME#-XX-XXXX-Y <br>X is a number and Y is a letter")]
        [StringLength(15)]
        public String ID { get; set; }
    }
}
