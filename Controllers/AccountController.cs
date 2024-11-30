using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
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

        // Métodos do CRUD
        //funcionando
        [HttpPost("/Account/Register")]
        public async Task<IActionResult> Register([FromBody] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _accountRepository.register(account);
                    return Ok("Conta registrada com sucesso");
                }
                return BadRequest("Dados da conta inválidos");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }

        //funcionando
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            try
            {
                var accounts = await _accountRepository.view();
                return Json(accounts);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }

        //funcionando
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var account = await _accountRepository.findById(id);
                if (account == null)
                {
                    return NotFound("Conta não encontrada");
                }
                return Json(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }

        //funcionando
        [HttpPut("/Account/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {   
                    account.Id = id;
                    await _accountRepository.update(account);
                    return Ok("Conta atualizada com sucesso");
                }
                return BadRequest("Dados da conta inválidos");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }


        //funcionando
        [HttpDelete("/Account/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var account = await _accountRepository.findById(id);
                if (account == null)
                {
                    return NotFound("Conta não encontrada");
                }
                await _accountRepository.delete(id);
                return Ok("Conta deletada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
