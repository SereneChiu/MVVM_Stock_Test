using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM_Test_Library
{
    public interface IMvvmLibraryService
    {
        UserControl MainPage { get; }
        bool LoadResult { get;}
    }
}
