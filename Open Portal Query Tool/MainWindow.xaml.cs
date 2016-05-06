using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using Open_Portal_Query_Tool.Controls;
using Open_Portal_Query_Tool.Model;
using Open_Portal_Query_Tool.ViewModel;
using SODA;

namespace Open_Portal_Query_Tool {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private QueryManager globalQueryManager;
        private ResourceMetadata resourceMetaData;
        private MainWindowViewModel mainWindowViewModel;
        private DataGridViewModel mainDataGridViewModel;

        public MainWindow() {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
            mainWindowViewModel.AppToken = GetAppToken();
            this.ColumnCheckListBox.ItemsSource = mainWindowViewModel.Columns;
            mainDataGridViewModel = new DataGridViewModel();
            ViolationDataGrid.DataContext = mainDataGridViewModel;
            ViolationDataGrid.ItemsSource = mainDataGridViewModel.Violations;
            PopulateColumnListBox();
        }
        /// <summary>
        /// Dynamically update the Listbox located in the Left Drawer to display Checkboxes depending on the number of columns returned by the data.
        /// </summary>
        public void PopulateColumnListBox() {

            /*
           var columnPopulatorWorker = new BackgroundWorker();
            columnPopulatorWorker.DoWork += new DoWorkEventHandler(GetMetaData);
            columnPopulatorWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GenerateColumns);
            columnPopulatorWorker.RunWorkerAsync();
             */


#if DEBUG
            globalQueryManager = new QueryManager(ApiURLBox.Text, ApiEndPointBox.Text, mainWindowViewModel.AppToken);
            resourceMetaData = globalQueryManager.GetMetaData();
            mainWindowViewModel.Columns.Clear();
            ViolationDataGrid.Columns.Clear();
            mainWindowViewModel.LastUpdated = resourceMetaData.RowsLastUpdated.Value.ToString("MM-dd-yyyy");
            foreach (var row in resourceMetaData.Columns) {
                mainWindowViewModel.Columns.Add(new OpenDataColumn(row.SodaFieldName, row.Name));
                ViolationDataGrid.Columns.Add(new DataGridTextColumn() {
                    Header = row.Name
                });
            }
#endif
        }
        /// <summary>
        /// When worker retrieves resources from dataset we begin populating column.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateColumns(object sender, RunWorkerCompletedEventArgs e) {
            if (e != null) {
                ResourceMetadata resourceMetaData = (ResourceMetadata) e.Result;
                foreach (var row in resourceMetaData.Columns) {
                    mainWindowViewModel.Columns.Add(new OpenDataColumn(row.Name, row.SodaFieldName));
                }
            }
            else {
                MessageBox.Show("E is null");
            }
        }
        /// <summary>
        /// This Method creates an instance of query manager based on the data entered on our respective textboxes. It also retrieves config file app token. Creates a New Query Manager Instnace
        /// TODO: Refine The GetAppToken() Method, more secure method exists. Rename Method name to avoid confusion with local method GetMetaData().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetMetaData(object sender, DoWorkEventArgs e) {
            globalQueryManager = new QueryManager(ApiURLBox.Text, ApiEndPointBox.Text, GetAppToken());
            e.Result = globalQueryManager.GetMetaData();

        }
        /// <summary>
        /// Retrieve App token From Config File. 
        /// TODO:Create a more secure way of storing the AppToken
        /// </summary>
        /// <returns></returns>
        private string GetAppToken() {
            var configFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.txt");
            if (File.Exists(configFile)) {
                using (StreamReader reader = new StreamReader(configFile)) {
                    var appToken = reader.ReadLine();
                    return appToken;
                }
            }
            throw new ArgumentException("No config File Exists");
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
                responseBox.SelectAll();
            }
        }
        private async void QueryButton_OnClick(object sender, RoutedEventArgs e) {
            IEnumerable<Violation> resultSet;
            await Task.Run(() => {
                resultSet = globalQueryManager.GetAllRows();
                foreach (var violation in resultSet) {
                    App.Current.Dispatcher.Invoke((Action) delegate {
                        mainDataGridViewModel.AddViolationRecord(violation);
                    });
                }
            });
            ViolationDataGrid.Items.Refresh();
        }



        /// <summary>
        /// Updates Meta Data reference to new instance and sets the columns.
        ///  </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateColumnsMetaData_Click(object sender, RoutedEventArgs e) {
            PopulateColumnListBox();
        }
    }
}
