﻿using HybridStats.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HybridStats.Core.Views
{
    public abstract class BasePage<T> : ContentPage where T : BaseViewModel
    {
        public T ViewModel { get; set; }

        public BasePage()
        {
            ViewModel = Activator.CreateInstance(typeof(T)) as T;
            
            InitView();
        }

        public async virtual void InitView()
        {
            await ViewModel.InitAsync();
            BindingContext = ViewModel;

            Title = ViewModel.Title;
        }
    }
}