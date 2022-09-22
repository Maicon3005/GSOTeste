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

        public async Task<ResultService> DeleteAsync(int id)
        {
            var client = await _clientRepository.GetByIdAssync(id);
            if (client == null)
                return ResultService.Fail("Pessoa não encontrada!");

            await _clientRepository.DeleteAsync(client);
            return ResultService.Ok($"Pessoa de id:{id} deletada");
        }

        public async Task<ResultService<ICollection<ClientDTO>>> GetAsync()
        {
            var client = await _clientRepository.GetClientAsync();
            return ResultService.Ok<ICollection<ClientDTO>>(_mapper.Map<ICollection<ClientDTO>>(client));
        }

        public async Task<ResultService<ClientDTO>> GetByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAssync(id);
            return ResultService.Ok(_mapper.Map<ClientDTO>(client));
        }

        public async Task<ResultService> UpdateAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new ClientDTOValidator().Validate(clientDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com a validação dos campos", validation);

            var client = await _clientRepository.GetByIdAssync(clientDTO.Id);
            if (client == null)
                return ResultService.Fail("Cliente não encontrado!");

            client = _mapper.Map<ClientDTO, Client>(clientDTO, client);
            await _clientRepository.EditAsync(client);
            return ResultService.Ok("Cliente editado");
        }
    }
}
