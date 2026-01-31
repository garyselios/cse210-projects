
using System;
using System.Collections.Generic;

public class Order
{
    // Private attributes (member variables)
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate total cost including shipping
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;

        // Add cost of all products
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost
        decimal shippingCost = _customer.IsInUSA() ? 5 : 35;
        totalCost += shippingCost;

        return totalCost;
    }

    // Method to get packing label
    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";
        label += "========================\n";

        foreach (Product product in _products)
        {
            label += $"- {product.GetProductInfo()}\n";
        }

        return label;
    }

    // Method to get shipping label
    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL:\n";
        label += "========================\n";
        label += $"To: {_customer.GetCustomerInfo()}\n";
        label += $"Address:\n{_customer.GetShippingAddress()}";

        return label;
    }

    // Method to get order summary
    public string GetOrderSummary()
    {
        string summary = $"ORDER SUMMARY:\n";
        summary += $"Customer: {_customer.GetCustomerInfo()}\n";
        summary += $"Total Items: {_products.Count}\n";
        summary += $"Shipping to USA: {(_customer.IsInUSA() ? "Yes" : "No")}\n";
        summary += $"Total Cost: ${CalculateTotalCost():F2}\n";
        summary += $"  - Products: ${CalculateProductTotal():F2}\n";
        summary += $"  - Shipping: ${(_customer.IsInUSA() ? "5.00" : "35.00")}\n";

        return summary;
    }

    // Helper method to calculate just product total
    private decimal CalculateProductTotal()
    {
        decimal productTotal = 0;
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }
        return productTotal;
    }
}