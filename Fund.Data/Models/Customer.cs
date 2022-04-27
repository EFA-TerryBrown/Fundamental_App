using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Customer : ICustomer
{
    public Customer() { }

    public Customer(string name, List<Order> orders)
    {
        Name = name;
        Orders = orders;
    }
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
}