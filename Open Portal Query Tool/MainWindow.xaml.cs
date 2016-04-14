using System.Diagnostics;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Open_Portal_Query_Tool.Controls;
using Open_Portal_Query_Tool.Model;
using Open_Portal_Query_Tool.ViewModel;

namespace Open_Portal_Query_Tool {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
            this.ColumnCheckListBox.ItemsSource = mainWindowViewModel.Columns;
            mainWindowViewModel.Columns.Add(new OpenDataColumn("ECB", "Visual Name"));
        }

        /// <summary>
        /// TODO:Dynamically update the Listbox located in the Left Drawer to display Checkboxes depending on the number of columns returned by the data.
        /// </summary>
        public void PopulateColumnListBox() {
            
        }

        private void GitHub_OnClick(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/FaustoPayano");
        }

        private async void Warning_OnGotFocus(object sender, RoutedEventArgs e) {
            var warningMessageDialog = new WarningDialog() {
                WarningMessage = {Text = "If this value is changed you will no longer be querying the ECB Open Data dataset."}
            };
            await DialogHost.Show(warningMessageDialog, "RootDialog");
        }
    }
}
