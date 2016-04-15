using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Open_Portal_Query_Tool.Model;

namespace Open_Portal_Query_Tool.ViewModel {
    public class DataGridViewModel : INotifyPropertyChanged {
        private ObservableCollection<Violation> _violations;

        /// <summary>
        /// Add new violation to Observable Collection bound to main DataGrid.
        /// </summary>
        /// <param name="newViolation"></param>
        public void AddViolationRecord(Violation newViolation) {
            _violations.Add(newViolation);
        }

        /// <summary>
        /// Removes a violation from the observable collection based on the ticket number.
        /// </summary>
        /// <param name="violationId"></param>
        public void RemoveViolationRecord(string violationId) {
            _violations.Remove(_violations.Single(record => record.TicketNumber == violationId));
        }

        /// <summary>
        /// Get Accessor that returns our private Observable Collection of violations.
        /// </summary>
        public ObservableCollection<Violation> Violations {
            get { return _violations;}
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
