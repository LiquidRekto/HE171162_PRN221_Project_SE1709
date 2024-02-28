using Microsoft.EntityFrameworkCore;
using PRN221_Project_HE171162_SE1709.Models;

namespace PRN221_Project_HE171162_SE1709
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<PRN221_PROJECT_HE171162Context>(
                opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("WebCnn"))
                );

            var app = builder.Build();
            app.MapRazorPages();
            app.UseStaticFiles();
            app.Run();
        }
    }
}