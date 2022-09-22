using AutoMapper;
using GerenciadorDeClientes.API.Application.DTOs;
using GerenciadorDeClientes.API.Domain.Entities;
using System;

namespace GerenciadorDeClientes.API.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {

        public DtoToDomainMapping()
        {
            CreateMap<ClientDTO, Client>();
        }

    }
}
