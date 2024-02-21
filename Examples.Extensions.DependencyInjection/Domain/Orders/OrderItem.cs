namespace Examples.Extensions.DependencyInjection.Domain.Orders;

/// <summary>
/// sample order item.
/// </summary>
public class OrderItem
{
    /// <summary>
    /// id of the order item.
    /// </summary>
    public int OrderItemId { get; set; }

    /// <summary>
    /// inventory item id.
    /// </summary>
    public int InventoryItemId { get; set; }

    /// <summary>
    /// number of ordered units.
    /// </summary>
    public decimal Units { get; set; }

    /// <summary>
    /// price per unit at time of the order.
    /// </summary>
    public decimal PricePerUnit { get; set; }

    /// <summary>
    /// tax status at the time of order.
    /// </summary>
    public bool IsTaxable { get; set; }

    /// <summary>
    /// date added to the order.
    /// </summary>
    public DateTime AddedOn { get; set; }

    /// <summary>
    /// date item was shipped.
    /// </summary>
    public DateTime? ShippedOn { get; set; }
}