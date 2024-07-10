using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Test_Library.Model
{
    public class ModelData 
    {
        private double m_price = 0.0;
        private double m_price_org = 0.0;


        public string Name { get; set; } = "";
        public double Price
        {
            get { return m_price; }
            set
            {
                if (m_price == value) { return; }
                m_price = value;
            }
        }

        public double Price_Org
        {
            get { return m_price_org; }
            set
            {
                if (m_price_org == value) { return; }
                m_price_org = value;
            }
        }

    }
}
