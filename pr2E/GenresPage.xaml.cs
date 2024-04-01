using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using pr2E;

namespace pr2E
{
    public partial class GenresPage : Page
    {
        private readonly pr2Entities _dbContext = new pr2Entities(); 
        private ObservableCollection<Genres> _genresList; 

        public GenresPage()
        {
            InitializeComponent();
            LoadGenres();
        }

        private void LoadGenres()
        {
            
            _genresList = new ObservableCollection<Genres>(_dbContext.Genres);
            BD_Genres.ItemsSource = _genresList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
       
            Genres newGenre = new Genres
            {
                Name = text1.Text
            };
            _dbContext.Genres.Add(newGenre);
            _dbContext.SaveChanges();
            _genresList.Add(newGenre); 
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Genres selectedGenre = BD_Genres.SelectedItem as Genres;
            if (selectedGenre != null)
            {
                selectedGenre.Name = text1.Text;
                _dbContext.SaveChanges();
            }
            else
            {
                MessageBox.Show("Select a genre to edit.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Genres selectedGenre = BD_Genres.SelectedItem as Genres;
            if (selectedGenre != null)
            {
                _dbContext.Genres.Remove(selectedGenre);
                _dbContext.SaveChanges();
                _genresList.Remove(selectedGenre); 
            }
            else
            {
                MessageBox.Show("Select a genre to delete.");
            }
        }
    }
}
