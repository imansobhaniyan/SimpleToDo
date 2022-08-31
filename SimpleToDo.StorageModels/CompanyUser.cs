namespace SimpleToDo.StorageModels;

public class CompanyUser
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public int UserId { get; set; }

    public CompanyUserType UserType { get; set; }

    public Company Company { get; set; }
    public User User { get; set; }

    public enum CompanyUserType
    {
        Admin = 2,
        Agent = 4
    }
}
