using System;
using Microsoft.AspNetCore.Mvc;
using TestBackend.Models;
using TestBackend.Repositories;

namespace NomeDoProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefasController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost("JoaoSilva")]
        public ActionResult<Tarefa> CriarTarefaJoaoSilva()
        {
            var tarefa = new Tarefa
            {
                DataInicio = new DateTime(2021, 12, 31),
                DuracaoEstimada = TimeSpan.FromHours(1),
                Estado = "Agendada",
                PessoaId = 1
            };
            var novaTarefa = _tarefaRepository.CriarTarefa(tarefa);
            return novaTarefa;
        }

        [HttpPost("AnaSilva")]
        public ActionResult<Tarefa> CriarTarefaAnaSilva()
        {
            var tarefa = new Tarefa
            {
                DataInicio = DateTime.Now,
                DuracaoEstimada = TimeSpan.FromHours(2),
                Estado = "Agendada",
                PessoaId = 2
            };
            var novaTarefa = _tarefaRepository.CriarTarefa(tarefa);
            return novaTarefa;
        }

        [HttpPut("AtualizarEstado/{tarefaId}/{estado}")]
        public ActionResult<Tarefa> AtualizarEstadoTarefa(int tarefaId, string estado)
        {
            var tarefaAtualizada = _tarefaRepository.AtualizarEstado(tarefaId, estado);
            if (tarefaAtualizada == null)
            {
                return NotFound();
            }
            return tarefaAtualizada;
        }

        [HttpGet("RetornarPeriodoEmAndamento/{tarefaId}")]
        public ActionResult<TimeSpan> RetornarPeriodoEmAndamento(int tarefaId)
        {
            var periodoEmAndamento = _tarefaRepository.RetornarPeriodoEmAndamento(tarefaId);
            return periodoEmAndamento;
        }

        [HttpPut("FinalizarTarefa/{tarefaId}")]
        public ActionResult FinalizarTarefa(int tarefaId)
        {
            _tarefaRepository.FinalizarTarefa(tarefaId);
            return NoContent();
        }

        [HttpPut("IniciarTarefaAgendada/{tarefaId}")]
        public ActionResult IniciarTarefaAgendada(int tarefaId)
        {
            _tarefaRepository.IniciarTarefaAgendada(tarefaId);
            return NoContent();
        }

        [HttpPost("AnexarArquivo/{tarefaId}")]
        public ActionResult AnexarArquivo(int tarefaId)
        {
            // Salvar o arquivo localmente
            _tarefaRepository.AnexarArquivo(tarefaId, "caminho/do/arquivo");
            return NoContent();
        }
    }
}
