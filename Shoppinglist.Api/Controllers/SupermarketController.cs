using Microsoft.AspNetCore.Mvc;
using Shoppinglist.Domains.Supermarket.ServiceDefinition;
using Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

namespace Shoppinglist.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SupermarketController : ControllerBase
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

    [HttpPut("{supermarketId}")]
    public async Task EditSupermarket(Guid supermarketId, string name)
    {
        await _supermarketService.EditSupermarket(supermarketId, name);
    }

    [HttpDelete("{supermarketId}")]
    public async Task DeleteSupermarket(Guid supermarketId)
    {
        await _supermarketService.DeleteSupermarket(supermarketId);
    }

    [HttpPost("address/{supermarketId}")]
    public async Task<AddressDto> AddAddressToSupermarket(Guid supermarketId, CreateAddressDto address)
    {
        return await _supermarketService.AddAddressToSupermarket(supermarketId, address);
    }

    [HttpPut("address/{addressId}")]
    public async Task EditAddress(Guid addressId, AddressDto address)
    {
        if (address.Id != addressId) throw new BadHttpRequestException("Wrong address ids");

        await _supermarketService.EditAddress(address);
    }

    [HttpDelete("address/{addressId}")]
    public async Task DeleteAddress(Guid addressId)
    {
        await _supermarketService.DeleteAddress(addressId);
    }
}