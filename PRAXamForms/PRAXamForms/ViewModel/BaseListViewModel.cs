using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PRAXamForms.ViewModel
{
    public class BaseListViewModel<T> : BaseViewModel where T : class, new()
    {
        #region Constructor

        public BaseListViewModel()
        {
            items = new ObservableCollection<T>();
        }

        #endregion

        #region Collection Peoperty

        private ObservableCollection<T> items;
        public ObservableCollection<T> Items
        {
            get { return items; }
            set
            {
                items.Clear();
                items.Add(value);
                OnPropertyChanged("Items");
            }
        }

        #endregion

        #region Selected Item

        private T selectedItem;
        public T SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
                if (SelectionChangedCommand != null && SelectionChangedCommand.CanExecute(null))
                {
                    SelectionChangedCommand.Execute(null);
                }
            }
        }

        public ICommand SelectionChangedCommand { get; protected set; }

        #endregion
    }
}
