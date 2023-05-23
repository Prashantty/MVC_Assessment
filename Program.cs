using Microsoft.EntityFrameworkCore;
using MVC_Assessment.Context;
using MVC_Assessment.Interface;
using MVC_Assessment.Reopsitory;

namespace MVC_Assessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TravelDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TrainingDbConnection"));

            });

            builder.Services.AddTransient<IUserInterface , UserRepository>();

            builder.Services.AddTransient<ICourseInterface , CourseRepository>();

            builder.Services.AddTransient<IBatchInterface , BatchRepository>(); 
            builder.Services.AddRazorPages();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
            });

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}