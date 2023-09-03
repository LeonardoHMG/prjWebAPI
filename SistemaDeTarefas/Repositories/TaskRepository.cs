using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class TaskRepository : ITaskRespository
    {
        public readonly DBContext _dbContext;
        public TaskRepository(DBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
           return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskModel> Add(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskById = await GetTaskById(id);

            if (taskById == null) {
                throw new Exception($" A tarefa com o id {id} não foi encontrado no banco de dados.");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Satus = task.Satus;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await GetTaskById(id);

            if (taskById == null)
            {
                throw new Exception($" A tarefa com o id {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
