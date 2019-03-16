using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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

namespace Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseballEntities baseballEntities = new BaseballEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            playerDataGrid.ItemsSource = baseballEntities.Players.OrderBy(player => player.PlayerID).ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var query =
            from player in baseballEntities.Players
            where player.LastName == searchTextBox.Text
            orderby player.PlayerID
            select player;

            playerDataGrid.ItemsSource = query.ToList<Player>();
        }
    }
}
