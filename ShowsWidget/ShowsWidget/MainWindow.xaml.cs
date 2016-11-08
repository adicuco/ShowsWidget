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

namespace ShowsWidget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var shows = JsonStuff.GetShows(txtSearch.Text);
            list.ItemsSource = shows;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Show show = (Show)list.SelectedItem;
            Episode ep = null;
            try
            {
                ep = JsonStuff.GetEpisode(show.externals.tvrage);
                DateTime dt = Convert.ToDateTime(ep.airdate);
                lblNextEp.Content = "Next episode airs on " + dt.ToString("d MMM yyy");
            }
            catch (Exception)
            {

                lblNextEp.Content = "No new episode found!";
            }
        }
    }
}
