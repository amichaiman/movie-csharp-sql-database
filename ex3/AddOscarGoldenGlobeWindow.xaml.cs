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
using System.Windows.Shapes;

namespace ex3
{
    /// <summary>
    /// Interaction logic for AddOscarWindow.xaml
    /// </summary>
    public partial class AddOscarGoldenGlobe : Window
    {
        public AddOscarGoldenGlobe()
        {
            InitializeComponent();
        }
        public Prize Prize { get; set; } = null;

        private void AddOscarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Prize = new Prize
                {
                    Year = int.Parse(OscarYearTextBox.Text.Trim()),
                    ActorId = int.Parse(OscarActorIdTextBox.Text.Trim()),
                    ActressId = int.Parse(OscarActressIdTextBox.Text.Trim()),
                    DirectorId = int.Parse(OscarDirectorIdTextBox.Text.Trim()),
                    MovieSerial = int.Parse(OscarMovieSerialIdTextBox.Text.Trim())
                };
                using (var context = new MovieContext("MyMovieDB"))
                {
                    if (MainWindow.Prize == "Oscar")
                    {
                        if (context.Oscars.Any(oscar=>oscar.Year == Prize.Year))
                        {
                            throw new InvalidInputException("Oscar was already set for given year");
                        }
                    }
                    else if (context.GoldenGlobes.Any(goldenGlobe=>goldenGlobe.Year == Prize.Year))
                    {
                        throw new InvalidInputException("Golden Globe was already set for given year");
                    }
                    if (!context.Actors.Any(actor => actor.Id == Prize.ActorId))
                    {
                        if (MessageBox.Show("No such actor. do you wish to add him now?", "Notice", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            AddActorWindow window = new AddActorWindow();
                            window.SetId(int.Parse(OscarActorIdTextBox.Text.Trim()));
                            MainWindow.Person = "Actor";
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
                                context.Actors.Add(actor);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new InvalidInputException("Invalid actor id");
                            }
                        }
                        else
                        {
                            throw new InvalidInputException("Invalid actor id"); 
                        }
                    }

                    if (!context.Actresses.Any(actress => actress.Id == Prize.ActressId))
                    {
                        if (MessageBox.Show("No such actress. do you wish to add her now?", "Notice", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            AddActorWindow window = new AddActorWindow();
                            window.SetId(int.Parse(OscarActressIdTextBox.Text.Trim()));
                            MainWindow.Person = "Actress";
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
                                context.Actresses.Add(actress);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new InvalidInputException("Invalid actress id");
                            }
                        }
                        else
                        {
                            throw new InvalidInputException("Invalid actress id");
                        }
                    }
                    if (!context.Directors.Any(director=> director.Id == Prize.DirectorId))
                    {
                        if (MessageBox.Show("No such director. do you wish to add him now?", "Notice", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            AddDirectorWindow window = new AddDirectorWindow();
                            window.SetId(int.Parse(OscarDirectorIdTextBox.Text.Trim()));
                            window.ShowDialog();

                            if (window.Director != null)
                            {
                                context.Directors.Add(window.Director);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new InvalidInputException("Invalid director id");
                            }
                        }
                    }
                    if (!context.Movies.Any(movie=> movie.MovieSerial == Prize.MovieSerial))
                    {
                        if (MessageBox.Show("No such movie. do you wish to add it now?", "Notice", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            AddMovieWindow window = new AddMovieWindow();
                            window.SetSerial(int.Parse(OscarMovieSerialIdTextBox.Text.Trim()));
                            window.ShowDialog();

                            if (window.Movie != null)
                            {
                                context.Movies.Add(window.Movie);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new InvalidInputException("Invalid movie serial");
                            }
                        }
                        else
                        {
                            throw new InvalidInputException("Invalid movie serial");
                        }
                    }
                }
                Close();
            }
            catch (Exception exception)
            {
                Prize = null;
                MessageBox.Show(exception.Message, "Notice");
            }
        }
    }
}
