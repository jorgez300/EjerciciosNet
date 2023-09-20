using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace PruebaEF7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly PreguntaService _PreguntaService;

        public PreguntaController(PreguntaService preguntaService)
        {
            this._PreguntaService = preguntaService;
        }

        [HttpGet("Full/{VehiculoId:int}")]
        public async Task<ActionResult> GetFull(int VehiculoId) => Ok(await this._PreguntaService.SelectFull(VehiculoId));

        [HttpPost]
        public async Task<ActionResult> Post(Pregunta item)
        {
            await this._PreguntaService.Insert(item);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Pregunta item)
        {
            await this._PreguntaService.Delete(item);
            return Ok();
        }

    }
}
