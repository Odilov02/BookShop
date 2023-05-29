using System.Text;

namespace WebUI.Middlewares
{
    public  class GlobalExeptionHendllar
    {
        private readonly RequestDelegate _next;

        public GlobalExeptionHendllar(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

                context.Response.StatusCode = 200;
             await   context.Response.WriteAsync(e!.ToString()!);
            }
        }
    }
}
