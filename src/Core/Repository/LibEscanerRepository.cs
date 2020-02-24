using System.Collections.Generic;
using System.Threading.Tasks;
using libescaner.Model.Entities;

namespace libescaner.Core.Repository
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> FindClienteById(string value);
        Task<Cliente> AddCliente(Cliente value);
        Task<Cliente> UpdateCliente(Cliente value);
        Task<bool> DeleteCliente(Cliente value);
    }

}