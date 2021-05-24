using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Техническое оснащение
    public class TechnicalFacility
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Title { get; set; }
        [Display(Name = "Конфигурация")]
        public string Configuration { get; set; }

        [Display(Name = "Аудитория")]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

    }
}