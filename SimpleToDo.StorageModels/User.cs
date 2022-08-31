namespace SimpleToDo.StorageModels;

public class User
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }

    public List<GroupUser> Groups { get; set; }
    public List<CompanyUser> Companies { get; set; }
    public List<UserToDo> ToDos { get; set; }
}
