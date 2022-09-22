using GerenciadorDeClientes.API.Domain.Entities;
using System;
using System.Collections.ObjectModel;

namespace GerenciadorDeClientes.API.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAssync(int id);
        Task<Collection<Client>> GetClientAsync();
        Task<Client> CreateAsync(Client client);
        Task EditAsync(Client client);
        Task DeleteAsync(Client client);
    }
}
