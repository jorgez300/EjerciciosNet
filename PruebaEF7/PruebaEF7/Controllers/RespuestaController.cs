using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace PruebaEF7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly RespuestaService _RespuestaService;

        public RespuestaController(RespuestaService respuestaService)
        {
            this._RespuestaService = respuestaService;
        }

        [HttpGet("Full/{PreguntaId:int}")]
        public async Task<ActionResult> GetFull(int PreguntaId) => Ok(await this._RespuestaService.SelectFull(PreguntaId));

        [HttpPost]
        public async Task<ActionResult> Post(Respuesta item)
        {
            await this._RespuestaService.Insert(item);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Respuesta item)
        {
            await this._RespuestaService.Delete(item);
            return Ok();
        }
    }
}
