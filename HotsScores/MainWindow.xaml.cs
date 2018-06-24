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

namespace HotsScores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ViewModels.MainWindowViewModel(new Hots.HotsApiService());
        }

        public async void GetReplaysButtonClicked(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as ViewModels.MainWindowViewModel;
            await vm.LoadHotsDataAsync();

            ScoresWindow scoresWindow = new ScoresWindow();
            scoresWindow.DataContext = new ViewModels.ScoresViewModel(vm.Replays, vm.PlayerBattleTag);
            scoresWindow.Owner = Window.GetWindow(this);
            scoresWindow.Show();
        }
    }
}
