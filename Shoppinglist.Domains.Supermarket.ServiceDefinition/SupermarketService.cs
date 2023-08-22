using System.Net;
using Mapster;
using MapsterMapper;
using Shoppinglist.Domains.Supermarket.Domain;
using Shoppinglist.Domains.Supermarket.Domain.Aggregate;
using Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

namespace Shoppinglist.Domains.Supermarket.ServiceDefinition
{
    public class SupermarketService : ISupermarketService
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

            return supermarketEntity.Adapt<SupermarketDto>();
        }

        public async Task<AddressDto> AddAddressToSupermarket(Guid supermarketId, CreateAddressDto address)
        {
            var addressAggregate = new AddressAggregate(Guid.NewGuid(), address.Street, address.City,
                address.PostalCode, supermarketId);

            await _supermarketRepository.AddAddressToSupermarket(addressAggregate);

            return addressAggregate.Adapt<AddressDto>();
        }

        public async Task<List<SupermarketDto>> GetAllSupermarket()
        {
            var supermarkets = await _supermarketRepository.GetAllSupermarket();
            return supermarkets.Adapt<List<SupermarketDto>>();
        }


        public async Task EditSupermarket(Guid supermarketId, string name)
        {
            var entity = await _supermarketRepository.GetSupermarketBy(supermarketId) ??
                         throw new HttpRequestException($"Supermarket with the {supermarketId} was not found.", null,
                             HttpStatusCode.NotFound);
            entity.SetName(name);
            await _supermarketRepository.UpdateSupermarket(entity);
        }

        public async Task EditAddress(AddressDto address)
        {
            if (!address.Id.HasValue)
                throw new HttpRequestException($"No address id found.", null, HttpStatusCode.BadRequest);
            var addressEntity = await _supermarketRepository.GetAddressBy(address.Id.Value) ??
                                throw new HttpRequestException($"Address with the {address.Id} was not found.", null,
                                    HttpStatusCode.NotFound);
            addressEntity.SetCity(address.City);
            addressEntity.SetPostalCode(address.PostalCode);
            addressEntity.SetStreet(address.Street);
            await _supermarketRepository.UpdateAddress(addressEntity);
        }

        public async Task DeleteSupermarket(Guid supermarketId)
        {
            await _supermarketRepository.DeleteSupermarket(supermarketId);
        }

        public async Task DeleteAddress(Guid addressId)
        {
            await _supermarketRepository.DeleteAddress(addressId);
        }
    }
}