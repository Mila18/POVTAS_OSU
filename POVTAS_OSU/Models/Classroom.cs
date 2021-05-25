using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Аудитории
    public class Classroom
    {
        public Classroom()
        {
            TechnicalFacilities = new List<TechnicalFacility>();
        }
        public int Id { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Номер аудитории")]
        public string Number { get; set; }

        public ICollection<TechnicalFacility> TechnicalFacilities;

        [Display(Name="МТО")]
        public int MaterialSupportId { get; set; }
        public MaterialSupport MaterialSupport { get; set; }
    }
}