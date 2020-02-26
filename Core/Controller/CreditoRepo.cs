using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libescaner.Core.Repository;
using libescaner.Model.Breakers;
using Microsoft.EntityFrameworkCore;

namespace libescaner.Core.Controller
{
    public class CreditoRepo : ICredito
    {
        private readonly LibEscanerDbContext context;
        public CreditoRepo(LibEscanerDbContext _context)
        {
            context = _context;
        }

        public async Task<Credito> Add(Credito value)
        {
            await context.Credito.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<bool> Delete(Credito value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Credito> FindById(string value)
        {
            return await context.Credito.Where(x => x.Id == value)
            .Include(i => i.Acreditado)
                .ThenInclude(i => i.Archivos)
                .ThenInclude(i => i.TipoArchivo)
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Credito>> GetAll()
        {
            return await context.Credito
            .Include(i => i.Acreditado)
                .ThenInclude(i => i.Archivos)
                .ThenInclude(i => i.TipoArchivo)
            .ToListAsync();
        }

        public async Task<Credito> Update(Credito value)
        {
           context.Update(value);
            context.SaveChanges();
            return await context.Credito.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
    }


}