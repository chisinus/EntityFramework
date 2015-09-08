using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6Recipe.Models
{
    [Table("ChildTable1", Schema ="Chapter2")]
    public class TableWithChildrenChildModel
    {
        public string FieldInChildTable1 { get; set; }
    }
}