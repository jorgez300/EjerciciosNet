using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace PruebaEF7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly VehiculoService _VehiculoService;

        public VehiculoController(VehiculoService vehiculoService)
        {
            this._VehiculoService = vehiculoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => Ok(await this._VehiculoService.Select());

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id) => Ok(await this._VehiculoService.Select(id));

        [HttpGet("Full")]
        public async Task<ActionResult> GetAllFull() => Ok(await this._VehiculoService.SelectFull());

        [HttpGet("Full/{id:int}")]
        public async Task<ActionResult> GetFull(int id) => Ok(await this._VehiculoService.SelectFull(id));

        [HttpPost]
        public async Task<ActionResult> Post(Vehiculo item)
        {
            await this._VehiculoService.Insert(item);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Vehiculo item)
        {
            await this._VehiculoService.Delete(item);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Vehiculo item)
        {
            await this._VehiculoService.Update(item);
            return Ok();
        }

    }
}
