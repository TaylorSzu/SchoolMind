using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School_Mind.Models;
using School_Mind.Repository;
using School_Mind.Services;

namespace School_Mind.Controllers
{
    public class AttendanceListController : Controller
    {
        private readonly IAttendanceListRepository _attendanceListRepository;

        public AttendanceListController(IAttendanceListRepository attendanceListRepository)
        {
            _attendanceListRepository = attendanceListRepository;
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

        [HttpPost("/AttendanceList/Create")]
        public async Task<IActionResult> CreateAttendance([FromBody] AttendanceList attendance)
        {
            try
            {
                if (attendance == null)
                {
                    return BadRequest("A presença não pode ser nula.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdAttendance = await _attendanceListRepository.AddAttendanceAsync(
                    attendance
                );
                return CreatedAtAction(
                    nameof(GetAttendanceById),
                    new { id = createdAttendance.Id },
                    createdAttendance
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao criar a presença: {ex.Message}");
            }
        }

        [HttpGet("/AttendanceList/FindById/{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            try
            {
                var attendance = await _attendanceListRepository.GetAttendanceByIdAsync(id);

                if (attendance == null)
                {
                    return NotFound();
                }

                return Ok(attendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao buscar a presença: {ex.Message}");
            }
        }

        // Obter todas as presenças de um aluno em uma turma
        [HttpGet("/AttendanceList/FindById/student/{studentId}/class/{classId}")]
        public async Task<IActionResult> GetAttendancesByStudentAndClass(int studentId, int classId)
        {
            try
            {
                var attendances =
                    await _attendanceListRepository.GetAttendancesByStudentAndClassAsync(
                        studentId,
                        classId
                    );

                if (attendances == null || attendances.Count == 0)
                {
                    return NotFound("Nenhuma presença encontrada para o aluno nesta turma.");
                }

                return Ok(attendances);
            }
            catch (Exception ex)
            {
                // Logar o erro, se necessário
                return StatusCode(500, $"Erro interno ao buscar as presenças: {ex.Message}");
            }
        }

        // Obter todas as presenças de um aluno
        [HttpGet("/AttendanceList/FindById/student/{studentId}")]
        public async Task<IActionResult> GetAttendancesByStudent(int studentId)
        {
            try
            {
                var attendances = await _attendanceListRepository.GetAttendancesByStudentIdAsync(
                    studentId
                );

                if (attendances == null || attendances.Count == 0)
                {
                    return NotFound("Nenhuma presença encontrada para o aluno.");
                }

                return Ok(attendances);
            }
            catch (Exception ex)
            {
                // Logar o erro, se necessário
                return StatusCode(
                    500,
                    $"Erro interno ao buscar as presenças do aluno: {ex.Message}"
                );
            }
        }

        // Atualizar uma presença
        [HttpPut("/AttendanceList/Update/{id}")]
        public async Task<IActionResult> UpdateAttendance(
            int id,
            [FromBody] AttendanceList attendance
        )
        {
            try
            {
                if (attendance == null || attendance.Id != id)
                {
                    return BadRequest("Presença inválida.");
                }

                var updatedAttendance = await _attendanceListRepository.UpdateAttendanceAsync(
                    attendance
                );

                if (updatedAttendance == null)
                {
                    return NotFound();
                }

                return Ok(updatedAttendance);
            }
            catch (Exception ex)
            {
                // Logar o erro, se necessário
                return StatusCode(500, $"Erro interno ao atualizar a presença: {ex.Message}");
            }
        }

        // Excluir uma presença
        [HttpDelete("/AttendanceList/Delete/{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            try
            {
                var attendance = await _attendanceListRepository.GetAttendanceByIdAsync(id);

                if (attendance == null)
                {
                    return NotFound();
                }

                await _attendanceListRepository.DeleteAttendanceAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Logar o erro, se necessário
                return StatusCode(500, $"Erro interno ao excluir a presença: {ex.Message}");
            }
        }
    }
}
