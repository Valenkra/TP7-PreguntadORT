namespace TP7_PreguntadORT.Models;

public static class Juego 
{
    private static string _username;
    private static int _puntajeActual;
    private static int  _cantidadPreguntasCorrectas;
    private static List<Preguntas> _preguntas;
    private static List<Respuestas> _respuestas;

    public static void InicializarJuego(){
        _username = "";
        _cantidadPreguntasCorrectas = 0;
        _puntajeActual = 0;

    }

    public static void CargarPartida(string username, int dificultad, int categoria){
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
        _username = username;
    }

    public static int ObtenerProximaPregunta(){
        bool exists = false;
        int[] numsAlreadyChosen = new int[_preguntas.Count];
        Random r = new Random();
        while (!exists){
            if(Array.IndexOf(numsAlreadyChosen, r.Next(_preguntas.Count)) == -1){
                exists = false;
            }else{
                exists = true;
            }
        }
        return r;
    }
    public static bool ObtenerProximasRespuestas(int IdPregunta, int idRespuesta){
        List<Respuestas> = new List<Respuestas>();
        bool respuesta = false; 
        int i = 4;
        while(i> 0 ){
            if (IdPregunta = idRespuesta){
                _puntajeActual  = _puntajeActual  + 100;
                _cantidadPreguntasCorrectas = _cantidadPreguntasCorrectas + 1; 
                List<Respuestas> = list.RemoveAt(idPregunta);
                return respuesta=true; 
                i=0;
            }
        }
        return respuesta; 

    }

} 
