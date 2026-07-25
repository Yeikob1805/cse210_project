public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
            total += product.GetTotalCost();

        total += _customer.LivesInUSA() ? 5 : 35;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";

        foreach (Product product in _products)
            label += $"{product.GetName()} ({product.GetProductId()})\n";

        return label;
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetDisplayAddress()}";
    }
}