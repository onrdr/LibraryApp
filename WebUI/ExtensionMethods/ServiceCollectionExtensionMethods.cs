using Business.Services.Abstract;
using Business.Services.Concrete;
using Business.Services.Validators.BookValidators;
using DataAccess;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.Repositories.Concrete.Cache;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

        services.AddTransient<IValidator<LendBookViewModel>, LendBookValidator>();

        return services;
    }
}
