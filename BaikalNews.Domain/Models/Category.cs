using System.ComponentModel.DataAnnotations;

namespace BaikalNews.Domain.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Article>? Articles { get; set; } = new List<Article>();
}