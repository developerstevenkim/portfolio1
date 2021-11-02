using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Do4.Models;

namespace DohunKim.Models
{
    public class Language
    {
        [Key]
        [Display(Name = "Language")]

        public string LanguageName { get; set; }

        public string ProjectName { get; set; }
        public List<Project_Language> Project_Languages { get; set; }
    }
}