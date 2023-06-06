using System;
using System.Collections.Generic;
using System.Linq;
using TestBackend.Models;

namespace TestBackend.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private List<Tarefa> _tarefas;

        public TarefaRepository()
        {
            _tarefas = new List<Tarefa>();
        }

        public Tarefa CriarTarefa(Tarefa tarefa)
        {
            tarefa.Id = _tarefas.Count + 1;
            _tarefas.Add(tarefa);
            return tarefa;
        }

        public Tarefa AtualizarEstado(int tarefaId, string estado)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == tarefaId);
            if (tarefa != null)
            {
                tarefa.Estado = estado;
            }
            return tarefa;
        }

        public TimeSpan RetornarPeriodoEmAndamento(int tarefaId)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == tarefaId);
            if (tarefa != null && tarefa.Estado == "Em Andamento" && tarefa.DataInicio != null && tarefa.DataFinalizacao != null)
            {
                return tarefa.DataFinalizacao.Value - tarefa.DataInicio;
            }
            return TimeSpan.Zero;
        }

        public void FinalizarTarefa(int tarefaId)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == tarefaId);
            if (tarefa != null && tarefa.Estado != "Finalizada")
            {
                tarefa.Estado = "Finalizada";
                tarefa.DataFinalizacao = DateTime.Now;
            }
        }

        public void IniciarTarefaAgendada(int tarefaId)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.Id == tarefaId);
            if (tarefa != null && tarefa.Estado == "Agendada")
            {
                tarefa.Estado = "Em Andamento";
                tarefa.DataInicio = DateTime.Now;
            }
        }

        public void AnexarArquivo(int tarefaId, string caminhoArquivo)
        {
            // Salvar o arquivo localmente
        }
    }
}
