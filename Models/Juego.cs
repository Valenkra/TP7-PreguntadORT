namespace TP7_PreguntadORT.Models;

public static class Juego 
{
    private static string _username;
    private static int _puntajeActual;
    private static int  _cantidadPreguntasCorrectas;
    public static List<Preguntas> _preguntas { get; private set; }
    public static List<Respuestas> _respuestas { get; private set; }

    public static void InicializarJuego(){
        _username = "";
        _cantidadPreguntasCorrectas = 0;
        _puntajeActual = 0;

    }

    public static void CargarPartida(string username, int dificultad, int categoria){
        _preguntas.AddRange(BD.ObtenerPreguntas(dificultad, categoria));
        _respuestas.AddRange(BD.ObtenerRespuestas(_preguntas));
        _username = username;
    }

    public static int VerificarRespuesta(int idPregunta, int idRespuesta){
        bool rspcorrecta= false;

        if(idPregunta==idRespuesta){
            _puntajeActual = _puntajeActual + 100;
            _cantidadPreguntasCorrectas = _cantidadPreguntasCorrectas +1;

            Preguntas.RemoveAt(idPregunta);
            
            rspcorrecta=true;
        }
    }
} 
