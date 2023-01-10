using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Controllers
{
  public class TitlesController : Controller
  {
    private readonly LibraryContext _db;

    public TitlesController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Title> titles = _db.Titles.ToList();
      return View(titles);
    }

    public ActionResult Create()
    {
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Title titles)
    {
      if (!ModelState.IsValid)
      {
        return View(titles);
      }
      else
      {
        _db.Titles.Add(titles);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Title thisTitle = _db.Titles.FirstOrDefault(titles => titles.TitleId == id);
      return View(thisTitle);
    }
  }
}