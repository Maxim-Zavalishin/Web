using BaikalNews.DAL;
using BaikalNews.DAL.Interfeces;
using BaikalNews.Domain.Enum;
using BaikalNews.Domain.Models;
using BaikalNews.Domain.Response;
using BaikalNews.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaikalNews.Service.Implementation;

public class WorkerService : IWorkerService
{
    private readonly IBaseRepository<Worker> _baseRepositories;

    public WorkerService(IBaseRepository<Worker> baseRepositories)
    {
        _baseRepositories = baseRepositories;
    }

    public IBaseResponse<List<Worker>> getWorkers()
    {
        try
        {
            var workers = _baseRepositories.Get().ToList();
            if (!workers.Any())
            {
                return new BaseResponse<List<Worker>>()
                {
                    Description = "Найдено 0 элементов",
                    StatusCode = StatusCode.UserNotFound
                };
            }

            return new BaseResponse<List<Worker>>()
            {
                Data = workers,
                StatusCode = StatusCode.OK
                
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<List<Worker>>() { Description = $"[GetWorkers] : {e.Message}", StatusCode = StatusCode.InternalServerError };
        }
    }

    public async Task<IBaseResponse<Worker>> getWorker(int id)
    {
        try
        {
            var worker = await _baseRepositories.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (worker == null)
            {
                return new BaseResponse<Worker>()
                {
                    Description = "Сотрудник не найден",
                    StatusCode = StatusCode.UserNotFound
                };
            }

            return new BaseResponse<Worker>()
            {
                StatusCode = StatusCode.OK,
                Data = worker
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Worker>()
            {
                Description = $"[GetWorker] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Worker>> create(Worker model)
    {
        try
        {
            var worker = new Worker()
            {
                Id = model.Id,
                Name = model.Name,
                Lastname = model.Lastname,
                DateCreated = DateTime.Now,
                Email = model.Email,
                Password = new Md5().HashPassword(model.Password),
                IdRole = model.IdRole,

            };

            await _baseRepositories.Create(worker);

            return new BaseResponse<Worker>()
            {
                StatusCode = StatusCode.OK,
                Data = worker
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Worker>()
            {
                Description = $"[Create] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Worker>> update(int id, Worker model)
    {
        try
        {
            var worker = await _baseRepositories.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (worker == null)
            {
                return new BaseResponse<Worker>()
                {
                    Description = "Нет пользователя",
                    StatusCode = StatusCode.OK
                };
            }

            
            worker.Name = model.Name;
            worker.Lastname = model.Lastname;
            worker.Email = model.Email;
            worker.Password = new Md5().HashPassword(model.Password);
            worker.IdRole = model.IdRole;

            _baseRepositories.Update(worker);

            return new BaseResponse<Worker>()
            {
                Data = worker,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Worker>()
            {
                Description = $"[Update] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }


    public async Task<IBaseResponse<bool>> delete(int id)
    {
        try
        {
            var worker = _baseRepositories.Get().FirstOrDefault(x => x.Id == id);
            if (worker == null)
            {
                return new BaseResponse<bool>
                {
                    Description = "Пользователь не найден",
                    StatusCode = StatusCode.OK
                };
            }

            await _baseRepositories.Delete(worker);
            return new BaseResponse<bool>()
            {
                Data = true,
                StatusCode = StatusCode.OK
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[Delete] : {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}