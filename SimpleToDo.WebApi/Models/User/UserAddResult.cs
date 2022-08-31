namespace SimpleToDo.WebApi.Models.User;

public class UserAddResult
{
    public UserAddResult(StorageModels.User user)
    {
        Id = user.Id;
        FullName = user.FullName;
        UserName = user.UserName;
    }

    public int Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
}