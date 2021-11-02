using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Do4.Models;

namespace DohunKim.Models
{
    public class Project
    {
        [Key]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Application Type")]
        public string TypeName { get; set; }
        [Display(Name = "Description")]
        public string ProjectDesc { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Github")]
        public string GithubURL { get; set; }
        [Display(Name = "Demo")]
        public string DemoURL { get; set; }
        [ForeignKey("TypeName")]
        [Display(Name = "Type")]
        public ApplicationType ApplicationType { get; set; }
        // many-to-many relationship
        // https://www.youtube.com/watch?v=Qh2hgIc90y0
        [Display(Name = "Author")]
        public List<Project_Author> Project_Authors { get; set; }
        [Display(Name = "Language")]
        public List<Project_Language> Project_Languages { get; set; }
    }
}