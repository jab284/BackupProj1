class TodoRepo
{
    private TodoListStorage _todoListStorage;
    
    public TodoRepo(TodoListStorage todoListStorage)
    {
        this._todoListStorage = todoListStorage;
    }

    //Add task to user
    public Todo AddTodo(Todo todo)
    {
        todo.Id = _todoListStorage.todoIdCounter;
        _todoListStorage.todoIdCounter++;
        
        _todoListStorage.TodoTable.Add(todo.Id, todo);
        return todo;
    }

    //Get All todos by userid
    public List<Todo> GetAllTodosByUserId(int userId)
    {
        //Get user from user table by user id ->Get tasks table by user
        List<Todo> todos = new();
        foreach (Todo todo in _todoListStorage.TodoTable.Values)
        {
            if (todo.UserId == userId)
            {
                todos.Add(todo);
            }
        }
        return todos;
    }
}
