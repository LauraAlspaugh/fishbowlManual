

namespace fishbowlManual.Repositories;
public class OrdersRepository
{
    private readonly IDbConnection _db;

    public OrdersRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Order CreateOrder(Order orderData)
    {
        string sql = @"
    INSERT INTO 
    orders(description, creatorId)
    VALUES(@Description, @CreatorId);
    SELECT 
    ord.*,
    acc.*
    FROM orders ord 
    JOIN accounts acc ON ord.creatorId = acc.id
    WHERE ord.id = LAST_INSERT_ID();
";
        Order order = _db.Query<Order, Account, Order>(sql, (order, account) =>
        {
            order.Creator = account;
            return order;
        }, orderData).FirstOrDefault();
        return order;
    }

    internal List<Order> GetOrders()
    {
        string sql = @"
    SELECT 
    ord.*,
    acc.*
    FROM orders ord
    JOIN accounts acc ON ord.creatorId = acc.id
    ";
        List<Order> orders = _db.Query<Order, Account, Order>(sql, (order, account) =>
        {
            order.Creator = account;
            return order;
        }).ToList();
        return orders;
    }
}