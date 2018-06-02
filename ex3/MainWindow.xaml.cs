using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace ex3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string Person { get; set; }
        public static string Prize { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            using (var context = new MovieContext("MyMovieDB"))
            {

                context.Database.Initialize(true);
                
                context.SaveChanges();
            }
        }

        private void AddActorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddActorWindow window = new AddActorWindow();
            Person = "Actor";
            window.ShowDialog();
            if (window.Person != null)
            {
                Actor actor = new Actor
                {
                    Id = window.Person.Id,
                    FristName = window.Person.FristName,
                    LastName = window.Person.LastName,
                    YearBorn = window.Person.YearBorn
                };
                using(var context = new MovieContext("MyMovieDB"))
                {
                    context.Actors.Add(actor);
                    context.SaveChanges();
                }
            }
        }

        private void AddActressMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddActorWindow window = new AddActorWindow();
            Person = "Actress";
            window.ShowDialog();

            if (window.Person != null)
            {
                Actress actress = new Actress
                {
                    Id = window.Person.Id,
                    FristName = window.Person.FristName,
                    LastName = window.Person.LastName,
                    YearBorn = window.Person.YearBorn
                };
                using (var context = new MovieContext("MyMovieDB"))
                {
                    context.Actresses.Add(actress);
                    context.SaveChanges();
                }
            }
        }

        private void AddMovieMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddMovieWindow window = new AddMovieWindow();
            window.ShowDialog();
        }

        private void AddOscarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddOscarGoldenGlobe window = new AddOscarGoldenGlobe();
            Prize = "Oscar";
            window.ShowDialog();

            if (window.Prize != null)
            {
                using (var context = new MovieContext("MyMovieDB"))
                {
                    var actor = (from a in context.Actors where a.Id == window.Prize.ActorId select a).ToList().Single();
                    var actress = (from a in context.Actresses where a.Id == window.Prize.ActressId select a).ToList().Single();
                    var director = (from d in context.Directors where d.Id == window.Prize.DirectorId select d).ToList().Single();
                    try
                    {
                        context.Oscars.Add(new Oscar
                        {
                            Year = window.Prize.Year,
                            BestActor = actor,
                            BestActress = actress,
                            BestDirector = director,
                            BestMotionPicture = (from m in context.Movies where m.MovieSerial == window.Prize.MovieSerial select m).ToList().Single()
                        });

                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                            }
                        }
                    }
                }
            }
        }

        private void AddGoldenGlobeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddOscarGoldenGlobe window = new AddOscarGoldenGlobe();
            Prize = "Golden Globe";
            window.ShowDialog();
        }

        private void AddDirectorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddDirectorWindow window = new AddDirectorWindow();
            window.ShowDialog();

            if (window.Director != null)
            {
                using (var context = new MovieContext("MyMovieDB"))
                {
                    context.Directors.Add(window.Director);
                    context.SaveChanges();
                } 
            }
        }
    }
}
