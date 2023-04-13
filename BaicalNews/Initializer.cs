using BaikalNews.DAL.Interfeces;
using BaikalNews.DAL.Rerositories;
using BaikalNews.Domain.Models;
using BaikalNews.Service.Implementation;
using BaikalNews.Service.Interfaces;

namespace BaikalNews;

public static class Initializer
{
    public static void InitializeRepositories(this IServiceCollection service)
    {
        service.AddScoped<IBaseRepository<Worker>, WorkerRepository>();
        service.AddScoped<IBaseRepository<Article>, ArticleRepository>();
        service.AddScoped<IBaseRepository<Comment>, CommentRepository>();
        service.AddScoped<IBaseRepository<Category>, CategoryRepository>();
    }

    public static void InitializeServices(this IServiceCollection services)
    {
        services.AddScoped<IWorkerService, WorkerService>();
    }
}