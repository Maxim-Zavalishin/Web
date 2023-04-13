using BaikalNews.DAL.Interfeces;
using BaikalNews.Domain.Models;

namespace BaikalNews.DAL.Rerositories;

public class ArticleRepository : IBaseRepository<Article>
{
    private readonly AppDbContext _appDbContext;

    public ArticleRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Create(Article entity)
    {
        await _appDbContext.Articles.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Update(Article entity)
    {
        _appDbContext.Articles.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(Article entity)
    {
        _appDbContext.Articles.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public IQueryable<Article> Get()
    {
        return _appDbContext.Articles;
    }
}