using GerenciadorDeClientes.API.Application.DTOs;
using GerenciadorDeClientes.API.Domain.Entities;
using System;

namespace GerenciadorDeClientes.API.Application.Services.Interface
{
    public interface IClientService
    {
        Task<ResultService<ClientDTO>> CreateAsync(ClientDTO clientDTO);
        Task<ResultService<ICollection<ClientDTO>>> GetAsync();
        Task<ResultService<ClientDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(ClientDTO clientDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
