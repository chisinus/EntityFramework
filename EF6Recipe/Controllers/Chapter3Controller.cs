﻿using EF6Recipe.Contexts;
using EF6Recipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace EF6Recipe.Controllers
{
    public class Chapter3Controller : Controller
    {
        public ViewResult Index()
        {
            var asyncTask = EF6AAsyncDemo();

            foreach (var c in BusyChars())
            {

            }

            return new ViewResult();
        }

        private IEnumerable<char> BusyChars()
        {
            while (true)
            {
                yield return '\\';
                yield return '|';
                yield return '/';
                yield return '-';
            }
        }

        private static async Task EF6AsyncDemo()
        {
            await Cleanup();
            await LoadData();
            await RunForEachAsyncExample();
            await RunToListAsyncExampe();
            await RunSingleOrDefaultAsyncExampe();
        }

        private static async Task Cleanup()
        {
            using (var context = new Chapter3Context())
            {
                // delete previous test data
                // execute raw sql statement asynchronoulsy
                Console.WriteLine("Cleaning Up Previous Test Data");
                Console.WriteLine("=========\n");
                await context.Database.ExecuteSqlCommandAsync("delete from chapter3.AssociateSalary");
                await context.Database.ExecuteSqlCommandAsync("delete from chapter3.Associate");
                await Task.Delay(5000);
            }
        }

        private static async Task LoadData()
        {
            using (var context = new Chapter3Context())
            {
                // add new test data
                Console.WriteLine("Adding Test Data");
                Console.WriteLine("=========\n");
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
                // update datastore asynchronoulsy
                await context.SaveChangesAsync();
                await Task.Delay(5000);
            }
        }

        private static async Task RunForEachAsyncExample()
        {
            using (var context = new Chapter3Context())
            {
                Console.WriteLine("Async ForEach Call");
                Console.WriteLine("=========");
                
                // leverage ForEachAsync
                await context.Associates.Include(x => x.AssociateSalaries).ForEachAsync(x =>
                {
                    Console.WriteLine("Here are the salaries for Associate {0}:", x.Name);
                    foreach (var salary in x.AssociateSalaries)
                    {
                        Console.WriteLine("\t{0}", salary.Salary);
                    }
                });
                await Task.Delay(5000);
            }
        }
        private static async Task RunToListAsyncExampe()
        {
            using (var context = new Chapter3Context())
            {
                Console.WriteLine("\n\nAsync ToList Call");
                Console.WriteLine("=========");
                
                // leverage ToListAsync
                var associates = await context.Associates.Include(x => x.AssociateSalaries).OrderBy(x => x.Name).ToListAsync();
                foreach (var associate in associates)
                {
                    Console.WriteLine("Here are the salaries for Associate {0}:", associate.Name);
                    foreach (var salaryInfo in associate.AssociateSalaries)
                    {
                        Console.WriteLine("\t{0}", salaryInfo.Salary);
                    }
                }
                await Task.Delay(5000);
            }
        }
        private static async Task RunSingleOrDefaultAsyncExampe()
        {
            using (var context = new Chapter3Context())
            {
                Console.WriteLine("\n\nAsync SingleOrDefault Call");
                Console.WriteLine("=========");

                var associate = await context.Associates.Include(x => x.AssociateSalaries).OrderBy(x => x.Name).FirstOrDefaultAsync(y => y.Name == "Kevin Hodges");

                Console.WriteLine("Here are the salaries for Associate {0}:", associate.Name);
                foreach (var salaryInfo in associate.AssociateSalaries)
                {
                    Console.WriteLine("\t{0}", salaryInfo.Salary);
                }
                await Task.Delay(5000);
            }
        }
    }
}