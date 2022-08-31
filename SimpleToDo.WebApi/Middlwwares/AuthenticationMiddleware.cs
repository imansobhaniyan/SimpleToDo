namespace SimpleToDo.WebApi.Middlwwares
{
    public class AuthenticationMiddleware : IMiddleware
    {
        private readonly ToDoDbContext dbContext;

        public AuthenticationMiddleware(ToDoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var companyIdentifier = context.GetRouteValue(RouteParameters.CompanyIdentifier)?.ToString();

            if (!string.IsNullOrWhiteSpace(companyIdentifier) && !await dbContext.Companies.AnyAsync(f => f.Identifier == companyIdentifier))
            {
                await context.Response.WriteAsJsonAsync(ApiResult<object>.NotAuthorized);

                return;
            }

            await next.Invoke(context);
        }
    }
}
