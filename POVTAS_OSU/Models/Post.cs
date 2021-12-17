using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    //Новости
    public class Post
    {
        public int Id { get; set; }
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Дата публикации")]
        public string Date { get; set; }
        [Display(Name = "Количество просмотров")]
        public int ViewsQuantity { get; set; }
        [Display(Name = "Вид новости")]
        public string NewsType { get; set; }
        [Display(Name = "Фото")]
        public string Photo { get; set; }
        [Display(Name = "Файл")]
        public string File { get; set; }



        public int ChairID { get; set; }
        public Chair Chair { get; set; }
    }
}