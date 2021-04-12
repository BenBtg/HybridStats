using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HybridStats.Core.ViewModels;

namespace HybridStats.Core
{
    public abstract class BaseViewModel : BaseNotifyPropertyChanged
    {

        public virtual string Title { get; set; }

        bool _isBusy;

        /// <summary>
        /// Gets or sets whether the ViewModel is busy.
        /// </summary>
        /// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (RaiseAndUpdate(ref _isBusy, value))
                    Raise(nameof(IsNotBusy));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the ViewModel is not busy.
        /// </summary>
        /// <value><c>true</c> if is not busy; otherwise, <c>false</c>.</value>
        public bool IsNotBusy => !IsBusy;

        /// <summary>
        /// Initialilzes the ViewModel.
        /// </summary>
        /// <returns>Task with result.</returns>
        public virtual Task InitAsync() => Task.FromResult(true);

    }
}
