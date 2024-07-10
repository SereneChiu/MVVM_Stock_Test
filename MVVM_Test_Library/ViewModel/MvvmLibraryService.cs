using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM_Test_Library
{
    public class MvvmLibraryService : IMvvmLibraryService
    {
        private bool mLoadResult = false;
        private MainPage mMainPage = new MainPage();

        public UserControl MainPage 
        { 
            get 
            {
                mLoadResult = true;
                return mMainPage; 
            } 
        }
        public bool LoadResult { get { return mLoadResult; } }
    }
}
