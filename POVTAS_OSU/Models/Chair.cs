using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Кафедра
    public class Chair
    {
        
        public Chair()
        {
            //Осуществление связи 1:m между таблицами "Кафедра" и "Состав кафедры"
            ChairConsists = new List<ChairConsist>();

            //Осуществление связи 1:m между таблицами "Кафедра" и "Вспомогательный персонал"
            SupportStaffs = new List<SupportStaff>();
            //Осуществление связи 1:m между таблицами "Кафедра" и "Календарь мероприятий"
            CalendarOfEvents = new List<CalendarOfEvent>();
            //Осуществление связи 1:m между таблицами "Кафедра" и "Новости"
            Posts = new List<Post>();
            //Осуществление связи 1:m между таблицами "Кафедра" и "Документы"
            Documents = new List<Document>();
            //Осуществление связи 1:m между таблицами "Кафедра" и "МТО"
            MaterialSupports = new List<MaterialSupport>();
            //Осуществление связи 1:m между таблицами "Кафедра" и "Направление подготовки"
            EducationFields = new List<EducationField>();

        }


        public int Id { get; set; }
        [Display(Name = "Кафедра")]
        public string Title { get; set; }
        [Display(Name = "Аббревиатура")]
        public string Abbreviation { get; set; }

        //Осуществление 1:1 между таблицами "Кафедра" и "Контакты"
        [Key]
        [ForeignKey("ContactOf")]
        public int ContactId { get; set; }
        public virtual Contact ContactOf { get; set; }


        //Осуществление связи 1:m между таблицами "Кафедра" и "Состав кафедры"
        public ICollection<ChairConsist> ChairConsists;

        //Осуществление связи 1:m между таблицами "Кафедра" и "Вспомогательный персонал"
        public ICollection<SupportStaff> SupportStaffs;

        //Осуществление связи 1:m между таблицами "Кафедра" и ""
        public ICollection<CalendarOfEvent> CalendarOfEvents ;

        //Осуществление связи 1:m между таблицами "Кафедра" и "Новости"
        public ICollection<Post> Posts;

        //Осуществление связи 1:m между таблицами "Кафедра" и "Документы"
        public ICollection<Document> Documents;

        //Осуществление связи 1:m между таблицами "Кафедра" и "МТО"
        public ICollection<MaterialSupport> MaterialSupports;

        //Осуществление связи 1:m между таблицами "Кафедра" и "Направление подготовки"
        public ICollection<EducationField> EducationFields;
    }

}