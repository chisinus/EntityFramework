using EF6Recipe.Contexts;
using EF6Recipe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EF6Recipe.Controllers
{
    public class Chapter3Controller : Controller
    {
        public ViewResult Index()
        {
            EF6cDemo();

            return new ViewResult();
        }

        private void EF6cDemo()
        {
            Cleanup();
            LoadData();
            //RunForEachExample();
            RunToListExampe();
            RunSingleOrDefaultExampe();
        }

        private void Cleanup()
        {
            using (var context = new Chapter3Context())
            {
                // delete previous test data
                Response.Write("Cleaning Up Previous Test Data<br />");
                Response.Write("=========<br />");
                context.Database.ExecuteSqlCommand("delete from AssociateSalary");
                context.Database.ExecuteSqlCommand("delete from Associate");
            }
        }

        private void LoadData()
        {
            using (var context = new Chapter3Context())
            {
                // add new test data
                Response.Write("Adding Test Data<br />");
                Response.Write("=========\n<br />");
                var assoc1 = new Associate { Name = "Janis Roberts" };
                var assoc2 = new Associate { Name = "Kevin Hodges" };
                var assoc3 = new Associate { Name = "Bill Jordan" };
                var salary1 = new AssociateSalary
                {
                    Salary = 39500M,
                    SalaryDate = DateTime.Parse("8/4/09")
                };
                var salary2 = new AssociateSalary
                {
                    Salary = 41900M,
                    SalaryDate = DateTime.Parse("2/5/10")
                };
                var salary3 = new AssociateSalary
                {
                    Salary = 33500M,
                    SalaryDate = DateTime.Parse("10/08/09")
                };
                assoc1.AssociateSalaries.Add(salary1);
                assoc2.AssociateSalaries.Add(salary2);
                assoc3.AssociateSalaries.Add(salary3);
                context.Associates.Add(assoc1);
                context.Associates.Add(assoc2);
                context.Associates.Add(assoc3);

                context.SaveChanges();
            }
        }

        //private void RunForEachExample()
        //{
        //    using (var context = new Chapter3Context())
        //    {
        //        Response.Write("ForEach Call<br />");
        //        Response.Write("=========<br />");
                
        //        context.Associates.Include(x => x.AssociateSalaries).ForEachAsync(x =>
        //        {
        //            Response.Write(string.Format("Here are the salaries for Associate {0}:<br />", x.Name));
        //            foreach (var salary in x.AssociateSalaries)
        //            {
        //                Response.Write(string.Format("\t{0}<br />", salary.Salary));
        //            }
        //        });
        //    }
        //}

        private void RunToListExampe()
        {
            using (var context = new Chapter3Context())
            {
                Response.Write("\n\nRunToList Call<br />");
                Response.Write("=========<br />");
                
                var associates = context.Associates.Include(x => x.AssociateSalaries).OrderBy(x => x.Name);
                foreach (var associate in associates)
                {
                    Response.Write(string.Format("Here are the salaries for Associate {0}:<br />", associate.Name));
                    foreach (var salaryInfo in associate.AssociateSalaries)
                    {
                        Response.Write(string.Format("\t{0}<br />", salaryInfo.Salary));
                    }
                }
            }
        }
        private void RunSingleOrDefaultExampe()
        {
            using (var context = new Chapter3Context())
            {
                Response.Write("\n\nSingleOrDefault Call<br />");
                Response.Write("=========<br />");

                var associate = context.Associates.Include(x => x.AssociateSalaries).OrderBy(x => x.Name).FirstOrDefault(y => y.Name == "Kevin Hodges");

                Response.Write(string.Format("Here are the salaries for Associate {0}:<br />", associate.Name));
                foreach (var salaryInfo in associate.AssociateSalaries)
                {
                    Response.Write(string.Format("\t{0}<br />", salaryInfo.Salary));
                }
            }
        }
    }
}