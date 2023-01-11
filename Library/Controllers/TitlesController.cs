using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  [Authorize(Roles = "admin, user")]
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

    [Authorize(Roles = "admin")]
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
      Title thisTitle = _db.Titles
      .Include(title => title.JoinEntities)
      .ThenInclude(join => join.Author)
      .FirstOrDefault(titles => titles.TitleId == id);
      return View(thisTitle);
    }

    public ActionResult Edit(int id)
    {
      Title thisTitle = _db.Titles.FirstOrDefault(title => title.TitleId == id);
      return View(thisTitle);
    }

    [HttpPost]
    public ActionResult Edit(Title title)
    {
      _db.Titles.Update(title);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
        public ActionResult Delete(int id)
    {
      Title thisTitle = _db.Titles.FirstOrDefault(titles => titles.TitleId == id);
      return View(thisTitle);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Title thisTitle = _db.Titles.FirstOrDefault(title => title.TitleId == id);
      _db.Titles.Remove(thisTitle);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddAuthor(int id)
    {
      Title thisTitle = _db.Titles.FirstOrDefault(titles => titles.TitleId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
      return View(thisTitle);
    }

    [HttpPost]
    public ActionResult AddAuthor(Title title, int authorId)
    {
        #nullable enable
      AuthorTitle? joinEntity = _db.AuthorTitles.FirstOrDefault(join => (join.AuthorId == authorId && join.TitleId == title.TitleId));
      #nullable disable
      if (joinEntity == null && authorId != 0)
      {
        _db.AuthorTitles.Add(new AuthorTitle() { AuthorId = authorId, TitleId = title.TitleId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = title.TitleId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      AuthorTitle joinEntry = _db.AuthorTitles.FirstOrDefault(entry => entry.AuthorTitleId == joinId);
      _db.AuthorTitles.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
  }
}