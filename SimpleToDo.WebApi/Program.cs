using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SimpleToDo.DataAccessLayer.ToDoDbContext>(options =>
{
    var connectionStringBuilder = new Ighan.DbHelpers.Core.IghanConnectionStringBuilder(
        builder.Configuration["DbOptions:Instance"],
        builder.Configuration["DbOptions:DbName"],
        builder.Configuration["DbOptions:UserName"],
        builder.Configuration["DbOptions:Password"]
        );

    options.UseSqlServer(connectionStringBuilder.Build());
});

builder.Services.AddControllers();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<SimpleToDo.DataAccessLayer.ToDoDbContext>();

    await dbContext.Database.MigrateAsync();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
