using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace LoginSystem
{
    public class Login : CommonDataAccess
    {
        public Login(string conString) : base(conString)
        {

        }
        public List<LoginAccess> GetAllFilms()
        {
            string sql = "SELECT * FROM Film";
            DataSet dataset = ExecuteQuery(sql);
            List<LoginAccess> films = new List<LoginAccess>();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                LoginAccess f = new LoginAccess(
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
        public bool LoginUserName(string UserName)
        {
            string sql = $"select username from login where username = '{UserName}'";
            string username = "";
            DataSet affectedRows = ExecuteQuery(sql);
            foreach (DataRow dr in affectedRows.Tables[0].Rows)
            {
                username = dr.Field<string>("username");
            }
            bool UsernameIsEmpty = !String.IsNullOrWhiteSpace(username);
            return UsernameIsEmpty;
        }
        public bool LoginPassword(string Password)
        {
            string sql = $"select Password from login where password = '{Password.GetHashCode()}'";
            string password = "";
            DataSet affectedRows = ExecuteQuery(sql);
            foreach (DataRow dr in affectedRows.Tables[0].Rows)
            {
                password = dr.Field<string>("password");
            }
            bool UsernameIsEmpty = !String.IsNullOrWhiteSpace(password);
            return UsernameIsEmpty;
        }
        public int Save(string u, string p)
        {
            string sql = $"INSERT INTO Login VALUES ('{u}',{p.GetHashCode()})";

            int affectRows = ExecuteNonQuery(sql);

            return affectRows;

        }
    }
}
