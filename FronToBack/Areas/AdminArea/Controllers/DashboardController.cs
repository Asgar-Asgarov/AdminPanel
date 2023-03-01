using Microsoft.AspNetCore.Mvc;

namespace FronToBack.Areas.AdminArea.Controllers;

[Area("AdminArea")]
public class DashBoardController:Controller
{
    public IActionResult Index()
    {
        return Content("Admin Dashboard");
    }
}