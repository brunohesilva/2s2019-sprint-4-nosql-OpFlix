using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Cadastrar uma categoria.
        /// </summary>
        /// <param name="categoria">Categoria</param>
        /// <returns>Mensagem de sucesso</returns>
        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            CategoriaRepository.Cadastrar(categoria);
            return Ok();     
        }

        /// <summary>
        /// Listar uma categoria
        /// </summary
        /// <returns>Lista com as categorias</returns>
        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="id">Busca uma Categoria por Id</param>
        /// <param name="categoria">Retorna CategoriaBuscada</param>
        /// <returns>Atualiza a Categoria</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Categorias categoria)
        {
            try
            {
                Categorias categoriaBuscada = CategoriaRepository.BuscarPorId(id);
                if (categoriaBuscada == null)
                    return NotFound();
                categoria.IdCategoria = id;
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}