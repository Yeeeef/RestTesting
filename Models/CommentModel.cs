namespace RestTesting.Models;

public class CommentModel
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreationTime { get; set;} = DateTime.Now.Date;
    public int? StockId { get; set; }
}
