namespace fishbowlManual.Models;
public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Description { get; set; }
    public Account Creator { get; set; }
    public string CreatorId { get; set; }
}