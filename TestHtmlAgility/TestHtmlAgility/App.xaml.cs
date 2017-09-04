using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TestHtmlAgility {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new TestHtmlAgility.MainPage();
        }

        protected override void OnStart() {}

        protected override void OnSleep() {}

        protected override void OnResume() {}
    }
}
