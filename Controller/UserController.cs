class UserController   //added page 5/21
{
    private UserService userService;
    public UserController(UserService userService)
    {
        this.userService = userService;
    }
    public User RegisterUser(string firstName, string userName, string password)
    {
        User user = userService.RegisterUser(firstName, userName, password);
        return user;
    }
    public User Login(string userName, string inputPassword)
    {
        User user = userService.Login(userName, inputPassword);
        return user;
    }
}