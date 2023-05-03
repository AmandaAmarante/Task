using Task.Models;

namespace Task.Repositories
{
    public interface ITarefaRepository
    {
        IEnumerable<Tarefa> GetTarefas();
        Tarefa? GetTarefa(int id);
        Tarefa AddTarefa(Tarefa tarefa);
        void UpdateTarefa(Tarefa tarefa);
        void MarkTarefaConcluida(Tarefa tarefa);
        void DeleteTarefa(int id);
    }
}
