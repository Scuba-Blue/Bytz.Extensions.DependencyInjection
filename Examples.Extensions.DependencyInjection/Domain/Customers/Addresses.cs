namespace Examples.Extensions.DependencyInjection.Domain.Customers;

/// <summary>
/// sample address item.
/// </summary>
public class Address
{
    /// <summary>
    /// id of the address.
    /// </summary>
    public int AddressId { get; set; }

    /// <summary>
    /// address line 1.
    /// </summary>
    public string Line1 { get; set; }

    /// <summary>
    /// address line 2.
    /// </summary>
    public string Line2 { get; set; }

    /// <summary>
    /// address' city.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// address' state.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// address' postal code.
    /// </summary>
    public string PostalCode { get; set; }
}