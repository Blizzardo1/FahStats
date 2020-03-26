#region Header
// FahStats >FahStats >MainWindow.xaml.cs\n Copyright (C) Adonis Deliannis, 2020\nCreated 26 03, 2020
#endregion

using System.Text;
using System.Windows;

namespace FahStats {
    public partial class MainWindow : Window {
        private Config _config;

        public MainWindow() {
            InitializeComponent();
        }
        
        // TODO: Fix this block
        /// <summary>
        /// Interaction logic for MainWindow_OnLoaded
        /// </summary>
        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
            _config = await Config.LoadAsync();

            dynamic data = await Api.GetTeam(_config.BaseTeam);
            
            foreach (dynamic donor in data.donors) {
                DataOutput.Text += $"{Format(donor)}\n\n";
            }
        }

        private static string Format(dynamic portion) {
            var sb = new StringBuilder();
            sb.Append($"Name: {portion.name}\n");
            sb.Append($"\tWork Units: {portion.wus}\n");
            sb.Append($"\tRank: {portion.rank}\n");
            sb.Append($"\tCredit: {portion.credit}\n");
            sb.Append($"\tTeam: {portion.team}\n");
            sb.Append($"\tId: {portion.id}\n");
            return sb.ToString();
        }
    }
}