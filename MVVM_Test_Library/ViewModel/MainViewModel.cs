using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM_Test_Library.View;
using MVVM_Test_Library.ViewModel;

namespace MVVM_Test_Library
{
    public class MainViewModel : NavigationControlViewModelBase
    {
        private StockMonitorView monitor_page = new StockMonitorView();
        private ViewDataModel data_model = new ViewDataModel();

        public MainViewModel()
        {
            CurrentPageViewModel = monitor_page;
            monitor_page.DataContext = data_model;
        }

        public int SliderValue
        {
            get { return data_model.SliderValue; }
            set
            {
                if (data_model.SliderValue != value)
                {
                    data_model.SliderValue = value;
                    OnPropertyChanged("SliderValue");
                }
            }
        }
    }
}
