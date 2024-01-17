using AuthApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AuthApi.Request;

namespace AuthApi.Controllers
{
    [Route("usuario/")]
    [Controller]
    public class UsuarioController : Controller
    {

        readonly LoginService _loginService;
        readonly CadastrarUsusarioService _cadastrarUsusarioService;

        public UsuarioController(LoginService loginService, CadastrarUsusarioService cadastrarUsusarioService)
        {
            _loginService = loginService;
            _cadastrarUsusarioService = cadastrarUsusarioService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var response = await _loginService.login(loginRequest);
                return Ok(response);
            }
            catch (Exception)
            {

                return BadRequest(
                    new
                    {
                        message = "Usuario ou senha incorretos"
                    }
                    );
            }
        }

        [HttpPost]
        [Route("cadastro")]
        [AllowAnonymous]
        public ActionResult<dynamic> CadastrarUsuario(CadastrarUsuarioRequest cadastrarUsuarioRequest)
        {
            try
            {
                _cadastrarUsusarioService.Cadastrar(cadastrarUsuarioRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
