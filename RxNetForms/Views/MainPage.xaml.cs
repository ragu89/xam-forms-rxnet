using System;
using System.ComponentModel;
using RxNetForms.ViewModels;
using RxNetForms.Views;
using Xamarin.Forms;

namespace RxNetForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private readonly GenericPage eventAsObservablePage;
        private readonly GenericPage dedicatedServiceAsObservablePage;

        public MainPage()
        {
            InitializeComponent();

            eventAsObservablePage = new GenericPage()
            {
                BindingContext = new EventAsObservableViewModel(),
                Title = item1.Text
            };
            dedicatedServiceAsObservablePage = new GenericPage()
            {
                BindingContext = new DedicatedServiceAsObservableViewModel(),
                Title = item2.Text
            };
        }

        void NavigateToPage1(object sender, EventArgs e)
        {
            Navigation.PushAsync(eventAsObservablePage);
        }

        void NavigateToPage2(object sender, EventArgs e)
        {
            Navigation.PushAsync(dedicatedServiceAsObservablePage);
        }
    }
}
