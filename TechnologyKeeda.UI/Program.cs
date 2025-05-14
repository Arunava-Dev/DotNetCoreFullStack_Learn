using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TechnologyKeeda.Repositories;
using TechnologyKeeda.Repositories.Implementations;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TechnologyKeeda.UI")));

            builder.Services.AddScoped<ICountryRepo,CountryRepo>(); // ICountryRepo countryRepo = new CountryRepo();
            builder.Services.AddScoped<IStateRepo,StateRepo>();
            builder.Services.AddScoped<ICityRepo, CityRepo>();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.TryAddSingleton<IHttpContextAccessor,HttpContextAccessor>();

            //Configureing Seassion
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // Configure Seassion
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
