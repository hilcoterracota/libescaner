using System.Collections.Generic;
using System.Threading.Tasks;
using libescaner.Model.Breakers;
using libescaner.Model.Catalog;
using libescaner.Model.Entities;

namespace libescaner.Core.Repository
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> FindById(string value);
        Task<Cliente> Add(Cliente value);
        Task<Cliente> Update(Cliente value);
        Task<bool> Delete(Cliente value);
    }

    public interface ICredito
    {
        Task<IEnumerable<Credito>> GetAll();
        Task<Credito> FindById(string value);
        Task<Credito> Add(Credito value);
        Task<Credito> Update(Credito value);
        Task<bool> Delete(Credito value);
    }

      public interface IAcreditado
    {
        Task<IEnumerable<Acreditado>> GetAll();
        Task<Acreditado> FindById(string value);
        Task<Acreditado> Add(Acreditado value);
        Task<Acreditado> Update(Acreditado value);
        Task<bool> Delete(Acreditado value);
    }

    public interface IArchivo
    {
        Task<IEnumerable<Archivo>> GetAll();
        Task<Archivo> FindById(string value);
        Task<Archivo> Add(Archivo value);
        Task<Archivo> Update(Archivo value);
        Task<bool> Delete(Archivo value);
    }

      public interface ITipoArchivo
    {
        Task<IEnumerable<TipoArchivo>> GetAll();
        Task<TipoArchivo> FindById(string value);
        Task<TipoArchivo> Add(TipoArchivo value);
        Task<TipoArchivo> Update(TipoArchivo value);
        Task<bool> Delete(TipoArchivo value);
    }


}