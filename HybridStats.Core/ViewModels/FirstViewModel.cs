using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using HybridStats.Core.MVVM;

namespace HybridStats.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public override string Title { get => "First View Model"; }

        public ICommand SecondNavigateCommand { get; set; }

        public FirstViewModel()
        {
            SecondNavigateCommand = new Command(() => App.Navigation?.NavigateAsync<SecondViewModel>());
        }
    }
}
