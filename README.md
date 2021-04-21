# HybridStats
HybridStats is a simple 3 page app used to demonstrate a process of incrementally migrating to Xamarin.Forms from an existing Xamarin.Native application with the help of  Xamarin.Forms embedding.

The app simply allows you to navigate to the next page via a centered button that uses a command binding to a ViewModel for each page. 

The main branch shows an example of the initial state of the Xamarin.iOS and Android application before introducing Xamrin.Forms

The "FormsPage" branch shows how the second page of the application can be effectivley swapped out while maintaining the existing ViewModel based navigation  pattern.

The process assumes that the MVVM arhicteure is used in the exitsing application with implementation thus allowing a clean seperation of concerns between the Views and the Service layer.
