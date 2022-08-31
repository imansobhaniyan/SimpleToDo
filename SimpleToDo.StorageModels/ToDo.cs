namespace SimpleToDo.StorageModels;

public class ToDo
{
    public ToDo()
    {
        CreateDate = DateTime.Now;
    }

    public int Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime? DoneAt { get; set; }
    public DateTime CreateDate { get; set; }
}
