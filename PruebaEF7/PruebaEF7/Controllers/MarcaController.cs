using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace PruebaEF7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly MarcaService _MarcaService;

        public MarcaController(MarcaService marcaService)
        {
            this._MarcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => Ok(await this._MarcaService.Select());


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id) => Ok(await this._MarcaService.Select(id));

        [HttpPost]
        public async Task<ActionResult> Post(Marca item)
        {
            await this._MarcaService.Insert(item);
            return Ok();
        }

        [HttpPost("Many")]
        public async Task<ActionResult> Post(List<Marca> item)
        {
            await this._MarcaService.InsertMany(item);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Marca item)
        {
            await this._MarcaService.Delete(item);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(Marca item)
        {
            await this._MarcaService.Update(item);
            return Ok();
        }

    }
}
