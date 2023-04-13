using BaikalNews.DAL.Interfeces;
using BaikalNews.Domain.Models;

namespace BaikalNews.DAL.Rerositories;

public class CommentRepository : IBaseRepository<Comment>
{
    private readonly AppDbContext _appDbContext;

    public CommentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Create(Comment entity)
    {
        await _appDbContext.Comments.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Update(Comment entity)
    {
        _appDbContext.Comments.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(Comment entity)
    {
        _appDbContext.Comments.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public IQueryable<Comment> Get()
    {
        return _appDbContext.Comments;
    }
}