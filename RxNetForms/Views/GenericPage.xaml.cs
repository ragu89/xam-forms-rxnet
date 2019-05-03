using System;
using RxNetForms.ViewModels;
using Xamarin.Forms;

namespace RxNetForms.Views
{
    public partial class GenericPage : ContentPage
    {
        public GenericPage()
        {
            InitializeComponent();
        }

        void SubscribeButton_Clicked(object sender, EventArgs e)
        {
            (BindingContext as BaseViewModel).Subscribe();
        }

        void StopButton_Clicked(object sender, EventArgs e)
        {
            (BindingContext as BaseViewModel).Dispose();
        }
    }
}
