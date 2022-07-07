using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POVTAS_OSU.Models
{
    public class DocumentType
    {
        public int Id { get; set; }
        public DocumentType()
        {
            Documents = new List<Document>();
        }

        
        [Display(Name = "Тип документа")]
        public string Title { get; set; }

        public ICollection<Document> Documents;
    }


}