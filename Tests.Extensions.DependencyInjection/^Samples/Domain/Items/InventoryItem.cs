namespace Tests.Extensions.DependencyInjection.Samples.Domain.Items
{
    /// <summary>
    /// sample inventory item.
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// id of the inventory item.
        /// </summary>
        public int InventoryItemId { get; set; } 

        /// <summary>
        /// item description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// current price of the item.
        /// </summary>
        public decimal CurrentPrice { get; set; }

        /// <summary>
        /// taxable status of the item.
        /// </summary>
        public bool IsTaxable { get; set; }
    }
}