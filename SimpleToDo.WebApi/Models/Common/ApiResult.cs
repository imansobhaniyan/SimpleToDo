namespace SimpleToDo.WebApi.Models.Common
{
    public class ApiResult<T>
    {
        private ApiResult()
        {
        }

        public T? Result { get; set; }
        public string? Error { get; set; }
        public bool Success { get; set; }

        public static ApiResult<T> AlreadyExists { get; } = new ApiResult<T> { Error = "Item already exists" };
        public static ApiResult<T> NotFound { get; } = new ApiResult<T> { Error = "Item not found" };
        public static ApiResult<T> NotAuthorized { get; } = new ApiResult<T> { Error = "Request not authorized" };

        public static ApiResult<T> CreateSuccessResult(T? result)
        {
            return new ApiResult<T>
            {
                Success = true,
                Result = result
            };
        }

        public static ApiResult<T> CreateErrorResult(Exception ex, string? message = null)
        {
            return new ApiResult<T>
            {
                Error = message ?? ex.Message
            };
        }
    }
}
