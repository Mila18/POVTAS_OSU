using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
        //Вид деятельности
    public class Activity
    {
        public Activity()
        {
            ChairConsists = new List<ChairConsist>();
        }
        public int Id { get; set; }
        [Display(Name = "Вид деятельности")]
        public string Title { get; set; }

        public ICollection<ChairConsist> ChairConsists;
    }
}