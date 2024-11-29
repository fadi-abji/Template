using BlazorWebAppWithIdentity.Components;
using BlazorWebAppWithIdentity.Components.Account;
using Business.DataBase;
using Business.Movie.Apis;
using Business.Movie.Interfaces;
using Business.Movie.Services;
using Core.Movie.Interfaces;
using Dal.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppWithIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            //Changed AddDbContext the default one to AddDbContextFactory After scaffolding
            builder.Services.AddDbContextFactory<MainDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddQuickGridEntityFrameworkAdapter();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //this added default identity when create a new project with individual user accounts
            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<MainDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
            builder.Services.AddScoped<DataTranslationService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddTransient<IMovieApi, MovieServerSideApi>();
            builder.Services.AddScoped<IMediaService, MediaService>();
            builder.Services.AddTransient<IMediaApi, MediaServerSideApi>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton(new HttpClient());

            builder.Services.AddHttpClient();




            var app = builder.Build();

            // Seed data
            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    SeedData.Initialize(services);
            //}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAntiforgery();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();


            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
