namespace SimpleToDo.WebApi.Models.User;

public class UserModel
{
    public UserModel(StorageModels.User user)
    {
        Id = user.Id;
        FullName = user.FullName;
        UserName = user.UserName;
    }

    public int Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
