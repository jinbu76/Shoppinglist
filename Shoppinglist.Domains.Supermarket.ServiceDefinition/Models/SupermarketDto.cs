namespace Shoppinglist.Domains.Supermarket.ServiceDefinition.Models
{
    public class SupermarketDto
    {
        public Guid? Id { get; init; }
        public string Name { get; init; }
        public List<AddressDto> Addresses { get; init; }

        public SupermarketDto(Guid? id, string name, List<AddressDto> addresses)
        {
            Id = id;
            Name = name;
            Addresses = addresses;
        }
    }
}
