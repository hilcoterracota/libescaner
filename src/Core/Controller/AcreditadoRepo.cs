using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libescaner.Core.Repository;
using libescaner.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace libescaner.Core.Controller
{
    public class AcreditadoRepo : IAcreditado

    {
        private readonly LibEscanerDbContext context;
        public AcreditadoRepo(LibEscanerDbContext _context)
        {
            context = _context;
        }

        public async Task<Acreditado> Add(Acreditado value)
        {
            await context.Acreditado.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<bool> Delete(Acreditado value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Acreditado> FindById(string value)
        {
            return await context.Acreditado.Where(x => x.Id == value)
           .Include(i => i.Archivos)
               .ThenInclude(i => i.TipoArchivo)
           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Acreditado>> GetAll()
        {
            return await context.Acreditado
            .Include(i => i.Archivos)
                .ThenInclude(i => i.TipoArchivo)
            .ToListAsync();
        }

        public async Task<Acreditado> Update(Acreditado value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Acreditado.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
    }


}