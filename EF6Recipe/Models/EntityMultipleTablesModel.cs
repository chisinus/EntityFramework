using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6Recipe.Models
{
    public class EntityMultipleTablesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Field1InTable1 { get; set; }
        public string Field2InTable1 { get; set; }
        public string Field1InTable2 { get; set; }
    }
}