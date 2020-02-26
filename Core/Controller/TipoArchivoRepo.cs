using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libescaner.Core.Repository;
using libescaner.Model.Catalog;
using Microsoft.EntityFrameworkCore;

namespace libescaner.Core.Controller
{

    public class TipoArchivoRepo : ITipoArchivo

    {
        private readonly LibEscanerDbContext context;
        public TipoArchivoRepo(LibEscanerDbContext _context)
        {
            context = _context;
        }

        public async Task<TipoArchivo> Add(TipoArchivo value)
        {
            await context.TipoArchivo.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<bool> Delete(TipoArchivo value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<TipoArchivo> FindById(string value)
        {
            return await context.TipoArchivo.Where(x => x.Id == value)

           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TipoArchivo>> GetAll()
        {
            return await context.TipoArchivo
        .ToListAsync();
        }


        public async Task<TipoArchivo> Update(TipoArchivo value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.TipoArchivo.FirstOrDefaultAsync(i => i.Id == value.Id);


        }
    }
}

