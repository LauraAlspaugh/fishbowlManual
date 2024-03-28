




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

    internal void DestroyOrder(int orderId, string userId)
    {
        string sql = "DELETE FROM orders WHERE id = @orderId LIMIT 1;";
        _db.Execute(sql, new { orderId });
    }

    internal Order EditOrder(Order order)
    {
        string sql = @"
    UPDATE orders
    SET 
    
description = @Description
WHERE id = @Id;

SELECT ord.*,
    acc.*
    FROM orders ord
    JOIN accounts acc ON ord.creatorId = acc.id
    Where ord.id = @Id;
    ";
        Order newOrder = _db.Query<Order, Account, Order>(sql, (order, account) =>
    {
        order.Creator = account;
        return order;
    }, order).FirstOrDefault();
        return newOrder;
    }

    internal Order GetOrderById(int orderId)
    {

        string sql = @"
       SELECT 
       ord.*,
       acc.*
       FROM orders ord
       JOIN accounts acc ON ord.creatorId = acc.id
       WHERE ord.id = @orderId;
       ";
        Order order = _db.Query<Order, Account, Order>(sql, (order, account) =>
        {
            order.Creator = account;
            return order;
        }, new { orderId }).FirstOrDefault();
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