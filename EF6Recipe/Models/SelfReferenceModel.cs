using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6Recipe.Models
{
    public class SelfReferenceModel
    {
        [Key]
        public int ID { get; private set; }
        public string Name { get; set; }

        public int? ParentID { get; private set; }

        [ForeignKey("ParentID")]
        public SelfReferenceModel ParentModel { get; set; }

        public List<SelfReferenceModel> Children { get; set; }

        public SelfReferenceModel()
        {
            Children = new List<SelfReferenceModel>();
        }
    }
}