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
    }
}
