namespace BaikalNews.Domain.Models;

public class Comment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Text { get; set; }

    public Article? Article { get; set; } = new Article();
}