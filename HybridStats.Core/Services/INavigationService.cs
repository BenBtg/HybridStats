using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HybridStats.Core.Services
{
    public interface INavigationService
    {
        Task GoBack();
        Task NavigateAsync<T>() where T : BaseViewModel;
    }
}
