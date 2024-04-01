using System.Windows;
using System.Windows.Controls;

namespace pr2E
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MenuListView.SelectedIndex = 0; 
        }

        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuListView.SelectedItem != null)
            {
                string selectedPage = ((ListViewItem)MenuListView.SelectedItem).Content.ToString();
                switch (selectedPage)
                {
                    case "Authors":
                        MainFrame.NavigationService.Navigate(new AuthorsPage());
                        break;
                    case "Genres":
                        MainFrame.NavigationService.Navigate(new GenresPage());
                        break;
                    case "Books":
                        MainFrame.NavigationService.Navigate(new BooksPage());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
