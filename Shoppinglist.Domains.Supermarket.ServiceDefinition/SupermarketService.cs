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

        public async Task<List<SupermarketDto>> GetAllSupermarket()
        {
            var supermarkets = await _supermarketRepository.GetAllSupermarket();

            var supermarketDtos = new List<SupermarketDto>();
            foreach (var supermarket in supermarkets)
            {
                var addressDtos = supermarket.Addresses.Select(address => new AddressDto(address.Id, address.Street, address.City, address.PostalCode, address.SupermarketId)).ToList();

                var supermarketDto = new SupermarketDto(supermarket.Id, supermarket.Name, addressDtos);
                supermarketDtos.Add(supermarketDto);
            }

            return supermarketDtos;
        }


        public async Task EditSupermarket(Guid supermarketId, string name)
        {
            var entity = await _supermarketRepository.GetSupermarketBy(supermarketId);
            if (entity == null)
                throw new HttpRequestException($"Supermarket with the {supermarketId} was not found.");

            entity.SetName(name);
            await _supermarketRepository.UpdateSupermarket(entity);
        }

        public async Task EditAddress(AddressDto address)
        {
            var addressEntity = await _supermarketRepository.GetAddressBy(address.Id!.Value);
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
