using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School_Mind.Repository;
using School_Mind.Models;

namespace School_Mind.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarRepository _calendarRepository;

        public CalendarController(ICalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
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
        [HttpPost("/Calendar/NewEvent")]
        public async Task<IActionResult> Create([FromBody] Calendar calendar){
            try
            {
                await _calendarRepository.newEvent(calendar);
                return Ok("Evento cadastrado com sucesso no calendario");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //funcionando
        [HttpGet("/Calendar/ListEvents")]
        public async Task<IActionResult> ListAllEvents(){
            try
            {
                var events = await _calendarRepository.listEvent();
                return Json(events);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //funcionando
        [HttpPut("/Calendar/UpdateEvent/{id}")]
        public async Task<IActionResult> updateEvent(int id, [FromBody] Calendar calendar){
            try
            {
                await _calendarRepository.updateEvent(calendar);
                return Ok("Calendario atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //funcionando
        [HttpDelete("/Calendar/DeleteEvent/{id}")]
        public async Task<IActionResult> DeleteEvent(int id){
            try
            {
                var calendar = await _calendarRepository.findById(id);
                await _calendarRepository.deleteEvent(id);
                return Ok("Evento deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}