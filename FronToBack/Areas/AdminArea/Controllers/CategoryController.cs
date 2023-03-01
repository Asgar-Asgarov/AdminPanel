using Microsoft.AspNetCore.Mvc;
using FronToBack.DAL;
using FronToBack.Models;

namespace FronToBack.Areas.AdminArea.Controllers;

[Area("AdminArea")]
public class CategoryController : Controller
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
        if (id == null) return NotFound();
        Category category = _appDbCOntext.Categories.SingleOrDefault(c => c.Id == id);
        if (id == null) return NotFound();
        return View(category);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        List<Category> categories = _appDbCOntext.Categories.ToList();
        foreach (var item in categories)
        {
            if (category.Name==item.Name)
            {
                var dumbcode=1;
            }
            else
            {
              _appDbCOntext.Categories.Add(category);
              break;
            }
        }
        _appDbCOntext.SaveChanges();

        return RedirectToAction("Index");
    }
}