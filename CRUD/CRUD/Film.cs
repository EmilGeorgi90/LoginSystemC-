using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Film
    {

        public Film(int filmId, string title, string land, int year, string genre, int oscars)
        {
            this.FilmID = filmId;
            this.Title = title;
            this.Genre = genre;
            this.Land = land;
            this.Oscars = oscars;
            this.Year = year;
        }
        public Film(string title, string land, int year, string genre, int oscars)
        {
            this.Title = title;
            this.Genre = genre;
            this.Land = land;
            this.Oscars = oscars;
            this.Year = year;
        }
        public int FilmID { get; set; }
        public string Genre { get; set; }
        public string Land { get; set; }
        public int Oscars { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

    }
}
