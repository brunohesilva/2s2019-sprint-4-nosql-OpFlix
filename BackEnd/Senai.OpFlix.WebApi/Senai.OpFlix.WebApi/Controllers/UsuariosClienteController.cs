using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosClienteController : ControllerBase
    {
        private IUsuarioClienteRepository UsuarioClienteRepository { get; set; }

        public UsuariosClienteController()
        {
            UsuarioClienteRepository = new UsuarioClienteRepository();
        }

        /// <summary>
        /// Cadastar um Usuário CLIENTE
        /// </summary>
        /// <param name="usuario">Usuarios</param>
        /// <returns>Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            UsuarioClienteRepository.Cadastrar(usuario);
            return Ok();
        }
    }
}