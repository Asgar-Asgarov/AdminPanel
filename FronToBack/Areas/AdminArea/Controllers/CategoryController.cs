using Microsoft.AspNetCore.Mvc;
using FronToBack.DAL;
namespace FronToBack.Areas.AdminArea.Controllers;

[Area("AdminArea")]
public class CategoryController:Controller
{
    private readonly AppDbContext _appDbCOntext;

    public CategoryController(AppDbContext appDbCOntext)
    {
        _appDbCOntext = appDbCOntext;
    }

    public IActionResult Index()
    {
        return View(_appDbCOntext.Categories.ToList());
    }
}