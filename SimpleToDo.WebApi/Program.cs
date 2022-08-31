
using SimpleToDo.WebApi.Middlwwares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    var connectionStringBuilder = new Ighan.DbHelpers.Core.IghanConnectionStringBuilder(
        builder.Configuration["DbOptions:Instance"],
        builder.Configuration["DbOptions:DbName"],
        builder.Configuration["DbOptions:UserName"],
        builder.Configuration["DbOptions:Password"]
        );

    options.UseSqlServer(connectionStringBuilder.Build());
});

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthenticationMiddleware>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<ToDoDbContext>();

    await dbContext.Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllers();

app.Run();
