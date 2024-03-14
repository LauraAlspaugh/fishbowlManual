namespace fishbowlManual.Services;
public class PartsService
{
    private readonly PartsRepository _partsRepository;

    public PartsService(PartsRepository partsRepository)
    {
        _partsRepository = partsRepository;
    }
}