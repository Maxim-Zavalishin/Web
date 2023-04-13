using BaikalNews.DAL.Interfeces;
using BaikalNews.Domain.Models;

namespace BaikalNews.DAL.Rerositories
{
    public class CategoryRepository : IBaseRepository<Category>
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(Category entity)
        {
            await _appDbContext.Categories.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Category entity)
        {
            _appDbContext.Categories.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(Category entity)
        {
            _appDbContext.Categories.Remove(entity);
            _appDbContext.SaveChangesAsync();
        }

        public IQueryable<Category> Get()
        {
            return _appDbContext.Categories;
        }
    }
}
