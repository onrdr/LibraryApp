using Business.Services.Abstract;
using Business.Services.Concrete;
using Business.Services.Validators.BookValidators;
using DataAccess;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.Repositories.Concrete.Cache;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Identity;
using Models.ViewModels;
using System.Reflection;

namespace WebUI.ExtensionMethods;

public static class ServiceCollectionExtensionMethods
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services
            .AddApplicationServices()
            .AddMemoryCache()
            .ConfigureDatabase(builder.Configuration)
            .AddAuthorization()
            .AddIdentity()
            .ConfigureApplicationCookie()
            .AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<BookRepository>();
        services.AddScoped<IBookRepository, CachedBookRepository>();
        services.AddScoped<IBookService, BookService>();

        services.AddScoped<AuthorRepository>();
        services.AddScoped<IAuthorRepository, CachedAuthorRepository>();
        services.AddScoped<IAuthorService, AuthorService>();

        services.AddScoped<BorrowerRepository>();
        services.AddScoped<IBorrowerRepository, CachedBorrowerRepository>();
        services.AddScoped<IBorrowerService, BorrowerService>();

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddTransient<IValidator<LendBookViewModel>, LendBookValidator>();

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    private static IServiceCollection ConfigureApplicationCookie(this IServiceCollection services)
    {
        CookieBuilder cookieBuilder = new()
        {
            Name = "LibraryApp",
            HttpOnly = false,
            SameSite = SameSiteMode.Lax,
            SecurePolicy = CookieSecurePolicy.SameAsRequest,
        };

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = new PathString("/Home/Login");
            options.LogoutPath = new PathString("/User/Logout");
            options.AccessDeniedPath = new PathString("/User/AccessDenied");
            options.Cookie = cookieBuilder;
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromDays(60);
        });

        return services;
    }
}
