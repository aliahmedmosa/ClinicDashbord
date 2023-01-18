using AliMosaclinicTask.Data;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace AliMosaclinicTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Connection string .
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
                    option.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

            //add NToastNotify service to class program
            builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                PreventDuplicates = true,
                CloseButton = true
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Appointment}/{action=Index}/{id?}");

            app.Run();
        }
    }
}