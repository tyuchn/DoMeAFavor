using System;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using GalaSoft.MvvmLight.Threading;

namespace DoMeAFavor.Services
{
    public sealed class NavigationService : INavigationService
    {
        private Frame _frame;

        public void SetFrame(Frame currentFrame)
        {
            _frame = currentFrame;
        }



        public void Navigate(Type sourcePage)
        {
            DispatcherHelper.Initialize();
            DispatcherHelper.CheckBeginInvokeOnUI(() => 
            { 
            //var frame = (Frame)Window.Current.Content;
            _frame.Navigate(sourcePage);
            });
        } 

        public void Navigate(Type sourcePage, object parameter)
        {
            DispatcherHelper.Initialize();
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                var frame = (Frame)Window.Current.Content;
            frame.Navigate(sourcePage, parameter);
            });
        }

        public void GoBack()
        {
            DispatcherHelper.Initialize();
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                var frame = (Frame)Window.Current.Content;
            frame.GoBack();
            });
        }
    }
}
