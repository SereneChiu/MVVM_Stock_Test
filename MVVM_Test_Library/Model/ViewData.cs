using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Test_Library.Model
{
    public class ViewData : INotifyPropertyChanged
    {
        private double m_price = 0.0;
        private double m_chage_rate = 0.0;
        private string m_status = "";

        public string Name { get; set; } = "";
        public double Price
        {
            get { return m_price; }
            set 
            { 
                if (m_price == value) { return; }
                m_price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public double ChageRate 
        {
            get { return m_chage_rate; }
            set
            {
                if (m_chage_rate == value) { return; }
                m_chage_rate = value;
                m_status = (m_chage_rate > 0) ? "Positive" : "Negative";
                OnPropertyChanged(nameof(ChageRate));
                OnPropertyChanged(nameof(ChageRateStr));
                OnPropertyChanged(nameof(Status));
            }
        }

        public string Status
        {
            get { return m_status; }
        }

        public string ChageRateStr
        {
            get { return m_chage_rate.ToString("#0.0000"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
