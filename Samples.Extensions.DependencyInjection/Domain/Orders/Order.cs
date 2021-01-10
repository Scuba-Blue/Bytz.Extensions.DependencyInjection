using System;
using System.Collections.Generic;

namespace Samples.Extensions.DependencyInjection.Domain.Orders
{
    /// <summary>
    /// sample order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// id of the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// customer for the order.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// date of the order.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// items in the order.
        /// </summary>
        public IList<Order> OrderItems { get; set; } = new List<Order>();
    }
}