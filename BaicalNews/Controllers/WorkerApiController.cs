using BaikalNews.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BaikalNews.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaikalNews.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkerApiController : ControllerBase
    {
        private readonly IWorkerService _services;

        public WorkerApiController(IWorkerService services)
        {
            _services = services;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IResult GetUsers()
        {
            var response = _services.getWorkers();
            return Results.Json(response.Data);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IResult> GetUser(int id)
        {
            var response = await _services.getWorker(id);

            return Results.Ok(response.Data);
        }

        // POST api/<UserController>
        [HttpPost]
        public async void Post(Worker model)
        {
            if (model.Id == 0)
            {
                model.DateCreated = DateTime.Now;
                await _services.create(model);
            }
            await _services.update(model.Id, model);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _services.delete(id);
        }
    }
}
