using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POVTAS_OSU.Models
{
    //Направления подготовки
    public class EducationField
    {
        public EducationField()
        {
            Disciplines = new List<Discipline>();
        }

        public int Id { get; set; }
        [Display(Name = "Направление подготовки")]
        public string Title { get; set; }


        public int ChairId { get; set; }
        public Chair Chair { get; set; }



        public ICollection<Discipline> Disciplines;

       

    }
}