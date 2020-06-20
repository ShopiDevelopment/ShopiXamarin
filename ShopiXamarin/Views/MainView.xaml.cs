using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ShopiXamarin.Views
{
    public partial class MainView : TabbedPage
    {
        public static MainView Instance;
        public MainView()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}
