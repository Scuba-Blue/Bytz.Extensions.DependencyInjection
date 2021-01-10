using System;
using System.Collections.Generic;

namespace Samples.Extensions.DependencyInjection.Domain.Customers
{
    /// <summary>
    /// sample customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// id of the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// customer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// customer's middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// customer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// optional birthdate for the customer.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// gender of the customer.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// cutomer's addresses.
        /// </summary>
        public IList<Address> AddressItems { get; set; } = new List<Address>();

        //
        public static IList<Customer> Samples =>
            new List<Customer>
            {
                new Customer { CustomerId = 1, FirstName = "Charlie", LastName = "Brown"},
                new Customer { CustomerId = 2, FirstName = "Bugs", LastName = "Bunny"},
                new Customer { CustomerId = 3, FirstName = "Fred", LastName = "Flintstone"},
                new Customer { CustomerId = 4, FirstName = "Grape", LastName = "Ape"},
                new Customer { CustomerId = 5, FirstName = "Mr.", LastName = "McGoo"}
            };
    }
}