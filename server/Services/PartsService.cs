

namespace fishbowlManual.Services;
public class PartsService
{
    private readonly PartsRepository _partsRepository;

    public PartsService(PartsRepository partsRepository)
    {
        _partsRepository = partsRepository;
    }

    internal Part CreatePart(Part partData)
    {
        Part part = _partsRepository.CreatePart(partData);
        return part;
    }

    internal List<Part> GetPartsByOrderId(int orderId)
    {
        List<Part> parts = _partsRepository.GetPartsByOrderId(orderId);
        return parts;
    }
}