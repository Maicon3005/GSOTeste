using AutoMapper;
using GerenciadorDeClientes.API.Application.DTOs;
using GerenciadorDeClientes.API.Application.DTOs.Validations;
using GerenciadorDeClientes.API.Application.Services.Interface;
using GerenciadorDeClientes.API.Domain.Entities;
using GerenciadorDeClientes.API.Domain.Repositories;
using System;

namespace GerenciadorDeClientes.API.Application.Services
{
    public class ClientService : IClientService
    {
        public readonly IClientRepository _clientRepository;

        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {        
            _clientRepository = clientRepository;  
            _mapper = mapper;
        }

        public async Task<ResultService<ClientDTO>> CreateAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return ResultService.Fail<ClientDTO>("Objeto deve ser informado");

            var result = new ClientDTOValidator().Validate(clientDTO);

            if (!result.IsValid)
                return ResultService.RequestError<ClientDTO>("Problemas de validade!", result);

            var client = _mapper.Map<Client>(clientDTO);
            var data = await _clientRepository.CreateAsync(client);
            return ResultService.Ok<ClientDTO>(_mapper.Map<ClientDTO>(data));
        }
    }
}
