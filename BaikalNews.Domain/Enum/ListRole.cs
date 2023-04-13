using System.ComponentModel.DataAnnotations;

namespace BaikalNews.Domain.Enum;

public enum ListRole
{
    [Display(Name = "Модератор")]
    Moderator = 1,
    [Display(Name = "Администратор")]
    Admin = 2,
    [Display(Name = "Главный администратор")]
    SuperAdmin = 3
}