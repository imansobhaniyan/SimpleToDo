namespace SimpleToDo.StorageModels;

public class Company
{
    public int Id { get; set; }

    public string Title { get; set; }

    public List<CompanyUser> Users { get; set; }
    public List<CompanyGroup> Groups { get; set; }
}