using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollectionBinding
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                var model = new MainWindowModel();
                return new MainWindowViewModel(model);
            }
        }
    }
}
