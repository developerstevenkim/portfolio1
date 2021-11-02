using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DohunKim.Models
{
    public class Occupation
    {
        [Key]
        [Display(Name = "Occupation")]
        public string OccupationTitle { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [ForeignKey("AuthorName")]
        public Author Author { get; set; }
    }
}