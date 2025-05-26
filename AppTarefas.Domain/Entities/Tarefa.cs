using System.ComponentModel.DataAnnotations;

namespace AppTarefas.Domain.Entities
{
    public enum StatusTarefa
    {
        Pendente,
        EmProgresso,
        Concluida
    }

    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? DataConclusao { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
    }
}
