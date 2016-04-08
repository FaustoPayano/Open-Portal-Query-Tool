using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            mainWindowViewModel.Columns.Add(new OpenDataColumn("Testing", "Testing"));
        }

        /// <summary>
        /// TODO:Dynamically update the Listbox located in the Left Drawer to display Checkboxes depending on the number of columns returned by the data.
        /// </summary>
        public void PopulateColumnListBox() {
            
        }

        private void GitHub_OnClick(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/FaustoPayano");
        }
    }
}
