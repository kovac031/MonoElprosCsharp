using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Kino.Model;
using Kino.Repository.Common;
using Kino.Common;

namespace Kino.Repository
{
    public class FilmRepository : IFilmRepository
    {
        public static string connectionString = "Data Source=VREMENSKISTROJ;Initial Catalog=SmallCinema;Integrated Security=True";

        public List<Film> GetPagingSortingFiltering(FilmFiltering filtering, Paging paging, Sorting sorting)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (conn)
            {
                
                StringBuilder sb = new StringBuilder();

                SqlCommand cmd = new SqlCommand();
                sb.Append("SELECT * FROM Film WHERE 1=1");

                if (!string.IsNullOrWhiteSpace(filtering.Title)) // exception ako nijedan parametar u postmanu nije selectan, kaze nesto ovdje null
                {
                    sb.Append(" AND Title LIKE @Title");
                    cmd.Parameters.AddWithValue("@Title", filtering.Title);
                }

                if (!string.IsNullOrWhiteSpace(filtering.Genre))
                {
                    sb.Append(" AND Genre LIKE @Genre");
                    cmd.Parameters.AddWithValue("@Genre", filtering.Genre);
                }

                if (filtering.ReleaseMin != null && filtering.ReleaseMax != null)
                {
                    sb.Append(" AND Release >= @ReleaseMin AND Release <= @ReleaseMax");
                    cmd.Parameters.AddWithValue("@ReleaseMin", filtering.ReleaseMin);
                    cmd.Parameters.AddWithValue("@ReleaseMax", filtering.ReleaseMax);
                }
                else if (filtering.ReleaseMin != null)
                {
                    sb.Append(" AND Release >= @ReleaseMin");
                    cmd.Parameters.AddWithValue("@ReleaseMin", filtering.ReleaseMin);
                }
                else if (filtering.ReleaseMax != null)
                {
                    sb.Append(" AND Release <= @ReleaseMax");
                    cmd.Parameters.AddWithValue("@ReleaseMax", filtering.ReleaseMax);
                }

                if (filtering.MinDuration != null && filtering.MaxDuration != null)
                {
                    sb.Append(" AND Duration >= @MinDuration AND Duration <= @MaxDuration");
                    cmd.Parameters.AddWithValue("@MinDuration", filtering.MinDuration);
                    cmd.Parameters.AddWithValue("@MaxDuration", filtering.MaxDuration);
                }
                else if (filtering.MinDuration != null)
                {
                    sb.Append(" AND Duration >= @MinDuration");
                    cmd.Parameters.AddWithValue("@MinDuration", filtering.MinDuration);
                }
                else if (filtering.MaxDuration != null)
                {
                    sb.Append(" AND Duration <= @MaxDuration");
                    cmd.Parameters.AddWithValue("@MaxDuration", filtering.MaxDuration);
                }
                ////////////////////////////////////////////////////////////////////////

                if (sorting.OrderBy != null && sorting.SortOrder != null)
                {
                    sb.Append($" ORDER BY {sorting.OrderBy} {sorting.SortOrder}");
                    cmd.Parameters.AddWithValue("@OrderBy", sorting.OrderBy);
                    cmd.Parameters.AddWithValue("@Direction", sorting.SortOrder);
                }
                else if (sorting.OrderBy != null)
                {
                    sb.Append(" ORDER BY @OrderBy ASC");
                    cmd.Parameters.AddWithValue("@OrderBy", sorting.OrderBy);
                }
                else if (sorting.SortOrder != null)
                {
                    sb.Append(" ORDER BY Release @Direction");
                    cmd.Parameters.AddWithValue("@Direction", sorting.SortOrder);
                }

                ////////////////////////////////////////////////////////////////////////

                if (paging.PageNumber != null && paging.PageRows != null)
                {
                    sb.Append($" OFFSET @Offset ROWS FETCH NEXT @PageRows ROWS ONLY;");
                    int? pOffset = (0 + paging.PageNumber) * paging.PageRows; 
                    cmd.Parameters.AddWithValue("@PageNumber", paging.PageNumber);
                    cmd.Parameters.AddWithValue("@PageRows", paging.PageRows);
                    cmd.Parameters.AddWithValue("@Offset", pOffset);
                }
                else if (paging.PageNumber != null)
                {
                    sb.Append($" OFFSET @Offset ROWS FETCH NEXT 5 ROWS ONLY;");
                    int? pOffset = (0 + paging.PageNumber) * 5;
                    cmd.Parameters.AddWithValue("@PageNumber", paging.PageNumber);
                    cmd.Parameters.AddWithValue("@Offset", pOffset);
                }
                else if (paging.PageRows != null)
                {
                    sb.Append($" OFFSET 0 ROWS FETCH NEXT @PageRows ROWS ONLY;");
                    cmd.Parameters.AddWithValue("@PageRows", paging.PageRows);
                }

                ///////////////////////////////////////////////////////////////////////

                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                ////////////////////////////////////////////////////////////////////////////
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

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
            }
        }


/// /////////////////////////////////////////////////////////////////////////////////////////


        public async Task<List<Film>> GetAllAsync() // vracam listu pa zato
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); //conn je connection

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Film", conn);
                    conn.Open();

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    
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
        
        public async Task<Film> GetByIdAsync(Guid id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

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
        
        
        public async Task<Film> PostAsync(Film film)
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
        
        
        public async Task<Film> PutAsync(string id, Film film)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString); 

                using (conn)
                {
                    SqlCommand cmdS = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmdS.Parameters.AddWithValue("@id", id); 
                    conn.Open();

                    SqlDataReader reader = await cmdS.ExecuteReaderAsync();

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
        
        
        public async Task<List<Film>> DeleteAsync(string id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                using (conn)
                {
                    SqlCommand cmdS = new SqlCommand("SELECT * FROM Film WHERE Id = @id", conn);
                    cmdS.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    SqlDataReader reader = await cmdS.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        SqlCommand cmdU = new SqlCommand("DELETE FROM Film WHERE Id = @id;", conn);

                        cmdU.Parameters.AddWithValue("@id", id);
                        
                        reader.Close();

                        if (cmdU.ExecuteNonQuery() > 0)
                        {

                            List<Film> filmList = await GetAllAsync(); // jer je async mora ici await
                            // List<Film> filmList = new List<Film>();
                            //Film film = new Film();
                            
                            //while (reader.Read())
                            //{
                            //    film.Id = reader.GetGuid(0);
                            //    film.Title = reader.GetString(1);
                            //    film.Release = reader.GetInt32(2);
                            //    film.Genre = reader.GetString(3);
                            //    film.Duration = reader.GetInt32(4);

                            //    filmList.Add(film);
                            //}                           

                            //reader.Close();
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
