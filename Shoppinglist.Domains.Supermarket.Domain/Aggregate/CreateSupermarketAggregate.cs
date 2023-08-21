namespace Shoppinglist.Domains.Supermarket.Domain.Aggregate;

public class CreateSupermarketAggregate
{
    public string Name { get; init; }
    public CreateAddressAggregate Address { get; init; }

    public CreateSupermarketAggregate(string name, CreateAddressAggregate address)
    {
        Name = name;
        Address = address;
    }
}