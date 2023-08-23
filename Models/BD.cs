using System.Data.SqlClient;
using Dapper;

namespace TP7_PreguntadORT.Models;

public static class BD {
    private static string _connectionString = @"Server=localhost;
            DataBase=PreguntadORT; Trusted_Connection=True;";

    public static List<Categorias> ObtenerCategorias(){
        List<Categorias> _ObtenerCate = new List<Categorias>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM Categoria";
            _ObtenerCate =  db.Query<Categorias>(SQL).ToList();
        }
        return _ObtenerCate;
    }
    
    public static List<Dificultades> ObtenerDificultades(){
        List<Dificultades> _ObtenerDif = new List<Dificultades>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM Dificultad";
            _ObtenerDif =  db.Query<Dificultades>(SQL).ToList();
        }
        return _ObtenerDif;
    }

    public static List<Preguntas> ObtenerPreguntas(int? dificultad, int? categoria){
        List<Preguntas> _ObtenerPregs = new List<Preguntas>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = @"SELECT * FROM Pregunta
                        WHERE @IdCategory IS NULL OR IdCategoria = @IdCategory and @IdDifficulty IS NULL OR IdDificultad = @IdDifficulty";
            _ObtenerPregs = db.Query<Preguntas>(SQL, new {IdCategory = categoria, IdDifficulty = dificultad}).ToList();
        }
        return _ObtenerPregs;
    }


    public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas){
        List<Respuestas> _ObtenerRes = new List<Respuestas>();
        foreach(var pregunta in preguntas){
            Respuestas temp = null;
            using(SqlConnection db = new SqlConnection(_connectionString) ){
                string SQL = "SELECT * FROM Respuesta WHERE IdPregunta = @IdPreg";
                temp =  db.QueryFirstOrDefault<Respuestas>(SQL, new {IdPreg = pregunta.IdPregunta});
            }
            _ObtenerRes.Add(temp);
        }
        return _ObtenerRes;
    }


}