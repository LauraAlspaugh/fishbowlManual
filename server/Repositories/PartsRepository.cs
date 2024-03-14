

namespace fishbowlManual.Repositories;
public class PartsRepository
{
    private readonly IDbConnection _db;

    public PartsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Part CreatePart(Part partData)
    {
        string sql = @"
    INSERT INTO 
    parts(description, partNumber, partDescription, Quantity, UOM, orderId, creatorId)
    VALUES(@Description, @PartNumber, @PartDescription, @Quantity, @UOM, @OrderId, @CreatorId);
    SELECT 
    par.*,
    acc.*
    FROM parts par
    JOIN accounts acc ON par.creatorId = acc.id
    WHERE par.id = LAST_INSERT_ID();
";
        Part part = _db.Query<Part, Account, Part>(sql, (part, account) =>
        {
            part.Creator = account;
            return part;
        }, partData).FirstOrDefault();
        return part;
    }

    internal List<Part> GetPartsByOrderId(int orderId)
    {
        string sql = @"
    SELECT 
    par.*, 
    acc.*
    FROM parts par
    JOIN accounts acc ON acc.id = par.creatorId
    WHERE par.orderId = @orderId;
    ";
        List<Part> parts = _db.Query<Part, Account, Part>(sql, (part, account) =>
        {
            part.Creator = account;
            return part;
        }, new { orderId }).ToList();
        return parts;
    }
}