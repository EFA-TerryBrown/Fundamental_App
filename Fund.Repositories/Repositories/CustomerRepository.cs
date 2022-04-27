using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class CustomerRepository : BaseRepo
{
    private readonly List<Customer> _customerDB = new List<Customer>();
    private int _customerCount = 0;
    //todo Making an overload of the Method above:
    public bool AddToDatabase(ICustomer customer)
    {
        if (customer != null)
        {
            _customerCount++;
            customer.ID = _customerCount;
            _customerDB.Add((Customer)customer);
            return true;
        }
        return true;
    }
    //?Read
    public Customer GetCustomer(int id)
    {
        if (id < 1)
            return null;

        foreach (var customer in _customerDB)
        {
            if (customer.ID == id)
            {
                return customer;
            }
        }
        return null;
    }

    //? Read 
    public List<Customer> GetCustomers()
    {
        return _customerDB;
    }

    //? Update
    public bool UpdateCustomer(int id, Customer newCustomerData)
    {
        var customer = GetCustomer(id);
        if (customer != null)
        {
            customer.Name = newCustomerData.Name;
            customer.Orders = newCustomerData.Orders;
            return true;
        }
        return false;
    }
}
