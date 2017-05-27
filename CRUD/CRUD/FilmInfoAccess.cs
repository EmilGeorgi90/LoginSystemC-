using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class FilmInfoAccess : CommonDataAccess
    {
        public FilmInfoAccess(string conString) : base(conString)
        {
        }
        public int Save(Film f)
        {
            string sql = $"INSERT INTO Film VALUES ('{f.Title}','{f.Land}','{f.Year}','{f.Genre}','{f.Oscars}')";

            int affectRows = ExecuteNonQuery(sql);

            return affectRows;
        }

        public List<Film> GetAllFilms()
        {
            string sql = "SELECT * FROM Film";
            DataSet dataset = ExecuteQuery(sql);
            List<Film> films = new List<Film>();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                Film f = new Film(
                    dr.Field<int>("FilmId"),
                    dr.Field<string>("titel"),
                    dr.Field<string>("land"),
                    dr.Field<int>("year"),
                    dr.Field<string>("genre"),
                    dr.Field<int>("oscars"));

                films.Add(f);
            }
            return films;
        }
        public int Delete(Film f)
        {
            string sql = $"Delete From film Where Titel = '{f.Title}' and land = '{f.Land}' and year = '{f.Year}' and genre = '{f.Genre}' and Oscars = '{f.Oscars}'";

            int affectedRows = ExecuteNonQuery(sql);

            return affectedRows;
        }
        public int Update(Film f, Film u)
        {
            string sql = $"Update film set Titel = '{u.Title}', land = '{u.Land}', year = '{u.Year}', genre = '{u.Genre}', Oscars = '{u.Oscars}' Where Titel = '{f.Title}' and land = '{f.Land}' and year = '{f.Year}' and genre = '{f.Genre}' and Oscars = '{f.Oscars}'";

            int affectedRows = ExecuteNonQuery(sql);

            return affectedRows;
        }
        public bool LoginUserName(string UserName)
        {
            string sql = $"select username from login where username = '{UserName}'";
            string username = "";
            DataSet affectedRows = ExecuteQuery(sql);
            foreach (DataRow dr in affectedRows.Tables[0].Rows)
            {
                username = dr.Field<string>("username");
            }
            bool UsernameIsEmpty = String.IsNullOrWhiteSpace(username);
            return UsernameIsEmpty;
        }
        public bool LoginPassword(string Password)
        {
            string sql = $"select Password from login where password = '{Password}'";
            string password = "";
            DataSet affectedRows = ExecuteQuery(sql);
            foreach (DataRow dr in affectedRows.Tables[0].Rows)
            {
                password = dr.Field<string>("password");
            }
            bool UsernameIsEmpty = String.IsNullOrWhiteSpace(password);
            return UsernameIsEmpty;
        }
    }
}
