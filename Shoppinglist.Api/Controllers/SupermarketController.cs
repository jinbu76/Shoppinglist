using Microsoft.AspNetCore.Mvc;
using Shoppinglist.Domains.Supermarket.ServiceDefinition;
using Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

namespace Shoppinglist.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SupermarketController: ControllerBase
{
    private readonly ISupermarketService _supermarketService;

    public SupermarketController(ISupermarketService supermarketService)
    {
        _supermarketService = supermarketService;
    }

    [HttpPost]
    public async Task<SupermarketDto> CreateSupermarket([FromBody] CreateSupermarketDto supermarket)
    {
        return await _supermarketService.InsertSupermarket(supermarket);
    }

    [HttpDelete]
    public async Task DeleteSupermarket(Guid supermarketId)
    {
        await _supermarketService.DeleteSupermarket(supermarketId);
    }
    
    [HttpPut("{supermarketId}")]
    public async Task<SupermarketDto> AddAddressToSupermarket(Guid supermarketId, CreateAddressDto address)
    {
        return await _supermarketService.AddAddressToSupermarket(supermarketId, address);
    }
}