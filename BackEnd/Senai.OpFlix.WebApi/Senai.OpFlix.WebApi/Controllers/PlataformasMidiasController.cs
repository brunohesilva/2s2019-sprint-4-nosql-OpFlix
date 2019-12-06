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
    public class PlataformasMidiasController : ControllerBase
    {
        private IPlataformaMidiaRepository PlataformaMidiaRepository { get; set; }

        public PlataformasMidiasController()
        {
            PlataformaMidiaRepository = new PlataformaMidiaRepository();
        }

        /// <summary>
        /// Cadastra uma Plataforma ou Mídia 
        /// </summary>
        /// <param name="plataformamidia">PlataformasMidias</param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(PlataformasMidias plataformamidia)
        {
            PlataformaMidiaRepository.Cadastrar(plataformamidia);
            return Ok();
        }

        /// <summary>
        /// Lista as Plataformas ou Mídias
        /// </summary>
        /// <returns>Lista de Plataformas ou Mídia</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaMidiaRepository.Listar());
        }

        /// <summary>
        /// Atuliza uma Plataforma ou Mídia
        /// </summary>
        /// <param name="id">Busca a Plataforma ou Mídia pelo Id</param>
        /// <param name="plataformamidia">Atualiza a Plataforma ou Mídia</param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, PlataformasMidias plataformamidia)
        {
            try
            {
                PlataformasMidias plataformamididaBuscada = PlataformaMidiaRepository.BuscarPorId(id);
                if (plataformamididaBuscada == null)
                    return NotFound();
                plataformamidia.IdPlataformaMidia = id;
                PlataformaMidiaRepository.Atualizar(plataformamidia);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Filtra a Plataforma ou Mídia pelo nome
        /// </summary>
        /// <param name="nome">PlataformasMidias</param>
        /// <returns>PlataformasMidias</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{nome}")]
        public IActionResult Filtrar(string nome)
        {
            try
            {
                PlataformasMidias plataformamidia = PlataformaMidiaRepository.FiltrarPlataforma(nome);
                if (plataformamidia == null)
                    return NotFound();
                return Ok(plataformamidia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}