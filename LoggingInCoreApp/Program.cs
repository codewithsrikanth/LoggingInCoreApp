using Serilog;

namespace LoggingInCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Serilog
            builder.Host.UseSerilog((HostBuilderContext context,IServiceProvider services,LoggerConfiguration loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(context.Configuration)//Read configuration settins from built in IConfiguration
                .ReadFrom.Services(services);//Readout current app's services and make them available to serilog

            });

            ////Logging
            //builder.Host.ConfigureLogging(logging =>
            //{
            //    logging.ClearProviders();
            //    logging.AddConsole();
            //    logging.AddDebug();
            //    logging.AddEventLog();                
            //});

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
           


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.Logger.LogDebug("Debug - Message");
            app.Logger.LogInformation("Information - Message");
            app.Logger.LogWarning("Warning - Message");
            app.Logger.LogError("Error - Message");
            app.Logger.LogCritical("Critical - Message");
            app.Logger.LogTrace("Trace - Message");


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}