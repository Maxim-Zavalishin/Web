using System.ComponentModel.DataAnnotations;
using BaikalNews.Domain.Enum;

namespace BaikalNews.Domain.Models;

public class Worker
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите имя")]
    [Display(Name="Имя")]
    public string Name { get; set; }

    [Display(Name="Фамилия")]
    public string? Lastname { get; set; }

    [Required(ErrorMessage = "Введите почту")]
    [UIHint("EmailAdress")]
    [EmailAddress(ErrorMessage = "Вы ввели некоректную почту")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Введите пароль")]
    [MinLength(4)]
    [Display(Name="Пароль")]
    [UIHint("Password")]
    public string Password { get; set; }

    [Required]
    [Display(Name="Дата регистрации")]
    public DateTime DateCreated { get; set; }

    [Required(ErrorMessage = "Выберите роль")]
    [Display(Name="Роль")]
    public ListRole IdRole { get; set; }

    [Display(Name = "Список публикаций")] 
    public List<Article>? ListPublic { get; set; } = new List<Article>();
}

