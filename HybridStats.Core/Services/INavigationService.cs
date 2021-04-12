using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HybridStats.Core.Services
{
    public interface INavigationService
    {
        string CurrentPageKey { get; }

        Task NavigateAsync(BaseViewModel viewModel, bool animated = true);
        Task NavigateAsync(BaseViewModel viewModel, object parameter, bool animated = true);
    }
}
