using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using pr2E;


namespace pr2E
{
    public partial class AuthorsPage : Page
    {
        private readonly pr2Entities _dbContext = new pr2Entities(); 
        private ObservableCollection<Authors> _authorsList; 

        public AuthorsPage()
        {
            InitializeComponent();
            LoadAuthors(); 
        }

        private void LoadAuthors()
        {
            
            _authorsList = new ObservableCollection<Authors>(_dbContext.Authors);
            BD_Authors.ItemsSource = _authorsList;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            Authors newAuthor = new Authors
            {
                FirstName = text1.Text,
                LastName = text2.Text
            };
            _dbContext.Authors.Add(newAuthor);
            _dbContext.SaveChanges();
            _authorsList.Add(newAuthor); 
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
          
            Authors selectedAuthor = BD_Authors.SelectedItem as Authors;
            if (selectedAuthor != null)
            {
                
                selectedAuthor.FirstName = text1.Text;
                selectedAuthor.LastName = text2.Text;
                _dbContext.SaveChanges();
            }
            else
            {
                MessageBox.Show("Select an author to edit.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Authors selectedAuthor = BD_Authors.SelectedItem as Authors;
            if (selectedAuthor != null)
            {
                _dbContext.Authors.Remove(selectedAuthor);
                _dbContext.SaveChanges();
                _authorsList.Remove(selectedAuthor); 
            }
            else
            {
                MessageBox.Show("Select an author to delete.");
            }
        }
    }
}
