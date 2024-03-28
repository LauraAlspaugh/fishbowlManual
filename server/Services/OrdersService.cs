


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

    internal string DestroyOrder(int orderId, string userId)
    {
        Order order = GetOrderById(orderId);
        if (order.CreatorId != userId)
        {
            throw new Exception("do not try it");
        }
        _ordersRepository.DestroyOrder(orderId, userId);
        return "it really is gone";
    }

    internal Order GetOrderById(int orderId)
    {
        Order order = _ordersRepository.GetOrderById(orderId);
        if (order == null)
        {
            throw new Exception("not a valid id");
        }
        return order;
    }


    internal List<Order> GetOrders()
    {
        List<Order> orders = _ordersRepository.GetOrders();
        return orders;
    }
}