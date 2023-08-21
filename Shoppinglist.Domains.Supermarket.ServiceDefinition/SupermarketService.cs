using Shoppinglist.Domains.Supermarket.Domain;
using Shoppinglist.Domains.Supermarket.Domain.Aggregate;
using Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

namespace Shoppinglist.Domains.Supermarket.ServiceDefinition
{
    public class SupermarketService: ISupermarketService
    {
        private readonly ISupermarketRepository _supermarketRepository;

        public SupermarketService(ISupermarketRepository supermarketRepository)
        {
            _supermarketRepository = supermarketRepository;
        }

        public async Task<SupermarketDto> InsertSupermarket(CreateSupermarketDto supermarket)
        {
            var supermarketId = Guid.NewGuid();
            var addressEntity = new AddressAggregate(Guid.NewGuid(), supermarket.Address.Street,
                supermarket.Address.City, supermarket.Address.PostalCode, supermarketId);

            List<AddressAggregate> addressEntities = new() { addressEntity };

            var supermarketEntity = new SupermarketAggregate(supermarketId, supermarket.Name, addressEntities);

            await _supermarketRepository.InsertSupermarket(supermarketEntity);

            List<AddressDto> addressDtos = new()
            {
                new AddressDto(addressEntity.Id, addressEntity.Street, addressEntity.City, addressEntity.PostalCode)
            };

            return new SupermarketDto(supermarketEntity.Id, supermarketEntity.Name, addressDtos);


        }

        public Task<SupermarketDto> AddAddressToSupermarket(SupermarketDto supermarket, AddressDto address)
        {
            throw new NotImplementedException();
        }

        public Task<List<SupermarketDto>> GetAllSupermarket()
        {
            throw new NotImplementedException();
        }

        public Task<SupermarketDto> GetSupermarketById(Guid supermarketId)
        {
            throw new NotImplementedException();
        }

        public Task<SupermarketDto> GetSupermarketByAddressId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditSupermarket(SupermarketDto supermarket)
        {
            throw new NotImplementedException();
        }

        public Task EditAddressFromSupermarket(Guid supermarketId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteSupermarket(Guid supermarketId)
        {
            await _supermarketRepository.DeleteSupermarket(supermarketId);
        }

        public Task DeleteAddress(Guid addressId)
        {
            throw new NotImplementedException();
        }
    }
}
