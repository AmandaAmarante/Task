using Microsoft.AspNetCore.Mvc;
using Task.Data;
using Task.Models;
using Task.Repositories;

namespace Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TarefasController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todas as tarefas",
                          Description = "Obter uma lista de todas as tarefas")]
        public IEnumerable<Tarefa> Get()
        {
            return _tarefaRepository.GetTarefas();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obter uma tarefa específica",
                          Description = "Obter uma tarefa específica pelo ID")]
        public Tarefa? Get(int id)
        {
            return _tarefaRepository.GetTarefa(id);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adicionar uma nova tarefa",
                          Description = "Adicionar uma nova tarefa")]
        public Tarefa Post([FromBody] Tarefa tarefa)
        {
            return _tarefaRepository.AddTarefa(tarefa);


        }

        [HttpPut("{id}/concluida")]
        [SwaggerOperation(Summary = "Marca uma tarefa como concluida",
                   Description = "Marca uma tarefa como concluida pelo ID")]
        public void Concluida(int id, [FromBody] Tarefa tarefa)
        {
            tarefa.Id = id;
            _tarefaRepository.MarkTarefaConcluida(tarefa);
        }


        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar uma tarefa existente",
                          Description = "Atualizar uma tarefa existente pelo ID")]
        public void Put(int id, [FromBody] Tarefa tarefa)
        {
            tarefa.Id = id;
            _tarefaRepository.UpdateTarefa(tarefa);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Excluir uma tarefa existente",
                          Description = "Excluir uma tarefa existente pelo ID")]
        public void Delete(int id)
        {
            _tarefaRepository.DeleteTarefa(id);
        }
    }
}
