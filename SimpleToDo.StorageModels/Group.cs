namespace SimpleToDo.StorageModels;

public class Group
{
    public int Id { get; set; }

    public string Title { get; set; }

    public List<CompanyGroup> Companies { get; set; }
    public List<GroupUser> Users { get; set; }
    public List<GroupToDo> ToDos { get; set; }
}
