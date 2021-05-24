using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Ученое звание
    public class AcademicTitle
    {
        public AcademicTitle() 
        {
            ChairConsists = new List<ChairConsist>();
        }
        public int Id { get; set; }
        [Display(Name = "Ученое звание")]
        public string Title { get; set; }

        public ICollection<ChairConsist> ChairConsists;

        
    }
}