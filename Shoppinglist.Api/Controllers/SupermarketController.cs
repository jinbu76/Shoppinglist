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

    [HttpGet]
    public async Task<List<SupermarketDto>> GetAllSuperMarket()
    {
        return await _supermarketService.GetAllSupermarket();
    }

    [HttpPut("/supermarket/{supermarketId}")]
    public async Task EditSupermarket(Guid supermarketId, string Name)
    {
        await _supermarketService.EditSupermarket(supermarketId, Name);
    }

    [HttpDelete]
    public async Task DeleteSupermarket(Guid supermarketId)
    {
        await _supermarketService.DeleteSupermarket(supermarketId);
    }
    
    [HttpPost("/address/{supermarketId}")]
    public async Task<SupermarketDto> AddAddressToSupermarket(Guid supermarketId, CreateAddressDto address)
    {
        return await _supermarketService.AddAddressToSupermarket(supermarketId, address);
    }

    
}