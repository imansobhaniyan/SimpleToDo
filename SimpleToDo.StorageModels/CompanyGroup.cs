namespace SimpleToDo.StorageModels;

public class CompanyGroup
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public int GroupId { get; set; }

    public Company Company { get; set; }
    public Group Group { get; set; }
}
