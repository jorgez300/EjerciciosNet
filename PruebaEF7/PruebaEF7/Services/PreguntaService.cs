using Db;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class PreguntaService
    {
        ConcesionarioDbContext _concesionarioDbContext;

        public PreguntaService(ConcesionarioDbContext concesionarioDbContext)
        {
            _concesionarioDbContext = concesionarioDbContext;
        }

        public async Task Insert(Pregunta Item)
        {
            await _concesionarioDbContext.Preguntas.AddAsync(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task Delete(Pregunta Item)
        {
            await _concesionarioDbContext.Preguntas.Where(b => b.Id == Item.Id).ExecuteDeleteAsync();
            await _concesionarioDbContext.SaveChangesAsync();
        }



        public async Task<IEnumerable<Pregunta>> SelectFull(int VehiculoId)
        {
                return await _concesionarioDbContext.Preguntas
                    .Where(a => a.VehiculoId == VehiculoId)
                    .Include(e => e.Respuestas)
                    .ToListAsync<Pregunta>();
        }
    }
}
