using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Документы
    public class Document
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Title { get; set; }
        [Display(Name = "Тип документа")]
        public string DocumentType { get; set; }
        [Display(Name = "Дата документа")]
        public string DocumentDate { get; set; }
        [Display(Name = "Номер документа")]
        public string DocumentNumber { get; set; }
        [Display(Name = "Файл")]
        public string File { get; set; }


        public int ChairId { get; set; }
        public Chair Chair { get; set; }
    }
}