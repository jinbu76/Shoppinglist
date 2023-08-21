namespace Shoppinglist.Domains.Supermarket.ServiceDefinition.Models
{
    public class AddressDto
    {
        public Guid? Id { get; init; }
        public string Street { get; init; }
        public string City { get; init; }
        public string PostalCode { get; init; }
        public Guid? SupermarketId { get; set; }

        public AddressDto(Guid? id, string street, string city, string postalCode, Guid? supermarketId)
        {
            Id = id;
            Street = street;
            City = city;
            PostalCode = postalCode;
            SupermarketId = supermarketId;
        }
    }
}
