using Db;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Services
{
    public class VehiculoService
    {
        ConcesionarioDbContext _concesionarioDbContext;

        public VehiculoService(ConcesionarioDbContext concesionarioDbContext)
        {
            _concesionarioDbContext = concesionarioDbContext;
        }


        public async Task Insert(Vehiculo Item)
        {
            await _concesionarioDbContext.Vehiculos.AddAsync(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task InsertMany(List<Vehiculo> Item)
        {
            await _concesionarioDbContext.Vehiculos.AddRangeAsync(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task Update(Vehiculo Item)
        {
            _concesionarioDbContext.Update(Item);
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task Delete(Vehiculo Item)
        {
            await _concesionarioDbContext.Vehiculos.Where(b => b.Id == Item.Id).ExecuteDeleteAsync();
            await _concesionarioDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehiculo>> Select(int? id = null)
        {

            if (id == null)
            {
                return await _concesionarioDbContext.Vehiculos.ToListAsync<Vehiculo>();
            }
            else
            {
                return await _concesionarioDbContext.Vehiculos.Where(a => a.Id == id).ToListAsync<Vehiculo>();

            }

        }

        public async Task<IEnumerable<Vehiculo>> SelectFull(int? id = null)
        {

            if (id == null)
            {
                return await _concesionarioDbContext.Vehiculos
                    .Include(e => e.Preguntas)
                    .Include(e => e.VendedoresVehiculos)
                    .ToListAsync<Vehiculo>();
            }
            else
            {
                return await _concesionarioDbContext.Vehiculos
                    .Where(a => a.Id == id)
                    .Include(e => e.Preguntas)
                    .Include(e => e.VendedoresVehiculos)
                    .ToListAsync<Vehiculo>();

            }

        }



    }
}
