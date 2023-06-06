using System;

namespace TestBackend.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public TimeSpan DuracaoEstimada { get; set; }
        public string Estado { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public int PessoaId { get; set; }
    }
}
