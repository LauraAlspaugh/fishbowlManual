namespace fishbowlManual.Repositories;
public class PartsRepository
{
    private readonly IDbConnection _db;

    public PartsRepository(IDbConnection db)
    {
        _db = db;
    }
}