using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DohunKim.Models;

namespace Do4.Models
{
    public class Project_Language
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public Project Project { get; set; }
        [Required]
        public string LanguageName { get; set; }
        public Language Language { get; set; }
    }
}