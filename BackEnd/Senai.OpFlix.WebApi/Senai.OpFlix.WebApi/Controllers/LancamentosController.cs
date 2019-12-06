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
    public class LancamentosController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns></returns>
        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            LancamentoRepository.Cadastrar(lancamento);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        /// <summary>
        /// Procura um lançamento pelo seu Id
        /// </summary>
        /// <param name="id">Lancamentos</param>
        /// <returns>Lancamento Buscado</returns>
       // [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Lancamentos Lancamento = LancamentoRepository.BuscarPorId(id);
            if (Lancamento == null)
            {
                return NotFound();
            }
            return Ok(Lancamento);
        }

        /// <summary>
        /// Atualiza um registro no Banco
        /// </summary>
        /// <param name="id">Busca um registro pelo Id</param>
        /// <param name="lancamento">Atualiza um Lançamento</param>
        /// <returns>Ok</returns>
        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Lancamentos lancamento)
        {
            try
            {
                Lancamentos lancamentoBuscado = LancamentoRepository.BuscarPorId(id);
                if (lancamentoBuscado == null)
                    return NotFound();
                lancamento.IdLancamento = id;
                LancamentoRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Deleta um Lançamento
        /// </summary>
        /// <param name="id">Busca o Lançamento pela a Id</param>
        /// <returns>Ok</returns>
        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }

        //[Authorize]
        [HttpGet("listar/categoria/{categoria}")]
        public IActionResult ListarPorCategoria (int categoria)
        {
            return Ok(LancamentoRepository.BuscarPorCategoria(categoria));
        }

        [HttpGet("filtroData/{data}")]
        public IActionResult FiltrarData(DateTime data)
        {
            return Ok(LancamentoRepository.BuscarPorData(data));
        }
    }
}