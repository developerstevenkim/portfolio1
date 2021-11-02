using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DohunKim.Models
{
    public class ApplicationType
    {
        [Key]
        [Display(Name = "Application Type")]
        public string TypeName { get; set; }
        public List<Project> Projects { get; set; }
    }
}