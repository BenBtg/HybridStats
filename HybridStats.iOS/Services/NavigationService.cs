﻿using System;
using System.Threading.Tasks;

namespace HybridStats.iOS.Services
{
    class NavigationService
    {
        public string CurrentPageKey => throw new NotImplementedException();

        public void Configure(string pageKey, Type pageType)
        {
            throw new NotImplementedException();
        }

        public Task GoBack()
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(string pageKey, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(string pageKey, object parameter, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public Task NavigateModalAsync(string pageKey, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public Task NavigateModalAsync(string pageKey, object parameter, bool animated = true)
        {
            throw new NotImplementedException();
        }
    }
}