using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project.Models
{
    public enum Doctors
    {

        [Display(Name = "Raghad Al Bizreh")] RaghadB, 
        [Display(Name = "Rasha Hijazi")] RashaH, 
        [Display(Name = " Dr Fadi Maalouf")] FadiM,
        
    }
}
