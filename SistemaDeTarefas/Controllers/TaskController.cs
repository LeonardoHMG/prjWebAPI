using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRespository _taskRespository;
        public TaskController(ITaskRespository taskRespository)
        {
            _taskRespository = taskRespository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> Get()
        {
            List<TaskModel> tasks = await _taskRespository.GetTasks();
            return Ok(tasks);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetById(int id)
        {
           TaskModel task = await _taskRespository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Add([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRespository.Add(taskModel);
            return Ok(task);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRespository.Update(taskModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            bool delete = await _taskRespository.Delete(id);
            return Ok(delete);
        }
    }
}
