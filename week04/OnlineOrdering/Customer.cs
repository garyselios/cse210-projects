
public class Customer
{
    // Private attributes (member variables)
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to check if customer is in USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Method to get customer information
    public string GetCustomerInfo()
    {
        return _name;
    }

    // Method to get customer address (for shipping label)
    public string GetShippingAddress()
    {
        return _address.GetFullAddress();
    }

    // Getters for encapsulation
    public string GetName() { return _name; }
    public Address GetAddress() { return _address; }
}