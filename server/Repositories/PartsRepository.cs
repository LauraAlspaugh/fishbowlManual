



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

    internal void DestroyPart(int partId)
    {
        string sql = "DELETE FROM parts WHERE id = @partId LIMIT 1;";
        _db.Execute(sql, new { partId });
    }

    internal Part EditPart(Part part)
    {
        string sql = @"
    UPDATE parts
    SET 
    
description = @Description, 
partNumber = @PartNumber,
partDescription = @PartDescription,
quantity = @Quantity
WHERE id = @Id;

SELECT par.*,
    acc.*
    FROM parts par
    JOIN accounts acc ON par.creatorId = acc.id
    Where par.id = @Id;
    ";
        Part newPart = _db.Query<Part, Account, Part>(sql, (part, account) =>
    {
        part.Creator = account;
        return part;
    }, part).FirstOrDefault();
        return newPart;
    }

    internal Part GetPartById(int partId)
    {
        string sql = @"
SELECT 
    par.*, 
    acc.*
    FROM parts par
    JOIN accounts acc ON acc.id = par.creatorId
    WHERE par.id = @partId;
";
        Part part = _db.Query<Part, Account, Part>(sql, (part, account) =>
        {
            part.Creator = account;
            return part;
        }, new { partId }).FirstOrDefault();
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