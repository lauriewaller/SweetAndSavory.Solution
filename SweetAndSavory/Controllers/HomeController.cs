using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SweetAndSavory.Models;

namespace SweetAndSavory.Controllers
{
  public class HomeController : Controller
  {
    private readonly SweetAndSavoryContext _db;

    public HomeController(SweetAndSavoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Flavor> flavorModel = _db.Flavors.ToList();
      List<Treat> treatList = _db.Treats.ToList();
      ViewBag.TreatModel = treatList;
      return View(flavorModel);
    }

  }
}
