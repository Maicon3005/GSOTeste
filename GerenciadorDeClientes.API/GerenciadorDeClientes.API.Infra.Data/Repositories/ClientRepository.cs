using System;
using System.Collections.ObjectModel;
using GerenciadorDeClientes.API.Domain.Entities;
using GerenciadorDeClientes.API.Domain.Repositories;
using GerenciadorDeClientes.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeClientes.API.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _db;

        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _db.Add(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(Client client)
        {
            _db.Remove(client);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Client client)
        {
            _db.Update(client);
            await _db.SaveChangesAsync();
        }

        public Task<Client> GetByIdAssync(int id)
        {
            return _db.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<Client>> GetClientAsync()
        {
            return await _db.Clients.ToListAsync();
        }
    }
}
