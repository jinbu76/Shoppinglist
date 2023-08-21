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
                new AddressDto(addressEntity.Id, addressEntity.Street, addressEntity.City, addressEntity.PostalCode, supermarketId)
            };

            return new SupermarketDto(supermarketEntity.Id, supermarketEntity.Name, addressDtos);


        }

        public async Task<SupermarketDto> AddAddressToSupermarket(Guid supermarketId, CreateAddressDto address)
        {
            var supermarket = await _supermarketRepository.GetSupermarketBy(supermarketId);

            var addressId = Guid.NewGuid();
            var addressAggregate = new AddressAggregate(addressId, address.Street, address.City,
                address.PostalCode, supermarket.Id);

            await _supermarketRepository.AddAddressToSupermarket(addressAggregate);

            List<AddressDto> addressDtos = new();
            foreach (var supermarketAddress in supermarket.Addresses)
            {
                var addressDto = new AddressDto(supermarketAddress.Id, supermarketAddress.Street,
                    supermarketAddress.City, supermarketAddress.PostalCode, supermarketAddress.SupermarketId);
                addressDtos.Add(addressDto);
            }
            
            addressDtos.Add(new AddressDto(addressId, address.Street,address.City, address.PostalCode, supermarketId));

            var supermarketDto = new SupermarketDto(supermarket.Id, supermarket.Name, addressDtos);
            return supermarketDto;
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
