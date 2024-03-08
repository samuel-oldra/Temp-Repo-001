using System;
using Agenda.API.Entities;
using Agenda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        // GET: api/tarefas
        /// <summary>
        /// Listagem de Tarefas
        /// </summary>
        /// <returns>Lista de Tarefas</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Endpoint - GET: api/tarefas");

            var tarefasViewModel = new List<TarefaViewModel>();
            tarefasViewModel.AddRange(
                new List<TarefaViewModel>
                {
                    new TarefaViewModel(
                        1,
                        "Enviar e-mail",
                        "Enviar e-mail de cobrança",
                        new DateTime(2024, 03, 16, 00, 00, 00),
                        new DateTime(2024, 03, 20, 23, 59, 59),
                        TarefaEnum.Alta
                    ),
                    new TarefaViewModel(
                        2,
                        "Criar documento",
                        "Criar documento do relatório",
                        new DateTime(2024, 03, 15, 00, 00, 00),
                        new DateTime(2024, 03, 15, 23, 59, 59),
                        TarefaEnum.Media
                    )
                }
            );

            Log.Information($"{tarefasViewModel.Count()} tarefas recuperadas");

            return Ok(tarefasViewModel);
        }

        // POST: api/tarefas
        /// <summary>
        /// Cadastro da Tarefa
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "nome": "Enviar e-mail",
        ///   "descricao": "Enviar e-mail de cobrança",
        ///   "dataInicio": "2024-03-16T00:00:00.000Z",
        ///   "dataTermino": "2024-03-20T23:59:59.999Z",
        ///   "prioridade": 1
        /// }
        /// </remarks>
        /// <param name="model">Dados da Tarefa</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(TarefaPostInputModel model)
        {
            Log.Information("Endpoint - POST: api/tarefas");

            var tarefaViewModel = new TarefaViewModel(
                1,
                model.Nome,
                model.Descricao,
                model.DataInicio,
                model.DataTermino,
                model.Prioridade
            );

            return CreatedAtAction(
                nameof(GetById),
                new { id = tarefaViewModel.Id },
                tarefaViewModel
            );
        }

        // GET: api/tarefas/{id}
        /// <summary>
        /// Detalhes da Tarefa
        /// </summary>
        /// <param name="id">ID da Tarefa</param>
        /// <returns>Mostra uma Tarefa</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Information($"Endpoint - GET: api/tarefas/{id}");

            var tarefaViewModel = new TarefaViewModel(
                1,
                "Enviar e-mail",
                "Enviar e-mail de cobrança",
                new DateTime(2024, 03, 16, 00, 00, 00),
                new DateTime(2024, 03, 20, 23, 59, 59),
                TarefaEnum.Alta
            );

            return Ok(tarefaViewModel);
        }

        // PUT: api/tarefas/{id}
        /// <summary>
        /// Atualiza uma Tarefa
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "descricao": "Enviar e-mail com o relatório",
        ///   "dataInicio": "2024-03-21T00:00:00.000Z",
        ///   "dataTermino": "2024-03-28T23:59:59.000Z",
        ///   "prioridade": 2
        /// }
        /// </remarks>
        /// <param name="id">ID da Tarefa</param>
        /// <param name="model">Dados da Tarefa</param>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, TarefaPutInputModel model)
        {
            Log.Information($"Endpoint - PUT: api/tarefas/{id}");

            return NoContent();
        }

        // DELETE: api/tarefas/{id}
        /// <summary>
        /// Deleta uma Tarefa
        /// </summary>
        /// <param name="id">ID da Tarefa</param>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Log.Information($"Endpoint - DELETE: api/tarefas/{id}");

            return NoContent();
        }
    }
}
