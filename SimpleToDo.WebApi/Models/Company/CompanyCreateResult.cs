using SimpleToDo.StorageModels;

namespace SimpleToDo.WebApi.Models.Company;

public class CompanyCreateResult
{
    public CompanyCreateResult(StorageModels.Company company, StorageModels.User adminUser)
    {
        Id = company.Id;
        UserId = adminUser.Id;

        Title = company.Title;
        UserFullName = adminUser.FullName;
        UserName = adminUser.UserName;
        Identifier = company.Identifier;
    }

    public int Id { get; set; }
    public int UserId { get; set; }

    public string Title { get; set; }
    public string UserFullName { get; set; }
    public string UserName { get; set; }
    public string Identifier { get; set; }
}