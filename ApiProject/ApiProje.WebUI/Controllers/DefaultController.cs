using Microsoft.AspNetCore.Mvc;

namespace ApiProje.WebUI.Controllers;

public class DefaultController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
}