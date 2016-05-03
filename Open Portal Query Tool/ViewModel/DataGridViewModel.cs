using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Open_Portal_Query_Tool.Model;

namespace Open_Portal_Query_Tool.ViewModel {
    public class DataGridViewModel : INotifyCollectionChanged, INotifyPropertyChanged {

        public ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Remove_Violation
        /// <summary>
        /// Removes a violation from the observable collection based on the ticket number.
        /// </summary>
        /// <param name="violationId"></param>
        public void RemoveViolationRecord(string violationId) {
            Violations.Remove(Violations.Single(record => record.TicketNumber == violationId));
        }
        #endregion
        #region Add_Violation
        /// <summary>
        /// Add new violation to Observable Collection bound to main DataGrid.
        /// </summary>
        /// <param name="newViolation"></param>
        public void AddViolationRecord(Violation newViolation) {
            Violations.Add(newViolation);
            this.OnNotifyCollectionChanged(
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Add, newViolation));
        }
        #endregion
        #region NotifyCollectionChanged
        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args) {
            if (this.CollectionChanged != null) {
                this.CollectionChanged(this, args);
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
    }
}
