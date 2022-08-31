namespace SimpleToDo.StorageModels;

public class UserToDo
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int ToDoId { get; set; }

    public bool Assigend { get; set; }
    public bool Watch { get; set; }

    public User User { get; set; }
    public ToDo ToDo { get; set; }
}
