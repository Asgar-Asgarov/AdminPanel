using Microsoft.AspNetCore.Mvc;
using FronToBack.DAL;
using FronToBack.Models;
using FronToBack.ViewModel;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult Create(CategoryCreateVM category)
    {
      if(!ModelState.IsValid) return View();
      bool isExist=_appDbCOntext.Category.Any(c=>c.Name.ToLower()==category.Name.ToLower());
      if(isExist)
        {
            ModelState.AddModelError("Name","Bu adli category yoxdur");
            return View();
        }
          
      Category newCategory = new();
      {
        Name= category.Name;
        Description=category.Description;
      }
        _appDbCOntext.Categories.Add(newCategory);
         _appDbCOntext.SaveChanges();

        return RedirectToAction("Index");
    }
}