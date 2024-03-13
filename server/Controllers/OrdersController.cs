namespace fishbowlManual.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrdersService _ordersService;
    private readonly Auth0Provider _auth0Provider;

    public OrdersController(OrdersService ordersService, Auth0Provider auth0Provider)
    {
        _ordersService = ordersService;
        _auth0Provider = auth0Provider;
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
}