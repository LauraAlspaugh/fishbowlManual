


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
    internal Part GetPartById(int partId)
    {
        Part part = _partsRepository.GetPartById(partId);
        if (part == null)
        {
            throw new Exception("not a valid part id!");
        }
        return part;
    }

    internal string DestroyPart(int partId, string userId)
    {
        Part part = GetPartById(partId);
        if (part.CreatorId != userId)
        {
            throw new Exception("do not try it");
        }
        _partsRepository.DestroyPart(partId);
        return "it really is gone";
    }

    internal List<Part> GetPartsByOrderId(int orderId)
    {
        List<Part> parts = _partsRepository.GetPartsByOrderId(orderId);
        return parts;
    }

    internal Part EditPart(int partId, Part partData, string userId)
    {
        Part part = GetPartById(partId);
        if (part.CreatorId != userId)
        {
            throw new Exception("not your part to edit!");
        }
        part.Description = partData.Description ?? part.Description;
        part.PartNumber = partData.PartNumber ?? part.PartNumber;
        part.PartDescription = partData.PartDescription ?? part.PartDescription;
        part.Quantity = partData.Quantity ?? part.Quantity;
        _partsRepository.EditPart(part);
        return part;
    }
}