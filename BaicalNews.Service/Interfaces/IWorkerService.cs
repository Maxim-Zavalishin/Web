using System.Reflection.Metadata;
using BaikalNews.Domain.Models;
using BaikalNews.Domain.Response;

namespace BaikalNews.Service.Interfaces;

public interface IWorkerService
{
    IBaseResponse<List<Worker>> getWorkers();
    Task<IBaseResponse<Worker>> getWorker(int id);
    Task<IBaseResponse<Worker>> create(Worker model);
    Task<IBaseResponse<Worker>> update(int id, Worker model);
    Task<IBaseResponse<bool>> delete(int id);


}