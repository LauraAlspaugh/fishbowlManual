

namespace fishbowlManual.Services;
public class OrdersService
{
    private readonly OrdersRepository _ordersRepository;

    public OrdersService(OrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    internal Order CreateOrder(Order orderData)
    {
        Order order = _ordersRepository.CreateOrder(orderData);
        return order;
    }

    internal List<Order> GetOrders()
    {
        List<Order> orders = _ordersRepository.GetOrders();
        return orders;
    }
}