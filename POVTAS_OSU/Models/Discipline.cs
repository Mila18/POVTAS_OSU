using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POVTAS_OSU.Models
{
    //Дисциплины
    public class Discipline
    {
        public int Id { get; set; }
        [Display(Name = "Дисциплина")]
        public string Title { get; set; }

        [Display(Name="Направление подготовки")]
        public int EducationFieldId { get; set; }
        public EducationField EducationField { get; set; }


        //public int ChairConsistId { get; set; }
        //public ChairConsist ChairConsist { get; set; }


        public Discipline()
        {
            ChairConsists = new List<ChairConsist>();
        }
        public ICollection<ChairConsist> ChairConsists { get; set; }
    }
}