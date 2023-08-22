namespace Shoppinglist.Domains.Supermarket.Domain.Aggregate;

public class SupermarketAggregate
{
    public Guid Id { get; init; }
    public string Name { get; private set; } = string.Empty;
    public List<AddressAggregate> Addresses { get; init; } = new List<AddressAggregate>();

    public SupermarketAggregate()
    {
        
    }

    public SupermarketAggregate(Guid id, string name, List<AddressAggregate> addresses)
    {
        Id = id;
        Name = name;
        Addresses = addresses;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}