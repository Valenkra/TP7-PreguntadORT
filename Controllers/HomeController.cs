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

    public IActionResult Jugar(string username, int dificultad, int categoria)
    {
        return View();
    }


    public IActionResult Fin()
    {
        
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


     public IActionResult Comenzar(string _username, int dificultad, int categoria)
    {
        /*
        Juego.CargarPartida(username, dificultad, categoria);
        if (Juego.ObtenerProximaPregunta() != null)
        {
            return RedirectToAction("Jugar");
        }
        else
        {
            return RedirectToAction("ConfigurarJuego");
        }*/
        return RedirectToAction("ConfigurarJuego");
    }

      public IActionResult Jugar()
    {/*
        Pregunta PreguntaActual = Juego.ObtenerProximaPregunta();
        if (PreguntaActual == null)
        {
            return View("Fin");
        }
        List<Respuesta> respuestas = Juego.ObtenerProximasRespuestas(PreguntaActual.IdPregunta);
        ViewBag.Pregunta = PreguntaActual;
        ViewBag.Respuestas = respuestas;*/
        return View();
    }

    [HttpPost]public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {/*
        bool respuestaCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        ViewBag.RespuestaCorrecta = respuestaCorrecta;*/
        return View("Respuesta");
    }

    /* NO SE CAMBIA */
}
