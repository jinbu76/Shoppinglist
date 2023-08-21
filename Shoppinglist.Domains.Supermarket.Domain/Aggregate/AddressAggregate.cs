namespace Shoppinglist.Domains.Supermarket.Domain.Aggregate;

public class AddressAggregate
{
    public Guid Id { get; init; }
    public string Street { get; init; }
    public string City { get; init; }
    public string PostalCode { get; init; }

    public SupermarketAggregate Supermarket { get; init; }
    public Guid SupermarketId { get; init; }

    public AddressAggregate()
    {
        
    }

    public AddressAggregate(Guid id, string street, string city, string postalCode, Guid supermarketId)
    {
        Id = id;
        Street = street;
        City = city;
        PostalCode = postalCode;
        SupermarketId = supermarketId;
    }
}