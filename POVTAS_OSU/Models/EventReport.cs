using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Отчет о мероприятии
    public class EventReport
    {
        public int Id { get; set; }
        [Display(Name = "Отчет")]
        public string ReportFile { get; set; }
        [Display(Name = "Дата")]
        public string Date { get; set; }
        public virtual CalendarOfEvent CalendarOfEvent { get; set; }
    }
}