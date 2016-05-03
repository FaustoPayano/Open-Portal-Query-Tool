using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Open_Portal_Query_Tool.Model;

namespace Open_Portal_Query_Tool.ViewModel {
    public class MainWindowViewModel : INotifyCollectionChanged, INotifyPropertyChanged {
        private string _appToken;


        #region LeftDrawerCheckMarkAddition

        public void Add(CheckBox item) {
            this.CheckBoxList.Add(item);
            this.OnNotifyCollectionChanged(
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Add, item));
        }

        #endregion
        #region LeftDrawerColumnGeneration
        public void Add(OpenDataColumn item) {
            this.Columns.Add(item);
            this.OnNotifyCollectionChanged(
                new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Add, item));
        }

        public ObservableCollection<OpenDataColumn> Columns = new ObservableCollection<OpenDataColumn>();
        public ObservableCollection<CheckBox> CheckBoxList = new ObservableCollection<CheckBox>();
        #endregion
        #region INotifyCollectionChanged

        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args) {
            if (this.CollectionChanged != null) {
                this.CollectionChanged(this, args);
            }
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
        #region INotifyPropertyChanged

        private void OnPropertyChanged<T>([CallerMemberName] string caller = null) {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}
