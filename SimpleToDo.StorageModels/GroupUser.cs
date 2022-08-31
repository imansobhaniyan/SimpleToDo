namespace SimpleToDo.StorageModels;

public class GroupUser
{
    public int Id { get; set; }

    public int GroupId { get; set; }
    public int UserId { get; set; }

    public Group Group { get; set; }
    public User User { get; set; }
}
