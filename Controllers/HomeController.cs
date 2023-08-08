using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7_PreguntadORT.Models;

namespace TP7_PreguntadORT.Controllers;

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

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.categorias = BD.ObtenerCategorias();
        ViewBag.dificultades = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Jugar(int dificultad, int categoria)
    {
        Juego._preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        Juego._respuestas = BD.ObtenerRespuestas(ViewBag.Preguntas);
        /*ViewBag.Puntaje = Juego._puntajeActual;
        ViewBag.Opciones = Juego._respuestas;*/
        return View();
    }

    public IActionResult Fin()
    {
        /*ViewBag.Nombre = Juego._username;
        ViewBag.Puntaje = Juego._puntajeActual;*/
        return View();
    }

    
    [HttpPost]
    public IActionResult Respuesta()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
