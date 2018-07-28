using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Threading;

namespace DoMeAFavor.Services
{
    public sealed class NavigationService : INavigationService
    {
        public void Navigate(Type sourcePage)
        {
           DispatcherHelper.CheckBeginInvokeOnUI(() => 
            { 
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(sourcePage);
            });
        }

        public void Navigate(Type sourcePage, object parameter)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(sourcePage, parameter);
        }

        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            frame.GoBack();
        }
    }
}
