using GerenciadorDeClientes.API.Application.DTOs;
using GerenciadorDeClientes.API.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeClientes.API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO clientDTO)
        {
            var result = await _clientService.CreateAsync(clientDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
