using Microsoft.AspNetCore.Mvc;
using SchoolManagementApplication.Models;
using SchoolManagementApplication.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolManagementApplication.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly StudentServices _studentServices;

        public StudentController(StudentServices studentServices)
        {
            _studentServices = studentServices;
        }


        // GET: api/student

        [HttpGet]
        public async Task<List<Student>>  Get() => await _studentServices.GetAsync();
        




        // GET api/student/656b6330a183be1c0c320031

        [HttpGet("{id :length(24)}")]
        public async Task<ActionResult<Student>>  Get(String id)
        {
            Student student = await _studentServices.GetAsync(id);
            if (student == null) 
            {
                return NotFound();
            }

            return student;
        }





        // POST api/student
        [HttpPost]
        public async Task<ActionResult<Student>>post (Student newStudent)
        {
            await _studentServices.CreateAsync(newStudent);
            return CreatedAtAction(nameof(Get), new {id = newStudent.Id}, newStudent);
            
            
        }






        // PUT api/student/656b6330a183be1c0c320031
        [HttpPut("{id: length(24)}")]

        public async Task<ActionResult> put(String id, Student updateStudent)
        {
            Student student = await _studentServices.GetAsync(id);
            if (student == null)
            {
                return NotFound("There is no student with this id :"+ id);
            }
            updateStudent.Id =student.Id;
            await _studentServices.UpdateAsync(id, updateStudent);

            return Ok("Update successfully ");
        }






        // DELETE api/student/656b6330a183be1c0c320031
        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> Delete(String id)
        {
            Student student = await _studentServices.GetAsync(id);
            if (student == null)
            {
                return NotFound("There is no student with this id :" + id);
            }
          
            await _studentServices.RemoveAsync(id);

            return Ok("Delete successfully ");
        }

    }
}
