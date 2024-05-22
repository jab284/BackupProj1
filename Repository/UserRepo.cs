using Microsoft.Data.SqlClient;

class UserRepo
{
    //private TodoListStorage _todoListStorage;  //commented out 5/21

    private readonly string _connectionString; // added 5/21

    // added method 5/21 - Dependency Injection / Constructor Injection - happening in constructor
    public UserRepo(string connString)
    {
        _connectionString = connString;
    }

    /*  -- commented 5/21 - does this get removed
    public UserRepo(TodoListStorage todoListStorage)
    {
        this._todoListStorage = todoListStorage;
    }
    */

    //Add User
    public User AddUser(User user)
    {
        
        using SqlConnection connection = new(_connectionString);  //added 5/21
        connection.Open();   //added 5/21

        string sql = "INSERT INTO [User] VALUES (@Name, @UserName, @Password)";  //added 5/21
        using SqlCommand cmd = new(sql, connection);  //added 5/21
        cmd.Parameters.AddWithValue("@Name", user.Name);  //added 5/21
        cmd.Parameters.AddWithValue("@UserName", user.UserName);  //added 5/21
        cmd.Parameters.AddWithValue("@Password", user.Password);  //added 5/21



        return null;  //added to stop errors  - placeholder
        /*  commented 5/21
        user.Id = _todoListStorage.userIdCounter;
        _todoListStorage.userIdCounter++;
        
        //Add to user table
        _todoListStorage.UserTable.Add(user.Id, user);
        
        return user;
        */
    }

    //Get user by Username
    public User GetUserByUsername(string username)
    {
        
        return null; //added to stop errors -- placeholder
        /*  commented 5/21
        //Get user from user table by username
        foreach (User user in _todoListStorage.UserTable.Values)
        {
            if (user.UserName == username)
            {
                return user;
            }
        }
        throw new ArgumentException("User not found");
        */
    }
}
