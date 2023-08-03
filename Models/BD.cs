using System.Data.SqlClient;
using Dapper;

namespace TP7_PreguntadORT.Models;

static class BD {
    private static string _connectionString = @"Server=localhost;
            DataBase=PreguntadORT; Trusted_Connection=True;";

    public static List<Categorias> ObtenerCategorias(){
        List<Categorias> _ObtenerCate = new List<Categorias>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM Categorias";
            _ObtenerCate =  db.Query<Partido>(SQL).ToList();
        }
        return _ObtenerCate;
    }
    
    public static List<Dificultades> ObtenerDificultades(){
        List<Dificultades> _ObtenerDif = new List<Dificultades>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM Dificultades";
            _ObtenerDif =  db.Query<Partido>(SQL).ToList();
        }
        return _ObtenerDif;
    }

    public static List<Preguntas> ObtenerPreguntas(int dificultad, int categoria){
        List<Preguntas> _ObtenerPregs = new List<Preguntas>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM Dificultades";
            _ObtenerPregs =  db.Query<Partido>(SQL).ToList();
        }
        return _ObtenerDif;
    }

}