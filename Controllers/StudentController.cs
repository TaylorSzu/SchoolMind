using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School_Mind.Models;
using School_Mind.Repository;

namespace School_Mind.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentProfileRepository _studentProfileRepository;

        public StudentController(IStudentProfileRepository studentProfileRepository)
        {
            _studentProfileRepository = studentProfileRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        //funcionando
        [HttpPost("/Student/RegisterStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentProfile studentProfile){
            try
            {
                await _studentProfileRepository.addStudent(studentProfile);
                return Ok("Dados adicionados com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //fucionando
        [HttpPost("/Student/AddToClass/")]
        public async Task<IActionResult> AddStudentToCLass([FromBody] JsonElement data){
            try
            {
                int classId = data.GetProperty("classId").GetInt32();
                int studentId = data.GetProperty("studentId").GetInt32();

                var updateClass = await _studentProfileRepository.addStudentToClass(classId, studentId);
                return Ok(new {mensagem = "Aluno adicionado na turma com sucesso", classe = updateClass});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //funcionando
        [HttpPut("/Student/UpdateStudent/{id}")]
        public async Task<IActionResult> EditStudent(int id, [FromBody] StudentProfile studentProfile)
        {
            try
            {
                studentProfile.Id = id;
                await _studentProfileRepository.updateStudent(studentProfile);
                return Ok("Dados do estudante atualizados com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //funcionando
        [HttpGet("/Student/ListAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _studentProfileRepository.listStudentToClass();
                return Json(students);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //funcionando
        [HttpGet("/Student/FindByStudent/{id}")]
        public async Task<IActionResult> FindById(int id){
            try
            {
                var students = await _studentProfileRepository.findStudentById(id);
                return Json(students);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Funcionando
        [HttpDelete("/Student/DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id){
            try
            {
                var student = await _studentProfileRepository.findStudentById(id);
                if (student == null)
                { 
                    return NotFound("Estudante não encontrado");
                }
                await _studentProfileRepository.deleteStudent(id);
                return Ok("Estudante deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
