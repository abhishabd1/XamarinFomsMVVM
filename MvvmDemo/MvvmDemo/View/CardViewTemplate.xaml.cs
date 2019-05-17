﻿using MvvmDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardViewTemplate : ContentView
    {
        public CardViewTemplate()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}