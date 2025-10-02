using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Controllers;

public class TestController : Controller
{
    [HttpGet("api/items")]
    public IActionResult GetItems()
    {
        var items = new List<string> { "Item 1", "Item 2", "Item 3" };
        return Json(items);
    }    
}