namespace fishbowlManual.Models;
public class Part
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Description { get; set; }
    public string PartNumber { get; set; }
    public string PartDescription { get; set; }
    public int? Quantity { get; set; }
    public string UOM { get; set; }
    public int OrderId { get; set; }
    public Account Creator { get; set; }
    public string CreatorId { get; set; }
}