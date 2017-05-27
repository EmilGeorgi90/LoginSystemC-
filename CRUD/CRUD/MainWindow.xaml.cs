using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FilmInfoAccess Film = new FilmInfoAccess("Data Source=MININT-HGBTR5E;Initial Catalog=filminfo;Integrated Security=True");
        public static bool IslogedIn = true;
        List<Film> films;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void FilmInput_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (IslogedIn == false)
                {
                    MessageBox.Show("you need login");
                }
                else
                {
                    try
                    {
                        Film NewFilm = new Film(txtTitel.Text, txtLand.Text, Convert.ToInt32(txtYear.Text), txtGenre.Text, Convert.ToInt32(txtOscars.Text));
                        Film.Save(NewFilm);
                        films = Film.GetAllFilms();
                        dgFilms.ItemsSource = films;

                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("only number is allowed in,Year and Oscars");

                    }
                }

            }
            catch (SqlException)
            {

                MessageBox.Show("there are allready one of these movies");
            }
        }

        private void btnGetFilms_Click(object sender, RoutedEventArgs e)
        {
            if (IslogedIn == false)
            {
                MessageBox.Show("you need login");
            }
            else
            {
                films = Film.GetAllFilms();
                dgFilms.ItemsSource = films;
            }
        }

        private void btnDeleteElement_Click(object sender, RoutedEventArgs e)
        {
            if (IslogedIn == false)
            {
                MessageBox.Show("you need login");
            }
            else
            {
                try
                {
                    Film NewFilm = new Film(txtTitel.Text, txtLand.Text, Convert.ToInt32(txtYear.Text), txtGenre.Text, Convert.ToInt32(txtOscars.Text));
                    Film.Delete(NewFilm);
                    films = Film.GetAllFilms();
                    dgFilms.ItemsSource = films;


                }
                catch (FormatException)
                {

                    MessageBox.Show("only number is allowed in,Year and Oscars");
                }

            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IslogedIn == false)
                {
                    MessageBox.Show("you need login");
                }
                else
                {
                    try
                    {
                        Film UpdateData = new Film(txtTitel.Text, txtLand.Text, Convert.ToInt32(txtYear.Text), txtGenre.Text, Convert.ToInt32(txtOscars.Text));
                        Film Update = new Film(txtTitelDelete.Text, txtLandDelete.Text, Convert.ToInt32(txtYearDelete.Text), txtGenreDelete.Text, Convert.ToInt32(txtOscarsDelete.Text));
                        Film.Update(UpdateData, Update);
                        films = Film.GetAllFilms();
                        dgFilms.ItemsSource = films;
                    }
                    catch (FormatException)
                    {

                        MessageBox.Show("only number is allowed in, Year and Oscars");
                    }
                }
        }
                        catch (SqlException)
            {

                MessageBox.Show("there are allready one of these movies");
            }
}

private void dgFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (IslogedIn == false)
    {
        MessageBox.Show("you need login");
    }
    else if (dgFilms.SelectedItem != null)
    {
        Film selectedfilm = (Film)dgFilms.SelectedItem;
        txtTitel.Text = selectedfilm.Title;
        txtLand.Text = selectedfilm.Land;
        txtYear.Text = selectedfilm.Year.ToString();
        txtGenre.Text = selectedfilm.Genre.ToString();
        txtOscars.Text = selectedfilm.Oscars.ToString();
    }
    else
    {
        txtTitel.Clear();
        txtLand.Clear();
        txtYear.Clear();
        txtGenre.Clear();
        txtOscars.Clear();
    }
}

    }
}

