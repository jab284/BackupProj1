class TodoListStorage
{
    public Dictionary<int, User> UserTable;
    public Dictionary<int, Todo> TodoTable;
    public int userIdCounter = 1;
    public int todoIdCounter = 1;

    //Constructor
    public TodoListStorage()
    {
        UserTable = new();
        userIdCounter++;
        TodoTable = new();
        todoIdCounter++;
    }
}
