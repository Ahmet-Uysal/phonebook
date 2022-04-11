namespace MiddleWares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        public ExceptionHandler(RequestDelegate Next)
        {
            next = Next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Exception ==> " + ex.Message);
            }
        }
    }
}