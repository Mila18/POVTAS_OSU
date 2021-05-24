using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Должность
    public class Position
    {
        public Position()
        {
            ChairConsists = new List<ChairConsist>();
        }
        
        public int Id { get; set; }
        [Display(Name = "Должность")]
        public string Title { get; set; }
        [Display(Name = "Код должности")]
        public string PositionKey { get; set; }

        public ICollection<ChairConsist> ChairConsists;
    }
}