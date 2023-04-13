using BaikalNews.DAL.Interfeces;
using BaikalNews.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BaikalNews.DAL.Rerositories;

public class WorkerRepository : IBaseRepository<Worker>
{
    private readonly AppDbContext _appDbContext;

    public WorkerRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Create(Worker entity)
    {
        await _appDbContext.Workers.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Update(Worker entity)
    {
        _appDbContext.Workers.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task Delete(Worker entity)
    {
        _appDbContext.Workers.Remove(entity);
        _appDbContext.SaveChangesAsync();
    }

    public IQueryable<Worker> Get()
    {
        return _appDbContext.Workers;
    }
}