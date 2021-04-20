using HybridStats.Core.ViewModels;
using System.Threading.Tasks;

namespace HybridStats.Core.Services
{
    public interface INavigationService
    {
        Task GoBack();
        Task NavigateAsync<T>() where T : BaseViewModel;
    }
}
