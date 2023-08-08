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

    public static void ObtenerProximaPregunta(){
        bool exists = false;
        int[] numsAlreadyChosen = new int[_preguntas.Count];
        Random r = new Random();
        while (!exists){
            if(Array.IndexOf(numsAlreadyChosen, r.Next(_preguntas.Count))){
                exists = false;
            }else{
                exists = true;
            }
        }
        return r;
    }
    public static void ObtenerProximasRespuestas(int IdPregunta){
        List<Respuestas> fewRespuestas = new List<Respuestas>();
        int i = 4;
        while(i > 0){
            
        }
    }
} 
