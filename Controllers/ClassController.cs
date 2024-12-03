using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School_Mind.Models;
using School_Mind.Repository;

namespace School_Mind.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public IActionResult NewClass(){
            return PartialView("NewClass");
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

        [HttpPost("/Class/Create")]
        public async Task<IActionResult> Create([FromBody] Class classe){
            try
            {
                await _classRepository.create(classe);
                return Ok("Classe criada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/Class/Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Class classe){
            try
            {   
                classe.Id = id;
                await _classRepository.update(classe);
                return Ok("Classe atualizada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/Class/ListAll")]
        public async Task<IActionResult> ListAll(){
            try
            {
                var classe = await _classRepository.listAll();
                return Json(classe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //funcionando
        [HttpGet("/Class/FindById/{id}")]
        public async Task<IActionResult> FindById(int id){
            try
            {
                var classe = await _classRepository.findById(id);
                return Json(classe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/Class/Delete/{id}")]
        public async Task<IActionResult> Delete(int id){
            try
            {
                var classe = await _classRepository.findById(id);
                await _classRepository.delete(id);
                return Ok("Classe deletada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}