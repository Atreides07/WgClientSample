using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WgClientSample.ViewModels;
using WGClient;
using WGClient.Wargaming.NET;
using WGClient.WorldOfTanks;
using Xamarin.Forms;

namespace WgClientSample.Views
{
    public partial class DetailsPageView : ContentPage
    {
        private readonly string accountId;

        public DetailsPageView(long? accountId)
        {
            this.accountId = accountId.ToString();
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this,false);
            this.BindingContext=new DetailsPageViewModel();
            this.Padding=new Thickness(0,0,0,0);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var client=new Client();
            var response=await client.SendRequestDictionary<ResponseWotAccountInfo>(new RequestWotAccountInfo()
            {
                ApplicationId = "demo",
                AccountId = accountId
            });

            if (response.Any())
            {
                var user = response.Values.First();
                ((DetailsPageViewModel) this.BindingContext).ApplyUser(user);
            }
        }
        
    }
}
