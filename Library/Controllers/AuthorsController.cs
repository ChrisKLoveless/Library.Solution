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
  public class AuthorsController : Controller
  {
    private readonly LibraryContext _db;

    public AuthorsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Author> authors = _db.Authors.ToList();
      return View(authors);
    }

  [Authorize(Roles = "admin")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Author author)
    {
      if (!ModelState.IsValid)
      {
        return View(author);
      }
      else
      {
        _db.Authors.Add(author);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Author thisAuthor = _db.Authors
      .Include(author => author.JoinEntities)
      .ThenInclude(join => join.Title)
      .FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }

    public ActionResult Edit(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }

    [HttpPost]
    public ActionResult Edit(Author author)
    {
      _db.Authors.Update(author);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      return View(thisAuthor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirm(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
      _db.Authors.Remove(thisAuthor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTitle(int id)
    {
      Author thisAuthor = _db.Authors.FirstOrDefault(authors => authors.AuthorId == id);
      ViewBag.TitleId = new SelectList(_db.Titles, "TitleId", "Name");
      return View(thisAuthor);
    }

    [HttpPost]
    public ActionResult AddTitle(Author author, int titleId)
    {
        #nullable enable
      AuthorTitle? joinEntity = _db.AuthorTitles.FirstOrDefault(join => (join.TitleId == titleId && join.AuthorId == author.AuthorId));
      #nullable disable
      if (joinEntity == null && titleId != 0)
      {
        _db.AuthorTitles.Add(new AuthorTitle() { TitleId = titleId, AuthorId = author.AuthorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = author.AuthorId });
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
