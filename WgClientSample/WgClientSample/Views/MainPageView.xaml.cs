using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WgClientSample.ViewModels;
using WGClient.Wargaming.NET;
using Xamarin.Forms;

namespace WgClientSample.Views
{
    public partial class MainPageView : ContentPage
    {
        public MainPageView()
        {
            InitializeComponent();
            BindingContext=new MainPageViewModel();
            //MyActivityIndicator.IsRunning = false;
            //MyActivityIndicator.IsVisible = false;

            NavigationPage.SetHasNavigationBar(this,false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //MyActivityIndicator.IsRunning = false;
            //MyActivityIndicator.IsVisible = false;
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = e.SelectedItem as ResponseWgnAccountList;
                Navigation.PushAsync(new DetailsPageView(item.AccountId));
                var listView = (ListView) sender;
                listView.SelectedItem = null;
            }
        }
    }
}
