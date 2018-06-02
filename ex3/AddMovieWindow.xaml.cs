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
    /// Interaction logic for AddMovieWindow.xaml
    /// </summary>
    public partial class AddMovieWindow : Window
    {
        public AddMovieWindow()
        {
            InitializeComponent();
        }
        public Movie Movie { get; set; } = null;
        private void AddMovieButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Movie = new Movie
                {
                    MovieSerial = int.Parse(MovieSerialTextBox.Text.Trim()),
                    MovieTitle = MovieTitleTextBox.Text.Trim(),
                    Year = int.Parse(MovieYearTextBox.Text.Trim()),
                    DirectorId = int.Parse(MovieDirectorIdTextBox.Text.Trim()),
                    Country = MovieCountryTextBox.Text.Trim(),
                    ImdbScore = int.Parse(MovieImdbScoreTextBox.Text.Trim())
                };
                using (var context = new MovieContext("MyMovieDB"))
                {
                    if (!context.Directors.Any(d=>d.Id == Movie.DirectorId))
                    {
                        if (MessageBox.Show("No matching director in database. do you wish to add him how?", "Notice", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            AddDirectorWindow window = new AddDirectorWindow();
                            window.SetId(int.Parse(MovieDirectorIdTextBox.Text.Trim()));
                            window.ShowDialog();
                            if (window.Director != null)
                            {
                                context.Directors.Add(window.Director);
                                Movie.Director = (from d in context.Directors where d.Id == Movie.DirectorId select d).ToList().First();
                            }
                            else
                            {
                                throw new InvalidInputException("Invalid director id");
                            }
                        }
                        else
                        {
                            throw new InvalidInputException("Invalid director id");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Movie = null;
                MessageBox.Show(exception.Message, "Notice");
            }
        }

        internal void SetSerial(int serial)
        {
            MovieSerialTextBox.Text = serial.ToString();
            MovieSerialTextBox.IsReadOnly = true;
            MovieSerialTextBox.Background = Brushes.LightGray;
        }
    }
}
