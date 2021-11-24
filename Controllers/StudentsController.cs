/*************************************************************
* File name: StudentController.cs
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
using System.Linq;
using System.Threading.Tasks;
using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsDbContext _context;

        public StudentsController(StudentsDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get collection of Students.
        /// </summary>
        /// <returns>A Collection of Students</returns>
        /// <response code="200">Returns a collection of Students</response>
        /// <response code="500">Internal error</response>      
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }
      
        // GET: Student
         /// <summary>
         /// Get a Student.
         /// </summary>
         /// <param id="id"></param>
         /// <returns>A Student</returns>
         /// <response code="201">Returns a collection of Students</response>
         /// <response code="400">If the id is malformed</response>      
         /// <response code="404">If the Student is null</response>      
         /// <response code="500">Internal error</response>
         [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status404NotFound)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         public async Task<ActionResult<Student>> GetById(Guid id)
         {
             Student student = await _context.Students.FindAsync(id);
             if (student == null)
             {
                 return NotFound();
             }
             return Ok(student);
         }

        
        /// <summary>
        /// Creates A Student.
        /// </summary>
        /// <returns>A collection of Students</returns>
        /// <response code="200">Returns a collection of Students</response>
        /// <response code="500">Internal error</response>    

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> CreateAsync([Bind("LastName,FirstName")] StudentBase studentBase)
        {
            Student student = new Student
            {
                LastName = studentBase.LastName,
                FirstName = studentBase.FirstName
            };

            _context.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = student.ID }, student);

        }
        /* private ActionResult<Student> CreatedAtActionResult(string v, object p, Student student)
        {
            throw new NotImplementedException();
        }*/


        /// PUT: Students/5
        /// <summary>
        /// Updates a Student.
        /// </summary>
        /// <param id="id"></param>
        /// <returns>An updated Student</returns>
        /// <response code="200">Returns the updated Student</response>
        /// <response code="404">If the Student is null or resource does not exist</response>
        /// <response code="400">If the Student or id is malformed</response>      
        /// <response code="500">Internal error</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Student>> Update(Guid id, [Bind("Make,Price")] StudentBase studentBase)
        {
            Student student = new Student
            {
                LastName = studentBase.LastName,
                FirstName = studentBase.FirstName
            };

            if (!StudentExists(id))
            {
                student.ID = id;
                _context.Add(student);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = student.ID }, student);
            }

            Student dbStudent = await _context.Students.FindAsync(id);
            dbStudent.FirstName = student.FirstName;
            dbStudent.LastName = student.LastName;

            _context.Update(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(dbStudent);
        }
        //Delete Student From Database
        // DELETE: Students/5
        /// <summary>
        /// Deletes a Student.
        /// </summary>
        /// <param id="id"></param>
        /// <response code="202">Student is deleted</response>
        /// <response code="400">If the id is malformed</response>      
        /// <response code="500">Internal error</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Accepted();
        }
        private bool StudentExists(Guid id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}


       
    