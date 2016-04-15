using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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


        /// <summary>
        /// Displays warning message to user when clicking on triggering control. If control source is textbox, will set focus and caret to end of text for easy modification and to avoid retriggering warning.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Warning_OnGotFocus(object sender, RoutedEventArgs e) {
            var warningMessageDialog = new WarningDialog() {
                WarningMessage = {Text = "Warning - this value points this tool to the dataset which it queries. \n If changed, you may be accessing a different dataset, or none at all."}
            };
            await DialogHost.Show(warningMessageDialog, "RootDialog");

            if (sender.GetType() == typeof (TextBox)) {
                var responseBox = (TextBox) sender;

                responseBox.Focus();
                responseBox.CaretIndex = responseBox.Text.Length;
            }
        }

        private void QueryButton_OnClick(object sender, RoutedEventArgs e) {
            
        }
    }
}
