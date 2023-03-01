using Microsoft.AspNetCore.Mvc;
using FronToBack.DAL;
using FronToBack.Models;

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

    public IActionResult Detail(int id)
    {
        if (id==null) return NotFound();
        Category category = _appDbCOntext.Categories.SingleOrDefault(c=>c.Id==id);
         if (id==null) return NotFound();
        return View(category);
    }
}