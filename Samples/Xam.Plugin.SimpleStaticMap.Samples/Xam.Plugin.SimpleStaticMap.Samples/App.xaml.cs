using System;
using Xam.Plugin.SimpleStaticMap.Samples;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xam.Plugin.SimpleStaticMap
{
   /// <summary>
   /// Sample app for SimpleStaticMap
   /// </summary>
   public partial class App : Application
   {
      /// <summary>
      /// Default constructor
      /// </summary>
      public App()
      {
         InitializeComponent();

         MainPage = new NavigationPage(new MainPage());
      }
   }
}
