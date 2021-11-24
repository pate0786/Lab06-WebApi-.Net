/*************************************************************
*File name: StudentBase.cs
* Compiler: MS Visual Studio 2019
* Author: Vandankumar Patel
* Course: CST 8359 – .Net Enterprise Appl. dev., Lab Section: [301]
* Lab 06: Web API 
* Date: November 23 2021
* Professor: Amir Afrasiabi Rad
* Reference: example code provided by professor on Github.com
  [https://github.com/aarad-ac/WebApiCore], Steps provided in the lab document
*************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6.Models
{
   public class StudentBase 
    {
     
        [Required]
        [StringLength(50)]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Program")]
        public string Program { get; set; }

    }
}
