using Application;
using Domain;
using Infrastructure;
using WebUI.Middlewares;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddDomainServices(builder.Configuration);
            builder.Services.AddUIServices(builder.Configuration);

            WebApplication app = builder.Build();
            app.UseExeptionHandling();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            }
            catch (Exception e)
            {

                
            }
        }
    }
}