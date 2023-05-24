namespace WebUI.Middlewares
{
    public static class MiddlewareExtention
    {
        public static void UseExeptionHandling(this WebApplication app)
        {
            app.UseMiddleware<GlobalExeptionHendllar>();
        }
    }
}
