using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    public class NewsType
    {
        public int Id { get; set; }
        public NewsType()
        {
            Posts = new List<Post>();
        }

        [Display(Name = "Вид новости")]
        public string Title { get; set; }

        

        public ICollection<Post> Posts;
    }
}