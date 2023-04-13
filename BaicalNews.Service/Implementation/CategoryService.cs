using BaikalNews.DAL.Interfeces;
using BaikalNews.Domain.Enum;
using BaikalNews.Domain.Models;
using BaikalNews.Domain.Response;
using BaikalNews.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaikalNews.Service.Implementation;

public class CategoryService : ICategoryService
{
    private readonly IBaseRepository<Category> _categoryRepository;

    public CategoryService(IBaseRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IBaseResponse<List<Category>> getCategories()
    {
        try
        {
            var categories = _categoryRepository.Get().ToList();
            if (!categories.Any())
            {
                return new BaseResponse<List<Category>>()
                {
                    Description = "Найдено 0 элементов",
                    StatusCode = StatusCode.UserNotFound
                };
            }

            return new BaseResponse<List<Category>>()
            {
                Data = categories,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<List<Category>>() { Description = $"[GetCategories] : {e.Message}", StatusCode = StatusCode.InternalServerError };
        }
    }

    public async Task<IBaseResponse<Category>> getCategory(int id)
    {
        try
        {
            var category = await _categoryRepository.Get().FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return new BaseResponse<Category>()
                {
                    Description = "Категория не найдена",
                    StatusCode = StatusCode.UserNotFound
                };
            }

            return new BaseResponse<Category>()
            {
                StatusCode = StatusCode.OK,
                Data = category
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Category>() { Description = $"[GetCategory] : {e.Message}", StatusCode = StatusCode.InternalServerError };
        }
    }

    public async Task<IBaseResponse<Category>> create(Category model)
    {
        try
        {
            var category = new Category()
            {
                Id = model.Id,
                Name = model.Name,
            };

            await _categoryRepository.Create(category);

            return new BaseResponse<Category>()
            {
                Data = category,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Category>() { Description = $"[CreateCategory] : {e.Message}", StatusCode = StatusCode.InternalServerError };
        }
    }

    public async Task<IBaseResponse<Category>> update(Category model)
    {
        try
        {
            var category = await _categoryRepository.Get().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (category == null)
            {
                return new BaseResponse<Category>()
                {
                    Description = "Нет категории",
                    StatusCode = StatusCode.UserNotFound
                };
            } 
            _categoryRepository.Update(category);
            return new BaseResponse<Category>()
            {
                Data = category,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Category>() { Description = $"[UpdateCategory] : {e.Message}", StatusCode = StatusCode.InternalServerError };
        }
    }

    public async Task<IBaseResponse<bool>> delete(int id)
    {
        try
        {
            var category = _categoryRepository.Get().FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return new BaseResponse<bool>()
                {
                    Description = "Категория не найдена"
                };
            }

            _categoryRepository.Delete(category);
            return new BaseResponse<bool>()
            {
                Data = true,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>() { Description = $"[UpdateCategory] : {e.Message}", StatusCode = StatusCode.InternalServerError };
        }
    }
}