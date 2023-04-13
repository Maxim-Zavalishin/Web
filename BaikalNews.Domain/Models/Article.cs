namespace BaikalNews.Domain.Models;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime PublicDate { get; set; }

    public Worker? Worker { get; set; } = new Worker();
    public List<Category>? Categories { get; set; } = new List<Category>();
    public List<Comment>? Comments { get; set; } = new List<Comment>();
}