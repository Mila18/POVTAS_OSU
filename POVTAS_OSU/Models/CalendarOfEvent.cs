using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Календарь мероприятий
    public class CalendarOfEvent
    {
        public int Id { get; set; }
        [Display(Name = "Событие")]
        public string Event { get; set; }
        [Display(Name = "Дата")]
        public string Date { get; set; }

        [Display(Name = "Отчет")]
        public string ReportFile { get; set; }

        public int ChairId { get; set; }
        public Chair Chair { get; set; }
        //[Key]
        //[ForeignKey("EventReportOf")]
        //public int EventReportId { get; set; }
        //public virtual EventReport EventReportOf { get; set; }
    }
}