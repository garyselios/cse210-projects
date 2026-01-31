
public class Product
{
    // Private attributes (member variables)
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate total cost of this product
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    // Method to get product information for packing label
    public string GetProductInfo()
    {
        return $"{_name} (ID: {_productId})";
    }

    // Getters for encapsulation
    public string GetName() { return _name; }
    public string GetProductId() { return _productId; }
    public decimal GetPrice() { return _price; }
    public int GetQuantity() { return _quantity; }
}