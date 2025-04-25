using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DOs.Models;
using System.Xml.Schema;

namespace DOs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DOBContext _context;

    public HomeController(ILogger<HomeController> logger, DOBContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<DO> DOs = _context.DOs.ToList();
        IndexViewModel vm = new IndexViewModel(DOs);
        Console.WriteLine(vm._DOs[0].Title);
        return View(vm);
    }

    public IActionResult DO(int Id)
    {
        DO DOItem = _context.DOs.Find(Id);
        if (DOItem is null)
        {
            return NotFound();
        }
        DOItem.Done = !DOItem.Done;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int Id)
    {
        DO dO = _context.DOs.Find(Id);
        if (dO is null)
        {
            return NotFound();
        }
        return View(dO);
    }

    [HttpPost]
    public IActionResult Update(DO dO)
    {
        DO DbDo = _context.DOs.Find(dO.Id);
        if (DbDo is null)
        {
            return NotFound();
        }

        DbDo.Description = dO.Description;
        DbDo.Done = dO.Done;
        DbDo.DueDate = dO.DueDate;
        DbDo.Title = dO.Title;
        
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(DO Do)
    {
        if (!ModelState.IsValid)
        {
            return View(Do);
        } else
        {
            _context.Add(Do);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public IActionResult Delete(int Id)
    {
        DO? Do = _context.DOs.Find(Id);
        if (Do is null)
        {
            return NotFound();
        }
        _context.DOs.Remove(Do);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
