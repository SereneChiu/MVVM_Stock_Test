using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using MVVM_Test_Library.Model;

namespace MVVM_Test_Library.ViewModel
{
    public class ViewDataModel
    {
        public ObservableCollection<ViewData> ViewDataList { get { return m_view_data_list; } }
        public int SliderValue { get; set; } = StockDataDefine.UPDATE_RATE_VIEW;

        private ObservableCollection<ViewData> m_view_data_list = new ObservableCollection<ViewData>();
        private List<ModelData> m_model_data_list = new List<ModelData>();

        private Thread m_update_view_thread;
        private Thread m_update_model_thread;



        public ViewDataModel()
        {
            m_update_view_thread = new Thread(UpdateViewData);
            m_update_model_thread = new Thread(UpdateModelData);

            m_update_view_thread.IsBackground = true;
            m_update_model_thread.IsBackground = true;

            InitDataList();

            m_update_view_thread.Start();
            m_update_model_thread.Start();
        }


        private void UpdateModelData()
        {
            while (true)
            {
                foreach (var data in m_model_data_list)
                {
                    data.Price = new Random().Next(StockDataDefine.PRICE_LOWER, StockDataDefine.PRICE_UPPER);
                }
                Thread.Sleep(StockDataDefine.UPDATE_RATE_MODEL);
            }
        }

        private void UpdateViewData()
        {
            while (true)
            {
                if (m_view_data_list.Count != m_model_data_list.Count)
                {
                    return;
                }

                if (m_view_data_list.Count != StockDataDefine.TOTAL_DATA_COUNT)
                {
                    return;
                }

                for (int i = 0; i < StockDataDefine.TOTAL_DATA_COUNT; i++)
                {
                    m_view_data_list[i].Price = m_model_data_list[i].Price;
                    m_view_data_list[i].ChageRate = (m_model_data_list[i].Price - m_model_data_list[i].Price_Org)/ m_model_data_list[i].Price_Org;
                }
                Thread.Sleep(SliderValue);
            }

        }


        private void InitDataList()
        {
            m_view_data_list.Clear();
            m_model_data_list.Clear();

            for (int i = 0; i < StockDataDefine.TOTAL_DATA_COUNT; i++)
            {
                m_model_data_list.Add(new ModelData()
                {
                    Name = string.Format("Name_{0}", (i + 1).ToString()),
                    Price_Org = new Random().Next(StockDataDefine.PRICE_LOWER, StockDataDefine.PRICE_UPPER),
                    Price = 0
                });
            }

            for (int i = 0; i < StockDataDefine.TOTAL_DATA_COUNT; i++)
            {
                m_view_data_list.Add(new ViewData()
                {
                    Name = m_model_data_list[i].Name,
                    Price = m_model_data_list[i].Price
                });
            }

        }
    }
}
