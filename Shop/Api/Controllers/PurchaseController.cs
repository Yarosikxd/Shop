﻿using Api.Contracts.Purchase;
using Core.Models;
using Infrastructure.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchesService _service;

        public PurchaseController(IPurchesService service)
        {
            _service = service;
        }

        [HttpPost("CreatePurchase")]
        public async Task<IActionResult> CreatePurchuseAsync([FromBody]CreatePurchaseRequest request)
        {
            var purchuse = Purchase.Create(
                Guid.NewGuid(),
                request.TotalAmount,
                request.ClientId
            );

            var purchuseId = await _service.AddAsync( purchuse );
            return Ok( purchuseId ); 
        }

        [HttpGet("recent-purchases/{days}")]
        public async Task<IActionResult> GetClientsWithRecentPurchasesAsync(int days)
        {
            if (days <= 0)
                return BadRequest("Кількість днів має бути більшою за 0.");

            var clients = await _service.GetClientsWithRecentPurchasesAsync(days);

            var result = clients.Select(c => new
            {
                Id = c.id,
                FullName = c.FullName,
                LastPurchaseDate = c.LastPurchaseDate
            }).ToList();

            return Ok(result);
        }

        [HttpGet("client-categories/{clientId}")]
        public async Task<IActionResult> GetClientPurchasedCategoriesAsync(Guid clientId)
        {
            var categories = await _service.GetClientPurchasedCategoriesAsync(clientId);

            return Ok(categories);
        }
    }
}
