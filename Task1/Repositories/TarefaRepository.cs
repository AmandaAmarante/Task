using Task.Helpers;
using Task.Models;


namespace Task.Repositories
{

    public class TarefaRepository : ITarefaRepository
    {
        private DataContext _context;

        public TarefaRepository(DataContext context)
        {
            _context = context;
        }


        public IEnumerable<Tarefa> GetTarefas()
        {
            return _context.Tarefas;
        }

        public Tarefa? GetTarefa(int id)
        {
            return getTarefa(id);
        }

        public Tarefa AddTarefa(Tarefa tarefa)
        {
            tarefa.Concluida = false;
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return tarefa;

        }

        public void UpdateTarefa(Tarefa tarefa)
        {

            var old = getTarefa(tarefa.Id);
            _context.Tarefas.Remove(old);
            _context.Tarefas.Add(tarefa);

            _context.SaveChanges();
        }

        public void MarkTarefaConcluida(Tarefa tarefa)
        {
            var oldTarefa = getTarefa(tarefa.Id);

            oldTarefa.Concluida = true;
            _context.SaveChanges();
        }

        public void DeleteTarefa(int id)
        {
            var tarefa = getTarefa(id);
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
        }

        private Tarefa getTarefa(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null) throw new KeyNotFoundException("Tarefa not found");
            return tarefa;
        }

    }
}

