using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
    public class LoginAccess
    {
        public LoginAccess(string genre, string land, int oscars, string title, int year)
        {
            Genre = genre;
            Land = land;
            Oscars = oscars;
            Title = title;
            Year = year;
        }

        public LoginAccess(int filmID, string genre, string land, int oscars, string title, int year)
        {
            FilmID = filmID;
            Genre = genre;
            Land = land;
            Oscars = oscars;
            Title = title;
            Year = year;
        }

        public int FilmID { get; set; }
        public string Genre { get; set; }
        public string Land { get; set; }
        public int Oscars { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
