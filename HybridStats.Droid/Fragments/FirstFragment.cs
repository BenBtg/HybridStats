using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using HybridStats.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HybridStats.Droid.Fragments
{
    public class FirstFragment : BaseFragment<FirstViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.first_fragment_layout, container, false);
            var nextButton = (Button)view.FindViewById(Resource.Id.nextPageButton);

            nextButton.Click += (s, e) => { ViewModel.SecondNavigateCommand.Execute(null); };
                
                //(() => { ViewModel.SecondNavigateCommand.Execute(null)});
            // this.Set = (TextView)view.FindViewById(Resource.Id.textView1);

            //ViewModel.WatchProperty(nameof(SecondViewModel.UserName), UserNameChanged);


            return view;
        }

        void UserNameChanged()
        {
            //textView.Text = ViewModel.Title;
        }
    }
}