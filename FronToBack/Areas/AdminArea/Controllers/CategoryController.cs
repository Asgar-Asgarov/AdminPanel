using Microsoft.AspNetCore.Mvc;

namespace FronToBack.Areas.AdminArea.Controllers;

[Area("AdminArea")]
public class CategoryController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
}