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

namespace Lab6.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students  { get; set; }
                 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}

