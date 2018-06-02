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
    /// Interaction logic for AddDirectorWindow.xaml
    /// </summary>
    public partial class AddDirectorWindow : Window
    {
        public AddDirectorWindow()
        {
            InitializeComponent();
        }
        internal Director Director { get; set; } = null;

        private void AddDirectorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Director = new Director
                {
                    Id = int.Parse(DirectorIdTextBox.Text.Trim()),
                    FirstName = DirectorFirstNameTextBox.Text.Trim(),
                    LastName = DirectorLastNameTextBox.Text.Trim()
                };

                using (var context = new MovieContext("MyMovieDB"))
                {
                    if (context.Directors.Any(director=>director.Id == Director.Id))
                    {
                        Director = null;
                        throw new InvalidInputException("Director with same id allready exists");
                    }
                }
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Notice");
            }
        }

        internal void SetId(int id)
        {
            DirectorIdTextBox.Text = id.ToString();
            DirectorIdTextBox.IsReadOnly = true;
            DirectorIdTextBox.Background = Brushes.LightGray;
        }
    }
}
