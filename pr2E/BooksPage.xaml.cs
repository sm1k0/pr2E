using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using pr2E;

namespace pr2E
{
    public partial class BooksPage : Page
    {
        private readonly pr2Entities _dbContext = new pr2Entities(); 
        private ObservableCollection<Books> _booksList;

        public BooksPage()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            _booksList = new ObservableCollection<Books>(_dbContext.Books);
            BD_Books.ItemsSource = _booksList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Books newBook = new Books
            {
                Title = textTitle.Text,
                AuthorID = int.Parse(textAuthorID.Text),
                GenreID = int.Parse(textGenreID.Text),
                Year = int.Parse(textYear.Text)
            };
            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();
            _booksList.Add(newBook); 
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Books selectedBook = BD_Books.SelectedItem as Books;
            if (selectedBook != null)
            {
                selectedBook.Title = textTitle.Text;
                selectedBook.AuthorID = int.Parse(textAuthorID.Text);
                selectedBook.GenreID = int.Parse(textGenreID.Text);
                selectedBook.Year = int.Parse(textYear.Text);
                _dbContext.SaveChanges();
            }
            else
            {
                MessageBox.Show("Select a book to edit.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Books selectedBook = BD_Books.SelectedItem as Books;
            if (selectedBook != null)
            {
                _dbContext.Books.Remove(selectedBook);
                _dbContext.SaveChanges();
                _booksList.Remove(selectedBook);
            }
            else
            {
                MessageBox.Show("Select a book to delete.");
            }
        }
    }
}
