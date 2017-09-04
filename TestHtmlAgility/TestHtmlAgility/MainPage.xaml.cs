using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestHtmlAgility {
    public partial class MainPage : ContentPage {
        //private MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage() {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        //protected override async void OnAppearing() {
        //    base.OnAppearing();
            
        //    if (ViewModel != null) {
        //        ViewModel.Testes();
        //    }
        //}
    }
}
