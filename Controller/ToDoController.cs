class ToDoController  //added page 5/21
{
    private TodoService _todoService;

    public ToDoController(TodoService todoService)
    {
        this._todoService = todoService;
    }

    public Todo AddTodo(string description, User user)
    {
        Todo todo = _todoService.AddTodo(description, user);
        return todo;
    }

    public List<Todo> GetAllTodos(User user)
    {
        return _todoService.GetAllTodos(user);
    }
}