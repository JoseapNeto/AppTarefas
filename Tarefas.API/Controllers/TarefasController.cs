using AppTarefas.Application.Interfaces;
using AppTarefas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Tarefas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodas()
        {
            var tarefas = await _tarefaService.ObterTodasAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var tarefa = await _tarefaService.ObterPorIdAsync(id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Tarefa tarefa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Se for informada DataConclusao, ela não pode ser anterior à DataCriacao
            if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao < tarefa.DataCriacao)
            {
                return BadRequest("A Data de Conclusão não pode ser anterior à Data de Criação.");
            }

            var novaTarefa = await _tarefaService.CriarAsync(tarefa);
            return CreatedAtAction(nameof(ObterPorId), new { id = novaTarefa.Id }, novaTarefa);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
                return BadRequest();

            if (tarefa.DataConclusao.HasValue && tarefa.DataConclusao < tarefa.DataCriacao)
            {
                return BadRequest("A Data de Conclusão não pode ser anterior à Data de Criação.");
            }

            await _tarefaService.AtualizarAsync(tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _tarefaService.DeletarAsync(id);
            return NoContent();
        }
    }
}
