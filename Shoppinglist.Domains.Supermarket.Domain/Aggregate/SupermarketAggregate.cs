namespace Shoppinglist.Domains.Supermarket.Domain.Aggregate;

public class SupermarketAggregate
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public List<AddressAggregate> Addresses { get; init; }

    public SupermarketAggregate()
    {
        
    }

    public SupermarketAggregate(Guid id, string name, List<AddressAggregate> addresses)
    {
        Id = id;
        Name = name;
        Addresses = addresses;
    }
}