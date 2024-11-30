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
    [Route("[controller]")]
    public class TeachingMaterialController : Controller
    {
        private readonly ITeachingMaterialRepository _teachingMaterialRepository;

        public TeachingMaterialController(ITeachingMaterialRepository teachingMaterialRepository)
        {
            _teachingMaterialRepository = teachingMaterialRepository;
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

        [HttpPost("/TeachingMaterial/NewTeachingMaterial")]
        public async Task<IActionResult> NewTeachingMaterial([FromBody] TeachingMaterial teachingMaterial){
            try
            {
                await _teachingMaterialRepository.newMaterial(teachingMaterial);
                return Ok("Material Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Funcionando
        [HttpGet("/TeachingMaterial/ListAllMaterial")]
        public async Task<IActionResult> ListAllTeachingMaterial(){
            try
            {
                var teachingMaterial = await _teachingMaterialRepository.listAllMaterial();
                return Json(teachingMaterial);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Funcionando
        [HttpPut("/TeachingMaterial/UpdateMaterial/{id}")]
        public async Task<IActionResult> UpdateTeachingMaterial(int id, [FromBody] TeachingMaterial teachingMaterial){
            try
            {
                await _teachingMaterialRepository.updateMaterial(teachingMaterial);
                return Ok("Material atualizado com sucesso");
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/TeachingMaterial/DeleteMaterial/{id}")]
        public async Task<IActionResult> DeleteTeachingMaterial(int id){
            try
            {
                var teachingMaterial = await _teachingMaterialRepository.findById(id);
                await _teachingMaterialRepository.deleteMaterial(id);
                return Ok("Material deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}