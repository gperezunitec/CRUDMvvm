﻿using CRUDMvvm.Views;

namespace CRUDMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainView()));
        }
    }
}