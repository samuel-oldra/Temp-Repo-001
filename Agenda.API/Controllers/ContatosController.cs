using Agenda.API.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase
    {
        // GET: api/contatos
        /// <summary>
        /// Listagem de Contatos
        /// </summary>
        /// <returns>Lista de Contatos</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            Log.Information("Endpoint - GET: api/contatos");

            var contatosViewModel = new List<ContatoViewModel>();
            contatosViewModel.AddRange(
                new List<ContatoViewModel>
                {
                    new ContatoViewModel(
                        1,
                        "Samuel",
                        "samuel@teste.io",
                        "(54) 99988.7766",
                        new DateTime(1984, 12, 07, 00, 00, 00)
                    ),
                    new ContatoViewModel(
                        2,
                        "Arthur",
                        "arthur@teste.io",
                        "(54) 99955.4433",
                        new DateTime(2016, 08, 19, 00, 00, 00)
                    )
                }
            );

            Log.Information($"{contatosViewModel.Count()} contatos recuperados");

            return Ok(contatosViewModel);
        }

        // POST: api/contatos
        /// <summary>
        /// Cadastro do Contato
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "nome": "Samuel",
        ///   "email": "samuel@teste.io",
        ///   "telefone": "(54) 99988.7766",
        ///   "dataNascimento": "1984-12-07T05:00:00.000Z"
        /// }
        /// </remarks>
        /// <param name="model">Dados do Contato</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ContatoPostInputModel model)
        {
            Log.Information("Endpoint - POST: api/contatos");

            var contatoViewModel = new ContatoViewModel(
                1,
                model.Nome,
                model.Email,
                model.Telefone,
                model.DataNascimento
            );

            return CreatedAtAction(
                nameof(GetById),
                new { id = contatoViewModel.Id },
                contatoViewModel
            );
        }

        // GET: api/contatos/{id}
        /// <summary>
        /// Detalhes do Contato
        /// </summary>
        /// <param name="id">ID do Contato</param>
        /// <returns>Mostra um Contato</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Information($"Endpoint - GET: api/contatos/{id}");

            var contatoViewModel = new ContatoViewModel(
                1,
                "Samuel",
                "samuel@teste.io",
                "(54) 99988.7766",
                new DateTime(1984, 12, 07, 00, 00, 00)
            );

            return Ok(contatoViewModel);
        }

        // PUT: api/contatos/{id}
        /// <summary>
        /// Atualiza um Contato
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///   "email": "samuel@teste.io",
        ///   "telefone": "(54) 99955.4433",
        ///   "dataNascimento": "1984-12-07T05:00:00.000Z"
        /// }
        /// </remarks>
        /// <param name="id">ID do Contato</param>
        /// <param name="model">Dados do Contato</param>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, ContatoPutInputModel model)
        {
            Log.Information($"Endpoint - PUT: api/contatos/{id}");

            return NoContent();
        }

        // DELETE: api/contatos/{id}
        /// <summary>
        /// Deleta um Contato
        /// </summary>
        /// <param name="id">ID do Contato</param>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Log.Information($"Endpoint - DELETE: api/contatos/{id}");

            return NoContent();
        }
    }
}
