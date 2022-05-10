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
        [RegularExpression(@"^[А-Я][а-яА-я\s]*$", ErrorMessage = "Фамилия введена неверно")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        [RegularExpression(@"^[А-Я][а-яА-я\s]*$", ErrorMessage = "Имя введено неверно")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        [RegularExpression(@"^[А-Я][а-яА-я\s]*$", ErrorMessage = "Отчество введено неверно")]
        public string PatronymicName { get; set; }

        [Display(Name = "Общий стаж работы")]
        [Range(0, 70, ErrorMessage = "Опыт работы должен содержать только цифры и не может превышать 70 лет")]
        public string WorkExperience { get; set; }

        [Display(Name = "Стаж педагогической работы")]
        [Range(0, 70, ErrorMessage = "Опыт работы должен содержать только цифры и не может превышать 70 лет")]
        public string TeachingExperience { get; set; }

        [Display(Name = "Образование")]
        public string Education { get; set; }

        [Display(Name = "Подробнее")]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Display(Name = "Почта")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Адрес электронной почты введен неверно")]
        [DataType(DataType.EmailAddress)]
        public string Emails { get; set; }

        [Display(Name = "Расписание преподавателя")]
        [DataType(DataType.Url)]
        public string Schedule { get; set; }

        [Display(Name = "Повышение квалификации")]
        public string Training { get; set; }

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