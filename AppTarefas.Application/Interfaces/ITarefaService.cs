using AppTarefas.Domain.Entities;


namespace AppTarefas.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> ObterTodasAsync();
        Task<Tarefa> ObterPorIdAsync(int id);
        Task<Tarefa> CriarAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task DeletarAsync(int id);
    }
}
