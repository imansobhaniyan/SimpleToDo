using SimpleToDo.WebApi.Models.User;

namespace SimpleToDo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ToDoDbContext dbContext;

    public UserController(ToDoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet($"{{{RouteParameters.CompanyIdentifier}}}")]
    public async Task<ApiResult<List<UserModel>>> Get(string companyIdentifier)
    {
        var users = await dbContext.Users.Where(f => f.Companies.Any(x => x.Company.Identifier == companyIdentifier)).ToListAsync();

        return ApiResult<List<UserModel>>.CreateSuccessResult(users.ConvertAll(user => new UserModel(user)));
    }

    [HttpPost($"{{{RouteParameters.CompanyIdentifier}}}")]
    public async Task<ApiResult<UserAddResult>> Post(string companyIdentifier, [FromBody] UserAddModel model)
    {
        var company = await dbContext.Companies.FirstOrDefaultAsync(f => f.Identifier == companyIdentifier);

        if (await dbContext.Users.AnyAsync(f => f.UserName == model.UserName && f.Companies.Any(x => x.Company.Identifier == companyIdentifier)))
            return ApiResult<UserAddResult>.AlreadyExists;

        var userAddResult = await dbContext.Users.AddAsync(new StorageModels.User
        {
            FullName = model.FullName,
            UserName = model.UserName,
            Password = model.Password,
            Companies = new List<StorageModels.CompanyUser>
            {
                new StorageModels.CompanyUser { Company = company }
            }
        });

        await dbContext.SaveChangesAsync();

        return ApiResult<UserAddResult>.CreateSuccessResult(new UserAddResult(userAddResult.Entity));
    }
}
