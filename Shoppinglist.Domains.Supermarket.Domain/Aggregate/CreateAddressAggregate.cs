namespace Shoppinglist.Domains.Supermarket.Domain.Aggregate;

public class CreateAddressAggregate
{
    public string Street { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
    public string PostalCode { get; init; }

    public CreateAddressAggregate(string street, string city, string country, string postalCode)
    {
        Street = street;
        City = city;
        Country = country;
        PostalCode = postalCode;
    }
}