HybridStats is a simple 3 page app used to demonstrate the process of using Xamarin.Forms embedding to migrate from a Xamarin.Native application to Xamarin.Forms incrementally.

The main branch shows an example of the initial state of the Xamarin.iOS and Android application before introducing Xamrin.Forms

The "FormsPage" branch shows how the second page of the application can be effectivley swapped out while maintaining the existing ViewModel based navigation  pattern.

The process assumes that the MVVM arhicteure is used in the exitsing application with implementation thus allowing a clean seperation of concerns between the Views and the Service layer.
