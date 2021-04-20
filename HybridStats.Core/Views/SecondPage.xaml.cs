using HybridStats.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HybridStats.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage: BasePage<SecondViewModel>
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ViewModel.NextPageCommand.Execute(null);
        }
    }
}