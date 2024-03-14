namespace fishbowlManual.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PartsController : ControllerBase
{
    private readonly PartsService _partsService;
    private readonly Auth0Provider _auth0Provider;

    public PartsController(PartsService partsService, Auth0Provider auth0Provider)
    {
        _partsService = partsService;
        _auth0Provider = auth0Provider;
    }
    [HttpPost]
    public async Task<ActionResult<Part>> CreatePart([FromBody] Part partData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            partData.CreatorId = userInfo.Id;
            Part part = _partsService.CreatePart(partData);
            return Ok(part);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}