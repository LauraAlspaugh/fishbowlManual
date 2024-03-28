namespace fishbowlManual.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrdersService _ordersService;
    private readonly Auth0Provider _auth0Provider;
    private readonly PartsService _partsService;

    public OrdersController(OrdersService ordersService, Auth0Provider auth0Provider, PartsService partsService)
    {
        _ordersService = ordersService;
        _auth0Provider = auth0Provider;
        _partsService = partsService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] Order orderData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            orderData.CreatorId = userInfo.Id;
            Order order = _ordersService.CreateOrder(orderData);
            return Ok(order);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }

    [HttpGet("{orderId}")]
    public ActionResult<Order> GetOrderById(int orderId)
    {
        try
        {
            Order order = _ordersService.GetOrderById(orderId);
            return Ok(order);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet]
    public ActionResult<List<Order>> GetOrders()
    {
        try
        {
            List<Order> orders = _ordersService.GetOrders();
            return Ok(orders);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{orderId}/parts")]
    public ActionResult<List<Part>> GetPartsByOrderId(int orderId)
    {
        try
        {
            List<Part> parts = _partsService.GetPartsByOrderId(orderId);
            return Ok(parts);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpDelete("{orderId}")]
    public async Task<ActionResult<string>> DestroyOrder(int orderId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _ordersService.DestroyOrder(orderId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpPut("{orderId}")]
    public async Task<ActionResult<Order>> EditOrder(int orderId, [FromBody] Order orderData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            Order order = _ordersService.EditOrder(orderId, orderData, userId);
            return Ok(order);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}