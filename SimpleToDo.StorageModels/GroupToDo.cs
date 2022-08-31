namespace SimpleToDo.StorageModels;

public class GroupToDo
{
    public int Id { get; set; }

    public int GroupId { get; set; }
    public int ToDoId { get; set; }

    public Group Group { get; set; }
    public ToDo ToDo { get; set; }
}
