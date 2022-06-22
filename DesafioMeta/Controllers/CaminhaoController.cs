using DesafioMeta.Models;
using DesafioMeta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminhaoController : ControllerBase
    {
        private readonly ICaminhaoService _caminhaoService;
        private const string ANO_MODELO = "O ano deve ser o atual ou subsequente";
        private const string ANO_FABRICACAO = "O ano deve ser o atual";
        private const string MODELO = "Modelo só pode ser FH e FM";



        public CaminhaoController(ICaminhaoService caminhaoService)
        {
            _caminhaoService = caminhaoService;
        }

        /// <summary>
        /// Obtenha todos os caminhões
        /// </summary>        
        /// <returns></returns>
        /// <response code="200">Sucesso - Lista de Caminhões</response>
        /// <response code="400">Erro - Sem caminhões cadastrados</response>
        [HttpGet]
        [Route("BuscarTodos")]
        public ActionResult<List<CaminhaoModel>> BuscarTodos()
        {
            var response = _caminhaoService.BuscarTodos();

            if (response != null)
            { 
                return Ok(response);
            }

            return BadRequest("Sem caminhões cadastrados");
        }

        /// <summary>
        /// Salvar Caminhão 
        /// </summary>        
        /// <returns>Objeto Caminhão</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Salvar
        ///     {
        ///        "modelo": "FH",
        ///        "anoFabricacao": 2022,
        ///        "anoModelo": 2024
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Sucesso - Cadastrado com sucesso</response>
        /// <response code="400">Erro - Dados inválidos</response>
        [HttpPost]
        [Route("Salvar")]
        public ActionResult Salvar([FromBody] CaminhaoModel caminhao)
        {
            string validacao = ValidaDados(caminhao);

            if (string.IsNullOrEmpty(validacao))
            {
                var response = _caminhaoService.Salvar(caminhao);

                if (response != null)
                {
                    return Ok(response);
                }
            }

            return BadRequest(validacao);
        }
        /// <summary>
        /// Atualizar Caminhão 
        /// </summary>        
        /// <returns>Objeto Caminhão</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Atualizar
        ///     {
        ///        "id": 2,
        ///        "modelo": "FH",
        ///        "anoFabricacao": 2022,
        ///        "anoModelo": 2024
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Sucesso - Atualizado com sucesso</response>
        /// <response code="400">Erro - Dados inválidos</response>
        [HttpPut]
        [Route("Atualizar")]
        public ActionResult Atualizar([FromBody] CaminhaoModel caminhao)
        {
            string validacao = ValidaDados(caminhao);

            if (string.IsNullOrEmpty(validacao))
            {
                var response = _caminhaoService.Atualizar(caminhao);

                if (response != null)
                {
                    return Ok(response);
                }
            }

            return BadRequest(validacao);
        }

        /// <summary>
        /// Excluir Caminhão 
        /// </summary>        
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Deletar
        ///     {
        ///        "id": 2                
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Sucesso - Deletado com sucesso</response>
        /// <response code="400">Erro - Erro ao excluir</response>
        [HttpDelete]
        [Route("Salvar/{id}")]
        public ActionResult Deletar(long id)
        {            
            var response = _caminhaoService.Deletar(id);

            if (response)
            {
                return Ok("Deletado com sucesso");
            }

            return BadRequest("Erro ao tentar excluir. Registro não encontrado!");
           
        }
        private string ValidaDados(CaminhaoModel caminhao)
        {
            if (caminhao.AnoModelo < DateTime.Now.Year)
            {
                return ANO_MODELO;
            }
            else if (caminhao.AnoFabricacao != DateTime.Now.Year)
            {
                return ANO_FABRICACAO;
            }
            else if (!caminhao.Modelo.ToUpper().Equals("FH") && !caminhao.Modelo.ToUpper().Equals("FM"))
            {
                return MODELO;
            }

            return string.Empty;
        }
    }
}
