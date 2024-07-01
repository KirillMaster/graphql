using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsMicroservice;

public class CustomersContext
{
    [Table("customers", Schema = "public")]
    public class Customer
    {
        public int Id { get; set; }
        public CustomerDetails Details { get; set; }
    }

    public class CustomerDetails    // Map to a JSON column in the table
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order       // Part of the JSON column
    {
        public decimal Price { get; set; }
        public string ShippingAddress { get; set; }
        public List<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}