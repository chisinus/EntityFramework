using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6Recipe.Models
{
    public class Associate
    {
        public Associate()
        {
            AssociateSalaries = new HashSet<AssociateSalary>();
        }

        public int AssociateId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AssociateSalary> AssociateSalaries { get; set; }
    }

    public class AssociateSalary
    {
        public int SalaryId { get; set; }
        public int AssociateId { get; set; }
        public decimal Salary { get; set; }
        public DateTime SalaryDate { get; set; }
        public virtual Associate Associate { get; set; }
    }
}