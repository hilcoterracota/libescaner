

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using libescaner.Core.Repository;
using libescaner.Model.Catalog;
using Microsoft.EntityFrameworkCore;

namespace libescaner.Core.Controller
{
    public class CategoriaRepo : ICategoria

    {
        private readonly LibEscanerDbContext context;
        public CategoriaRepo(LibEscanerDbContext _context)
        {
            context = _context;
        }

        public async Task<Categoria> Add(Categoria value)
        {
            await context.Categoria.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<bool> Delete(Categoria value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Categoria> FindById(string value)
        {
            return await context.Categoria.Where(x => x.Id == value).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await context.Categoria.ToListAsync();
        }

        public async Task<Categoria> Update(Categoria value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Categoria.FirstOrDefaultAsync(i => i.Id == value.Id);
        }

    }
}