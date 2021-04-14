using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using HybridStats.Core.MVVM;

namespace HybridStats.Core
{
    public class FirstViewModel : BaseViewModel
    {
        public override string Title { get => "First View Model"; }

        public ICommand SecondNavigateCommand { get; set; }

        public FirstViewModel()
        {
            SecondNavigateCommand = new Command(SecondNavigate);
        }

        void SecondNavigate()
        {
            App.Naviagtion.NavigateAsync<SecondViewModel>();
        }
    }
}
