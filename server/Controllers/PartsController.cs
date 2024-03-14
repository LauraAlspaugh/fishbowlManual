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
}