using System.Data.SqlClient;
using Dapper;

namespace TP7_PreguntadORT.Models;

public static class BD {
    private static string _connectionString = @"Server=localhost;
            DataBase=PreguntadORT; Trusted_Connection=True;";

    public static List<Categorias> ObtenerCategorias(){
        List<Categorias> _ObtenerCate = new List<Categorias>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM Categorias";
            _ObtenerCate =  db.Query<Categorias>(SQL).ToList();
        }
        return _ObtenerCate;
    }
    
    public static List<Dificultades> ObtenerDificultades(){
        List<Dificultades> _ObtenerDif = new List<Dificultades>();
        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = "SELECT * FROM Dificultades";
            _ObtenerDif =  db.Query<Dificultades>(SQL).ToList();
        }
        return _ObtenerDif;
    }

    public static List<Preguntas> ObtenerPreguntas(int? dificultad, int? categoria){
        dificultad = (dificultad == -1) ? null : dificultad;
        categoria = (categoria == -1) ? null : categoria;

        List<Preguntas> _ObtenerPregs = new List<Preguntas>();

        using(SqlConnection db = new SqlConnection(_connectionString) ){
            string SQL = @"
                    IF EXISTS (SELECT * FROM Pregunta)
                    DROP PROCEDURE [dbo].[po_ObtenerPreguntas]
                    GO
                    CREATE PROCEDURE [dbo].[po_ObtenerPreguntas]
                        @IdCategoria INT,
                        @IdDifictultad INT
                    AS
                    BEGIN
                        SELECT * FROM Pregunta
                        WHERE @IdCategoria IS NULL OR IdCategoria = @IdCategoria and @IdDifictultad IS NULL OR IdDifictultad = @IdDifictultad
                    END
                    EXEC po_ObtenerPreguntas
                    ";
            _ObtenerPregs = db.Query<Preguntas>(SQL, new {IdDifictultad = dificultad, IdCategoria = categoria}).ToList();
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