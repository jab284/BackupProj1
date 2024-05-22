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
    public User? AddUser(User user)
    {
        
        using SqlConnection connection = new(_connectionString);  //added 5/21
        connection.Open();   //added 5/21

        string sql = "INSERT INTO [User] VALUES (@Name, @UserName, @Password)";  //added 5/21
        using SqlCommand cmd = new(sql, connection);  //added 5/21
        cmd.Parameters.AddWithValue("@Name", user.Name);  //added 5/21
        cmd.Parameters.AddWithValue("@UserName", user.UserName);  //added 5/21
        cmd.Parameters.AddWithValue("@Password", user.Password);  //added 5/21

        //Execute the Query
        // cmd.ExecuteNonQuery(); //This executes a non-select SQL statement (inserts, updates, deletes)
        using SqlDataReader reader = cmd.ExecuteReader();

        //Extract the Results
        if (reader.Read())
        {
            //If Read() found data -> then extract it.
            User newUser = BuildUser(reader); //Helper Method for doing that repetitive task
            return newUser;
        }
        else
        {
            //Else Read() found nothing -> Insert Failed. :(
            return null;
        }


       
        /*  commented 5/21
        user.Id = _todoListStorage.userIdCounter;
        _todoListStorage.userIdCounter++;
        
        //Add to user table
        _todoListStorage.UserTable.Add(user.Id, user);
        
        return user;
        */
    }

    //Get user by Username
    public User? GetUserByUsername(string username)
    {
        
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[User] WHERE UserName = @UserName";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@UserName", username);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                User newUser = BuildUser(reader);
                return newUser;
            }

            return null; //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }









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

    private User BuildUser(SqlDataReader reader)
    {
        User newUser = new();
        newUser.Id = (int)reader["Id"];
        newUser.Name = (string)reader["Name"];
        newUser.UserName = (string)reader["userName"];
        newUser.Password = (string)reader["Password"];
       


        return newUser;
    }
}
