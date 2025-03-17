using Api.Contracts.Clients;
using Core.Models;
using Infrastructure.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClientsAsync()
        {
            try
            {
                var clients = await _service.GetAllAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClientAsync([FromBody] ClientCreateRequest request)
        {
            var client = Client.Create(
                Guid.NewGuid(),
                request.FullName,
                request.Birthday
            );

            var clientId = await _service.AddAsync( client );
            return Ok (clientId) ;
        }

        [HttpGet("birthdays/{date}")]
        public async Task<IActionResult> GetBirthdayClientsAsync([FromRoute] string date)
        {
            if (!DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                return BadRequest("Некоректний формат дати. Використовуйте формат yyyy-MM-dd.");
            }

            var clients = await _service.GetBirthdayClientsAsync(parsedDate);

            var result = clients.Select(c => new
            {
                Id = c.Id,
                FullName = c.FullName
            }).ToList();

            return Ok(result);
        }


    }
}
