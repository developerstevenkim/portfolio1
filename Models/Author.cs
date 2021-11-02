using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Do4.Models;

namespace DohunKim.Models
{
    public class Author
    {
        [Key]
        [Display(Name = "Name")]
        public string AuthorName { get; set; }
        public string ProjectName { get; set; }
        public List<Project_Author> Project_Authors { get; set; }
        public List<Occupation> Occupations { get; set; }
    }
}