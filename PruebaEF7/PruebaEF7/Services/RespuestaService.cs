using Models;
using Microsoft.EntityFrameworkCore;
using Db;

namespace Services
{
    public class RespuestaService
    {
        ConcesionarioDbContext _concesionarioDbContext;

        public RespuestaService(ConcesionarioDbContext concesionarioDbContext)
        {
            _concesionarioDbContext = concesionarioDbContext;
        }

        public async Task Insert(Respuesta Item)
        {
            await _concesionarioDbContext.Respuestas.AddAsync(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task Delete(Respuesta Item)
        {
            await _concesionarioDbContext.Respuestas.Where(b => b.Id == Item.Id).ExecuteDeleteAsync();
            await _concesionarioDbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<Respuesta>> SelectFull(int PreguntaId)
        {
            return await _concesionarioDbContext.Respuestas
                .Where(a => a.PreguntaId == PreguntaId)
                .ToListAsync<Respuesta>();
        }
    }
}
