using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CasaDeCambioChuquicaja.Models;

namespace CasaDeCambioChuquicaja.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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


    [HttpGet]
    public IActionResult Cambio()
    {
        return View(new CambioModel());
    }

    [HttpPost]
    public IActionResult Cambio(CambioModel model)
    {
        if (ModelState.IsValid)
        {
            string clave = $"{model.MonedaOrigen}_{model.MonedaDestino}";
            if (CambioModel.TasasDeCambio.TryGetValue(clave, out decimal tasa))
            {
                model.Resultado = model.Cantidad * tasa;
                return RedirectToAction("Boleta", new { 
                    monedaOrigen = model.MonedaOrigen, 
                    monedaDestino = model.MonedaDestino,
                    cantidad = model.Cantidad,
                    resultado = model.Resultado
                });
            }
        }
        return View(model);
    }


    ///boleta
    [HttpGet]
    public IActionResult Boleta(string monedaOrigen, string monedaDestino, decimal cantidad, decimal resultado)
    {
        var model = new BoletaModel
        {
            MonedaOrigen = monedaOrigen,
            MonedaDestino = monedaDestino,
            Cantidad = cantidad,
            Resultado = resultado
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Boleta(BoletaModel model)
    {
        if (ModelState.IsValid)
        {
            // Aquí normalmente guardarías en base de datos
            return RedirectToAction("BoletaGenerada", model);
        }
        return View(model);
    }

    public IActionResult BoletaGenerada(BoletaModel model)
    {
        return View(model);
    }
}
