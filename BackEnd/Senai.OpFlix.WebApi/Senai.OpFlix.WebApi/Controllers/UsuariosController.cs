using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um Usuário Amin
        /// </summary>
        /// <param name="usuario">Usuarios</param>
        /// <returns>Ok</returns>
        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult CadastrarAdmin(Usuarios usuario)
        {
            UsuarioRepository.CadastrarAdmin(usuario);
            return Ok();
        }
    }
}