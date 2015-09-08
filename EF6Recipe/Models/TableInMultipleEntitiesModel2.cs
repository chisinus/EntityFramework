using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6Recipe.Models
{
    public class TableInMultipleEntitiesModel2
    {
        [Key]
        public int ID { get; set; }
        public string Field { get; set; }

        [ForeignKey("ID")]
        public virtual TableInMultipleEntitiesModel1 Model1 { get; set; }
    }
}