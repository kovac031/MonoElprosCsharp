using Antlr.Runtime.Misc;
using PovezivanjeSbazom.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PovezivanjeSbazom.WebApi
{
    public class TestController : ApiController
    {
        public static string connectionString = "Data Source=VREMENSKISTROJ;Initial Catalog=SmallCinema;Integrated Security=True";

        [HttpGet]
        public HttpResponseMessage GetFilms()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); //conn je connection

                using(conn) 
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Film", conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<FilmClass> filmList = new List<FilmClass>();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            FilmClass film = new FilmClass();

                            film.Id = reader.GetGuid(0);
                            film.Title = reader.GetString(1);
                            film.Release = reader.GetInt32(2);
                            film.Genre = reader.GetString(3);
                            film.Duration = reader.GetInt32(4);
                            
                            filmList.Add(film);
                        }
                        reader.Close();
                        return Request.CreateResponse(HttpStatusCode.OK, filmList);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No movies here!");
                    }
                }                                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetFilms: {ex.Message}");
            }
        }







        /*
        [HttpGet]
            // Data Source=VREMENSKISTROJ;Initial Catalog=SmallCinema;Integrated Security=True
            SqlConnection connection = new SqlConnection();*/
    }  
}