using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6Recipe.Models
{
    public class TableInMultipleEntitiesModel1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Field { get; set; }

        [ForeignKey("ID")]
        public virtual TableInMultipleEntitiesModel2 Model2 { get; set; }
    }
}