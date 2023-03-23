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
        [Route ("api/test/getfilms")]
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
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetFilms: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/test/getwhere")]
        public HttpResponseMessage GetWhere()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); //conn je connection

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Film WHERE \"Duration\">121", conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<FilmClass> filmList = new List<FilmClass>();
                    if (reader.HasRows)
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
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetWhere: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/test/getid/{id}")] // mora id u viticastima inace ne radi, neznam zasto
        public HttpResponseMessage GetId(Guid id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); //conn je connection

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id); // unesemo u URL id koji smo definirali kao @id, koji ce bit usporedjen sa Id iz Film tablice
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    //List<FilmClass> filmList = new List<FilmClass>(); // ne treba lista jel vracamo jedan rezultat

                    if (reader.HasRows)
                    {
                        //while (reader.Read()) // ne treba while petlja jer zbog GUIDa ima samo jedan moguci rezultat
                        //{
                            reader.Read();
                            FilmClass film = new FilmClass();

                            film.Id = reader.GetGuid(0);
                            film.Title = reader.GetString(1);
                            film.Release = reader.GetInt32(2);
                            film.Genre = reader.GetString(3);
                            film.Duration = reader.GetInt32(4);

                           // filmList.Add(film);
                        //}
                        reader.Close();
                        return Request.CreateResponse(HttpStatusCode.OK, film);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No movies here!");
                    }
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing GetId: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/test/post")]
        public HttpResponseMessage Post([FromBody] FilmClass film)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); //conn je connection

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Film VALUES (@id, @title, @release, @genre, @duration);", conn);

                    //film.Id = new Guid();
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@title", film.Title);
                    cmd.Parameters.AddWithValue("@release", film.Release);
                    cmd.Parameters.AddWithValue("@genre", film.Genre);
                    cmd.Parameters.AddWithValue("@duration", film.Duration);
                    conn.Open();

                    if(cmd.ExecuteNonQuery()>0)
                    {
                        //List<FilmClass> filmList = new List<FilmClass>(); // iniciram listu ali nista ne unosim u nju, trebao bi kopirati onaj GET kod za to, nema potrebe

                        return Request.CreateResponse(HttpStatusCode.OK, "Added movie " + film.Title +" to the list.");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No NEW movies!");
                    }
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Post: {ex.Message}");
            }
        }//unese sta mu napisem ali ne generira guid nego unese sa 0000 sve i javi else message

        [HttpPut]
        [Route("api/test/put/{id}")] 
        public HttpResponseMessage Put(Guid id, [FromBody] FilmClass film)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); 

                using (conn)
                {
                    SqlCommand cmdS = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmdS.Parameters.AddWithValue("@id", id); // unesemo u URL id koji smo definirali kao @id, koji ce bit usporedjen sa Id iz Film tablice
                    conn.Open();

                    SqlDataReader reader = cmdS.ExecuteReader();

                    //List<FilmClass> filmList = new List<FilmClass>(); // ne treba lista jel vracamo jedan rezultat

                    if (reader.HasRows)
                    {
                        SqlCommand cmdU = new SqlCommand("UPDATE Film SET Title = @title, Release = @release, Genre = @genre, Duration = @duration WHERE Id = @id;", conn);

                        //film.Id = new Guid();
                        cmdU.Parameters.AddWithValue("@id", id);
                        cmdU.Parameters.AddWithValue("@title", film.Title); //= string.IsNullOrWhiteSpace(film.Title) ? "@title" : film.Title); ovo nece nista pametno napravit, trebam promijenit
                        cmdU.Parameters.AddWithValue("@release", film.Release); //provjeru mogu sa je ili nije 0 jer je default vrijednost
                        cmdU.Parameters.AddWithValue("@genre", film.Genre); // = string.IsNullOrWhiteSpace(film.Genre) ? "@genre" : film.Genre);
                        cmdU.Parameters.AddWithValue("@duration", film.Duration);
                        
                        reader.Close();

                        if (cmdU.ExecuteNonQuery() > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, "Updated movie " + film.Title);
                        }
                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing updated, something went wrong!");
                        }
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not find movie!");
                    }
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Put: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("api/test/delete/{id}")]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                using (conn)
                {
                    SqlCommand cmdS = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmdS.Parameters.AddWithValue("@id", id); // unesemo u URL id koji smo definirali kao @id, koji ce bit usporedjen sa Id iz Film tablice
                    conn.Open();

                    SqlDataReader reader = cmdS.ExecuteReader();

                    if (reader.HasRows)
                    {
                        SqlCommand cmdU = new SqlCommand("DELETE FROM Film WHERE Id = @id;", conn);

                        cmdU.Parameters.AddWithValue("@id", id);
                        
                        reader.Close();

                        if (cmdU.ExecuteNonQuery() > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, "Movie deleted");
                        }
                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong, did not delete!");
                        }
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not find movie!");
                    }
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error occured while executing Delete: {ex.Message}");
            }
        }

    }  
}