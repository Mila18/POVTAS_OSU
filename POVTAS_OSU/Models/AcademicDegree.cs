using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Ученая степень
    public class AcademicDegree
    {
        public AcademicDegree()
        {
            ChairConsists = new List<ChairConsist>();
        }
        public int Id { get; set; }
        [Display(Name = "Ученая степень")]
        public string Title { get; set; }

        public ICollection<ChairConsist> ChairConsists;
    }
}