/*************************************************************
*File name: StudentDbContext.cs
* Compiler: MS Visual Studio 2019
* Author: Vandankumar Patel
* Course: CST 8359 – .Net Enterprise Appl. dev., Lab Section: [301]
* Lab 06: Web API 
* Date: November 23 2021
* Professor: Amir Afrasiabi Rad
* Reference: example code provided by professor on Github.com
  [https://github.com/aarad-ac/WebApiCore], Steps provided in the lab document
*************************************************************/

using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lab6.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StudentsDbContext context)
        {
            context.Database.Migrate();
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }
            var students = new Student[]
            {

            new Student{FirstName="Carson",LastName="Alexander",Program="ICT"},
            new Student{FirstName="Meredith",LastName="Alonso",Program="ICT"},
            new Student{FirstName="Arturo",LastName="Anand",Program="ICT"},
            new Student{FirstName="Gytis",LastName="Barzdukas",Program="ICT"},
            };
            foreach (Student c in students)
            {
                context.Students.Add(c);
            }
            context.SaveChanges();
        }
    }
}
