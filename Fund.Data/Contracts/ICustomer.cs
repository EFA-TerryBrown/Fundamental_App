using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface ICustomer : IIdentifiable
{
    string Name { get; set; }
    List<Order> Orders { get; set; }
}
