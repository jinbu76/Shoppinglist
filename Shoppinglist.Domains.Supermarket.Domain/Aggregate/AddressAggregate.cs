namespace Shoppinglist.Domains.Supermarket.Domain.Aggregate;

public class AddressAggregate
{
    public Guid Id { get; init; }
    public string Street { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string PostalCode { get; private set; } = string.Empty;

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

    public void SetStreet(string street)
    {
        Street = street;
    }

    public void SetCity(string city)
    {
        City = city;
    }

    public void SetPostalCode(string postalCode)
    {
        PostalCode = postalCode;
    }
}