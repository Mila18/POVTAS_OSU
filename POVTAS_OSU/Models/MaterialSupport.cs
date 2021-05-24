using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //МТО
    public class MaterialSupport
    {
        public MaterialSupport()
        {
            Classrooms = new List<Classroom>();
        }
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Title { get; set; }

        public ICollection<Classroom> Classrooms;


        public int ChairId { get; set; }
        public Chair Chair { get; set; }
    }
}