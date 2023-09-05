using System;
using System.Collections.Generic;
using System.Linq;

namespace TP7_PreguntadORT.Models;

public static class Juego 
{
    public static string _username { get; private set; }
    public static int _puntajeActual { get; private set; }
    public static int  _cantidadPreguntasCorrectas { get; private set; }
    public static List<Preguntas> _preguntas { get; private set; }
    public static List<Respuestas> _respuestas { get; private set; }

    public static void InicializarJuego(){
        _username = "";
        _cantidadPreguntasCorrectas = 0;
        _puntajeActual = 0;
        _preguntas = new List<Preguntas>();
        _respuestas = new List<Respuestas>();
    }

    public static void CargarPartida(string username, int dificultad, int categoria){
        _preguntas.AddRange(BD.ObtenerPreguntas(dificultad, categoria));
        _respuestas.AddRange(BD.ObtenerRespuestas(_preguntas));
        _username = username;
    }

    public static Preguntas ObtenerProximaPregunta(){
        if(_preguntas?.Any() != true){
            return null;
        }
        else{ 
            Random r = new Random();
            return _preguntas[r.Next(_preguntas.Count)];
        }
    }

    public static IEnumerable<Respuestas> ObtenerProximaRespuesta(int idPregunta){
        return _respuestas.Where(res => res.IdPregunta == idPregunta);
    }

    public static bool VerificarRespuesta(int idPregunta, int idRes){
        bool esCorrecta = false;
        Respuestas? god = _respuestas.Find(res => res.IdRespuesta == idRes && res.Correcta == true);
        if(god != null && god.Correcta == true){
            esCorrecta = true;
            _puntajeActual += 30;
        }
        _preguntas.RemoveAll(preg => preg.IdPregunta == idPregunta);
        return esCorrecta;
    }
} 