using GerenciadorDeClientes.API.Application.DTOs;
using System;

namespace GerenciadorDeClientes.API.Application.Services.Interface
{
    public interface IClientService
    {
        Task<ResultService<ClientDTO>> CreateAsync(ClientDTO clientDTO);
    }
}
