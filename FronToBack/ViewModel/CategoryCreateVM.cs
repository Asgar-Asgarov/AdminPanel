using System.ComponentModel.DataAnnotations;
using FronToBack.Models;
namespace FronToBack.ViewModel;


public class CategoryCreateVM
{
     [Required,MaxLength(50)]
    public string Name { get; set; }
    [Required,MinLength(5)]
    public string Description { get; set; }
}