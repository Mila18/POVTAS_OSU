using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POVTAS_OSU.Models
{
    //Состав кафедры
    public class ChairConsist
    {

        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string PatronymicName { get; set; }

        [Display(Name = "Стаж работы")]
        public string WorkExperience { get; set; }
        [Display(Name = "Фото")]
        public string Photo { get; set; }

        [NotMapped]
        public string FullName { get { return Surname + " " + Name + " " + PatronymicName; } }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        
        public int AcademicTitleId { get; set; }
        public AcademicTitle AcademicTitle { get; set; }

        
        public int AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        
        public int PositionId { get; set; }
        public Position Position { get; set; }

        
        public int ChairId { get; set; }
        public Chair Chair { get; set; }

        public ChairConsist()
        {
            Disciplines = new List<Discipline>();
        }
        public ICollection<Discipline> Disciplines { get; set; }

    }
}