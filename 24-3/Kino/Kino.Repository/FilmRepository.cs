using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Kino.Model;

namespace Kino.Repository
{
    public class FilmRepository
    {
        public static string connectionString = "Data Source=VREMENSKISTROJ;Initial Catalog=SmallCinema;Integrated Security=True";

        public List<Film> GetAll() // vracam listu pa zato
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); //conn je connection

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Film", conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    //Kino.Model.Film film = new Kino.Model.Film(); // ne treba, vidi ga

                    List<Film> filmList = new List<Film>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Film film = new Film();

                            film.Id = reader.GetGuid(0);
                            film.Title = reader.GetString(1);
                            film.Release = reader.GetInt32(2);
                            film.Genre = reader.GetString(3);
                            film.Duration = reader.GetInt32(4);

                            filmList.Add(film);
                        }
                        reader.Close();
                        return filmList;
                    }
                    else
                    {
                        return (null);
                    }
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception)
            {
                return (null);
            }
        }

        public Film GetById(Guid id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Film film = new Film(); //stavio tu jer return film mora ici iza while a unutar if petlje, inace javlja not all paths return value

                        while (reader.Read())
                        {
                            //Film film = new Film();

                            film.Id = reader.GetGuid(0);
                            film.Title = reader.GetString(1);
                            film.Release = reader.GetInt32(2);
                            film.Genre = reader.GetString(3);
                            film.Duration = reader.GetInt32(4);
                            //return film;
                        }
                        reader.Close();
                        return film;
                    }
                    else
                    {
                        return (null);
                    }
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception)
            {
                return (null);
            }
        }

        public Film Post(Film film)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); //conn je connection

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Film VALUES (@id, @title, @release, @genre, @duration);", conn);

                    cmd.Parameters.AddWithValue("@id", film.Id=Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@title", film.Title);
                    cmd.Parameters.AddWithValue("@release", film.Release);
                    cmd.Parameters.AddWithValue("@genre", film.Genre);
                    cmd.Parameters.AddWithValue("@duration", film.Duration);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return film;
                    }
                    else
                    {
                        return (null);
                    }
                }   // zatvorio conn, prestao using                        
            }
            catch (Exception)
            {
                return (null);
            }
        }

        public Film Put(string id, Film film)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); 

                using (conn)
                {
                    SqlCommand cmdS = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmdS.Parameters.AddWithValue("@id", id); 
                    conn.Open();

                    SqlDataReader reader = cmdS.ExecuteReader();

                    if (reader.HasRows)
                    {
                        SqlCommand cmdU = new SqlCommand("UPDATE Film SET Title = @title, Release = @release, Genre = @genre, Duration = @duration WHERE Id = @id;", conn);

                        cmdU.Parameters.AddWithValue("@id", id);
                        cmdU.Parameters.AddWithValue("@title", film.Title); 
                        cmdU.Parameters.AddWithValue("@release", film.Release); 
                        cmdU.Parameters.AddWithValue("@genre", film.Genre); 
                        cmdU.Parameters.AddWithValue("@duration", film.Duration);

                        reader.Close();

                        if (cmdU.ExecuteNonQuery() > 0)
                        {
                            return film;
                        }
                        else
                        {
                            return (null);
                        }
                    }
                    else
                    {
                        return (null);
                    }
                }                       
            }
            catch (Exception)
            {
                return (null);
            }
        }

        public List<Film> Delete(string id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                using (conn)
                {
                    SqlCommand cmdS = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmdS.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    SqlDataReader reader = cmdS.ExecuteReader();

                    if (reader.HasRows)
                    {
                        SqlCommand cmdU = new SqlCommand("DELETE FROM Film WHERE Id = @id;", conn);

                        cmdU.Parameters.AddWithValue("@id", id);
                        
                        //reader.Close();

                        if (cmdU.ExecuteNonQuery() > 0)
                        {

                            List<Film> filmList = GetAll();
                            /* List<Film> filmList = new List<Film>();
                            Film film = new Film();
                            
                            while (reader.Read())
                            {
                                film.Id = reader.GetGuid(0);
                                film.Title = reader.GetString(1);
                                film.Release = reader.GetInt32(2);
                                film.Genre = reader.GetString(3);
                                film.Duration = reader.GetInt32(4);

                                filmList.Add(film);
                            }                           

                            reader.Close();*/
                            return filmList;

                        }
                        else
                        {
                            return (null);
                        }
                    }
                    else
                    {
                        return (null);
                    }
                }
            }
            catch (Exception)
            {
                return (null);
            }
        }

    }
}
