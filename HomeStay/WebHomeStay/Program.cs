using Microsoft.EntityFrameworkCore;
using WebHomeStay.Models;

namespace WebHomeStay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<InternWebsiteContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Dbase")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
<<<<<<< HEAD
                pattern: "{controller=DatPhong}/{action=Index}/{id?}")
=======
                pattern: "{controller=Home}/{action=TrangChu}/{id?}")
>>>>>>> 3c12dddb396a7e1e39292c074fec216f4167d804
                .WithStaticAssets();

            app.Run();
        }
    }
}
