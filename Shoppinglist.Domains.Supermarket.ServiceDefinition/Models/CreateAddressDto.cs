namespace Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

public class CreateAddressDto
{
    public string Street { get; init; }
    public string City { get; init; }
    public string PostalCode { get; init; }

    public CreateAddressDto(string street, string city, string postalCode)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }
}