using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SimpleToDo.DataAccessLayer;
using SimpleToDo.WebApi.Models.Common;
using SimpleToDo.WebApi.Models.Company;

namespace SimpleToDo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ToDoDbContext dbContext;

    public CompanyController(ToDoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<ApiResult<CompanyCreateResult>> Post([FromBody] CompanyCreateModel model)
    {
        if (await dbContext.Companies.AnyAsync(f => f.Title == model.Title))
            return ApiResult<CompanyCreateResult>.AlreadyExists;

        var adminUser = new StorageModels.User
        {
            FullName = model.AdminUserFullName,
            UserName = model.AdminUserName,
            Password = model.Password
        };

        var companyAddResult = await dbContext.Companies.AddAsync(new StorageModels.Company
        {
            Id = 0,
            Title = model.Title,
            Identifier = Guid.NewGuid().ToString(),
            Users = new List<StorageModels.CompanyUser>
            {
                new StorageModels.CompanyUser { UserType = StorageModels.CompanyUser.CompanyUserType.Admin, User = adminUser }
            }
        });

        await dbContext.SaveChangesAsync();

        return ApiResult<CompanyCreateResult>.CreateSuccessResult(new CompanyCreateResult(companyAddResult.Entity, adminUser));
    }
}
