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

    public static void CargarPartida(string username, int difi, int cate){
        int? dificultad = (difi == -1) ? null : difi;
        int? categoria = (cate == -1) ? null : cate;
        _preguntas.AddRange(BD.ObtenerPreguntas(dificultad, categoria));
        _respuestas.AddRange(BD.ObtenerRespuestas(_preguntas));
        _username = username;
    }

    public static Preguntas ObtenerProximaPregunta(){
        if(_preguntas.Count == 0){
            return null;
        }
        else{ 
            Random r = new Random();
            return _preguntas[r.Next(_preguntas.Count)];
        }
    }

    public static List<Respuestas> ObtenerProximaRespuesta(int idPregunta){
        List<Respuestas> res = new List<Respuestas>();
        bool index = _respuestas.FindIndex(res => res.IdPregunta = idPregunta);
        Console.WriteLine(index);
        return res;
    }

    public static bool VerificarRespuesta(int idPregunta, int idRes){
        bool esCorrecta = false;
        var item = _respuestas.FirstOrDefault(res => res.IdRespuesta == idRes);
        if(item.Correcta == true){
            _puntajeActual += 100;
            _cantidadPreguntasCorrectas += 1;
            _preguntas.RemoveAt(idPregunta);
            esCorrecta = true;
        }

        return esCorrecta;
    }
} 
