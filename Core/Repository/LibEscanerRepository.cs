using System.Collections.Generic;
using System.Threading.Tasks;
using libescaner.Model.Breakers;
using libescaner.Model.Catalog;
using libescaner.Model.Entities;

namespace libescaner.Core.Repository
{
    public interface IArchivo
    {
        Task<IEnumerable<Archivo>> GetAll();
        Task<Archivo> FindById(string value);
        Task<Archivo> Add(Archivo value);
        Task<Archivo> Update(Archivo value);
        Task<bool> Delete(Archivo value);
    }

    public interface ICategoria
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria> FindById(string value);
        Task<Categoria> Add(Categoria value);
        Task<Categoria> Update(Categoria value);
        Task<bool> Delete(Categoria value);

    }
}