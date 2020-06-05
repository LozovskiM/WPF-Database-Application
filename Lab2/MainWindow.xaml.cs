using Lab2.Models;
using System;
using System.Collections.Generic;
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

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FilmsDBContext db = new FilmsDBContext();
        private int changingMovie = 0;
        private int changingActor = 0;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            List<Movie> movies = db.Movie.ToList();
            foreach (Movie m in movies)
            {
                listBox1.Items.Add(m.ToString());
            }
        }

        private void GetAllActors_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            List<Actor> actors = db.Actor.ToList();
            foreach (Actor a in actors)
            { 
                listBox1.Items.Add(a.ToString() + ", " + db.Movie.ToList()[a.MovieId - 1].Title);
            }
        }

        private void AddMovie_Click(object sender, RoutedEventArgs e)
        {
            Movie newM = new Movie();
            newM.Title = text_title.Text;
            newM.DirectedBy = text_dir.Text;
            newM.Budget = Int32.Parse(text_budget.Text);
            newM.ReleaseDate = Date_movie.DisplayDate;
            newM.Rating = float.Parse(text_rat.Text);
            newM.Id = db.Movie.ToList().Last().Id + 1;
            db.Movie.Add(newM);
            db.SaveChanges();
        }

        private void buttonAddActor_Click(object sender, RoutedEventArgs e)
        {
            Actor newA = new Actor();
            newA.Name = textName.Text;
            newA.Born = DateBorn.DisplayDate;
            newA.Nation = textNation.Text;
            newA.MovieId = db.Movie.FirstOrDefault(s => s.Title.Contains(textMovie.Text)).Id;
            db.Actor.Add(newA);
            db.SaveChanges();
        }

        private void buttonAccMov_Click(object sender, RoutedEventArgs e)
        {
            db.Movie.ToList()[changingMovie].Title = text_title.Text;
            db.Movie.ToList()[changingMovie].DirectedBy = text_dir.Text;
            db.Movie.ToList()[changingMovie].Budget = Int32.Parse(text_budget.Text);
            db.Movie.ToList()[changingMovie].ReleaseDate = Date_movie.DisplayDate;
            db.Movie.ToList()[changingMovie].Rating = float.Parse(text_rat.Text);
            db.SaveChanges();


        }

        private void buttonRefMov_Click(object sender, RoutedEventArgs e)
        {
            String str = listBox1.SelectedItem.ToString();
            text_title.Text = db.Movie.ToList()[Int32.Parse(str.ElementAt(0).ToString())-1].Title;
            text_dir.Text = db.Movie.ToList()[Int32.Parse(str.ElementAt(0).ToString())-1].DirectedBy;
            text_budget.Text = db.Movie.ToList()[Int32.Parse(str.ElementAt(0).ToString())-1].Budget.ToString();
            Date_movie.DisplayDate = db.Movie.ToList()[Int32.Parse(str.ElementAt(0).ToString())-1].ReleaseDate;
            text_rat.Text = db.Movie.ToList()[Int32.Parse(str.ElementAt(0).ToString())-1].Rating.ToString();
            changingMovie = db.Movie.ToList()[Int32.Parse(str.ElementAt(0).ToString()) - 1].Id-1;
        }

        private void buttonRefAct_Click(object sender, RoutedEventArgs e)
        {
            String str = listBox1.SelectedItem.ToString();
            textName.Text = db.Actor.ToList()[Int32.Parse(str.ElementAt(0).ToString()) - 1].Name;
            DateBorn.DisplayDate = db.Actor.ToList()[Int32.Parse(str.ElementAt(0).ToString()) - 1].Born;
            textNation.Text = db.Actor.ToList()[Int32.Parse(str.ElementAt(0).ToString()) - 1].Nation;
            textMovie.Text = db.Movie.FirstOrDefault(s => s.Id == db.Actor.ToList()[Int32.Parse(str.ElementAt(0).ToString()) - 1].MovieId).Title;
            changingActor = db.Actor.ToList()[Int32.Parse(str.ElementAt(0).ToString()) - 1].Id-1;
        }

        private void buttonAccAct_Click(object sender, RoutedEventArgs e)
        {
            db.Actor.ToList()[changingActor].Name = textName.Text;
            db.Actor.ToList()[changingActor].Born = DateBorn.DisplayDate;
            db.Actor.ToList()[changingActor].Nation = textNation.Text;
            db.Actor.ToList()[changingActor].MovieId = db.Movie.FirstOrDefault(s => s.Title.Contains(textMovie.Text)).Id;
            db.SaveChanges();
        }

        private void buttonDelMov_Click(object sender, RoutedEventArgs e)
        {
            String str = listBox1.SelectedItem.ToString();
            Movie mv = db.Movie.Find(Int32.Parse(str.ElementAt(0).ToString()));
            db.Movie.Remove(mv);
            db.SaveChanges();
        }

        private void buttonDelAct_Click(object sender, RoutedEventArgs e)
        {
            String str = listBox1.SelectedItem.ToString();
            Actor ac = db.Actor.Find(Int32.Parse(str.ElementAt(0).ToString()));
            db.Actor.Remove(ac);
            db.SaveChanges();
        }
    }
}
