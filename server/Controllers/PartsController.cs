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
    [Authorize]
    [HttpDelete("{partId}")]
    public async Task<ActionResult<string>> DestroyPart(int partId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _partsService.DestroyPart(partId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpPut("{partId}")]
    public async Task<ActionResult<Part>> EditPart(int partId, [FromBody] Part partData)

    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            Part part = _partsService.EditPart(partId, partData, userId);
            return Ok(part);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}