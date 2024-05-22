class Todo
{
    //Properties
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; } = "";
    
     
    public Todo ()
    {
        
    }

      public Todo(int id, int userId, string description)
    {
        this.Id = id;
        this.UserId = userId;
        this.Description = description.ToUpper();  
    }
     
     //Constructor
    public Todo(string description, int userId)
    {
        //this.Id = id;
        this.UserId = userId;
        this.Description = description.ToUpper();  
    }

    //ToString
    public override string ToString()
    {
        return $"ToDo: {Description}";  
    }
}
