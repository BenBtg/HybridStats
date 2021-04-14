using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Input;
using HybridStats.Core.Services;
using HybridStats.Core.MVVM;

namespace HybridStats.Core
{
    public class SecondViewModel : BaseViewModel
    {
        private string userName;

        public ICommand NextPageCommand { get; private set; }

        public override string Title { get => "Second View Model";}

        public Timer Timer { get; set; }

        int count = 1;

        public override Task InitAsync()
        {
            NextPageCommand = new Command(() => App.Naviagtion?.NavigateAsync<ThirdViewModel>());

            UserName = $"Page 2 {count}";

            Timer = new Timer(5000);
            Timer.Elapsed += Timer_Elapsed;

            Timer.Start();

            return Task.CompletedTask;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            count++;

            UserName = $"Alex B {count}";
        }

        public string UserName { get => userName; set => RaiseAndUpdate(ref userName, value); }
    }
}
