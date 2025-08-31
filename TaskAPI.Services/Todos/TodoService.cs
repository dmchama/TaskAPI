using TaskAPI.Models;

namespace TaskAPI.Services.Todos
{
    public class TodoService : ITodoRepository
    {
        public List<Todo> AllTodos(int authorId)
        {
            var todos = new List<Todo>();

            var todo1 = new Todo
            {
                Id = 1,
                Title = "title 1",
                Description = "des 1",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(5),
                Status = TodoStatus.New

            };

            todos.Add(todo1);

            var todo2 = new Todo
            {
                Id = 2,
                Title = "title 2",
                Description = "des ",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(4),
                Status = TodoStatus.New

            };

            todos.Add(todo2);

            return todos;
        }

        public Todo GetTodo(int authorId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
