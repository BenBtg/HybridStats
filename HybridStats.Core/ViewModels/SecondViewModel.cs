using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace HybridStats.Core
{
    public class SecondViewModel : BaseViewModel
    {
        private string userName;

        public override string Title { get => "Second View Model";}

        public Timer Timer { get; set; }

        int count = 1;

        public override Task InitAsync()
        {
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
