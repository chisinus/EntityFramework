using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6Recipe.Models
{
    [Table("MasterTable", Schema = "Chapter2")]
    public class TableWithChildrenMasterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FieldInMaster { get; set; }
    }
}