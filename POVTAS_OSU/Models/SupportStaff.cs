using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    public class SupportStaff
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

        [Display(Name = "Образование")]
        public string Education { get; set; }

        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Добавьте фото сотрудника")]
        public string Photo { get; set; }

        [NotMapped]
        public string FullName { get { return Surname + " " + Name + " " + PatronymicName; } }

        
        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int ChairId { get; set; }
        public Chair Chair { get; set; }
    }
}