namespace SimpleToDo.WebApi.Models.Company;

public class CompanyCreateModel
{
    public string Title { get; set; }
    public string AdminUserFullName { get; set; }
    public string AdminUserName { get; set; }
    public string Password { get; set; }
}
