namespace Shoppinglist.Domains.Supermarket.ServiceDefinition.Models;

public class CreateSupermarketDto
{
    public string Name { get; init; }
    public CreateAddressDto Address { get; init; }

    public CreateSupermarketDto(string name, CreateAddressDto address)
    {
        Name = name;
        Address = address;
    }
}