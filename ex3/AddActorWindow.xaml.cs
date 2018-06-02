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
    /// Interaction logic for AddActorWindow.xaml
    /// </summary>
     partial class AddActorWindow : Window
    {
        public AddActorWindow()
        {
            InitializeComponent();
        }

        public Person Person { get; set; } = null;

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person = new Person
                {
                    Id = int.Parse(ActorIdTextBox.Text.Trim()),
                    FristName = ActorFirstNameTextBox.Text.Trim(),
                    LastName = ActorLastNameTextBox.Text.Trim(),
                    YearBorn = int.Parse(ActorYearBornTextBox.Text.Trim())
                };
                using (var context = new MovieContext("MyMovieDB"))
                {
                    if (MainWindow.Person == "Actor")
                    {
                        if (context.Actors.Any(actor => actor.Id == Person.Id))
                        {
                            Person = null;
                            throw new InvalidInputException("id already belongs to an actor in the database");
                        }
                    }
                    else if (context.Actresses.Any(actress => actress.Id == Person.Id))
                    {
                        Person = null;
                        throw new InvalidInputException("id already belongs to an actress in the database");
                    }
                }
                this.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message,"Notice");
            }
        }
        public void SetId(int id)
        {
            ActorIdTextBox.Text = id.ToString();
            ActorIdTextBox.IsReadOnly = true;
            ActorIdTextBox.Background = Brushes.LightGray;
        }
    }
}
