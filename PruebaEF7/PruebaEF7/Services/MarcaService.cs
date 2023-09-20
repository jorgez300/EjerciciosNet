using Db;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Services
{
    public class MarcaService
    {
        ConcesionarioDbContext _concesionarioDbContext;

        public MarcaService(ConcesionarioDbContext concesionarioDbContext)
        {
            _concesionarioDbContext = concesionarioDbContext;
        }


        public async Task Insert(Marca Item)
        {
            await _concesionarioDbContext.Marcas.AddAsync(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task InsertMany(List<Marca> Item)
        {
            await _concesionarioDbContext.Marcas.AddRangeAsync(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task Update(Marca Item)
        {
            _concesionarioDbContext.Update(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task Delete(Marca Item)
        {
            await _concesionarioDbContext.Marcas.Where(b => b.Id == Item.Id).ExecuteDeleteAsync();
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Marca>> Select(int? id = null)
        {

            if (id == null)
            {

                return await _concesionarioDbContext.Marcas.ToListAsync<Marca>();
            }
            else
            {
                return await _concesionarioDbContext.Marcas.Where(a => a.Id == id).ToListAsync<Marca>();

            }

        }



    }
}
