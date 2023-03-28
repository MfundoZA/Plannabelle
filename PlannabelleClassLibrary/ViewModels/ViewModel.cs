using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannabelleClassLibrary.ViewModels
{
    public class ViewModel
    {
        public static ViewModel CurrentInstance { get; set; }

        protected ViewModel()
        {

        }

        public static ViewModel GetSingletonInstance()
        {
            if (CurrentInstance == null)
            {
                CurrentInstance = new ViewModel();
            }

            return CurrentInstance;
        }
    }
}
