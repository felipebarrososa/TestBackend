using System.Collections.Generic;
using TestBackend.Models;

namespace TestBackend.Repositories
{
    public interface ITarefaRepository
    {
        Tarefa CriarTarefa(Tarefa tarefa);
        Tarefa AtualizarEstado(int tarefaId, string estado);
        TimeSpan RetornarPeriodoEmAndamento(int tarefaId);
        void FinalizarTarefa(int tarefaId);
        void IniciarTarefaAgendada(int tarefaId);
        void AnexarArquivo(int tarefaId, string caminhoArquivo);
    }
}
