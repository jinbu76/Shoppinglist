using Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

namespace Shoppinglist.Domains.Supermarket.ServiceDefinition
{
    public interface ISupermarketService
    {
        Task<SupermarketDto> InsertSupermarket(CreateSupermarketDto supermarket);
        Task<SupermarketDto> AddAddressToSupermarket(Guid supermarketId, CreateAddressDto address);
        Task<List<SupermarketDto>> GetAllSupermarket();
        Task EditSupermarket(Guid supermarketId, string name);
        Task EditAddress(AddressDto address);
        Task DeleteSupermarket(Guid supermarketId);
        Task DeleteAddress(Guid addressId);
    }
}