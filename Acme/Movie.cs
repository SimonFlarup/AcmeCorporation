using System;
using System.ComponentModel.DataAnnotations;

namespace Acme
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
