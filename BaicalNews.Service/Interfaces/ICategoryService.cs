using BaikalNews.Domain.Models;
using BaikalNews.Domain.Response;

namespace BaikalNews.Service.Interfaces;

public interface ICategoryService
{
    IBaseResponse<List<Category>> getCategories();
    Task<IBaseResponse<Category>> getCategory(int id);
    Task<IBaseResponse<Category>> create(Category model);
    Task<IBaseResponse<Category>> update(Category model);
    Task<IBaseResponse<bool>> delete(int id);
}