﻿using System;
using Windows.UI.Xaml.Controls;


namespace DoMeAFavor.Services
{
    public interface INavigationService
    {
        
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void GoBack();
    }
}
