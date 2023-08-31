﻿using System.Diagnostics;
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
    
    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        if(BD.ObtenerPreguntas(dificultad, categoria).Any()){
            Juego.CargarPartida(username,dificultad,categoria);
            return RedirectToAction("Jugar");
        }else{
            return RedirectToAction("ConfigurarJuego");
        }
    }

    public IActionResult Jugar()
    {
        ViewBag.Jugando = true;
        Preguntas preg = Juego.ObtenerProximaPregunta();
        if(preg != null){
            ViewBag.username = Juego._username;
            ViewBag.puntos = Juego._puntajeActual;
            ViewBag.pregunta = preg;
            ViewBag.respuestas = Juego.ObtenerProximaRespuesta(preg.IdPregunta);
            
            return View();
        }else{
            return RedirectToAction("Fin");
        }
    }

    public IActionResult Fin()
    {
        return View();
    }

    [HttpPost]public IActionResult VerificarRespuesta(int idRespuesta, int idPregunta)
    {
        ViewBag.esCorreta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        return View("Respuesta");
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}