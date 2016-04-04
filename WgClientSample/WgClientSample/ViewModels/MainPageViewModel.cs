using System.Collections.Generic;
using System.Windows.Input;
using WGClient.Wargaming.NET;
using WGClient.WorldOfTanks;
using Xamarin.Forms;

namespace WgClientSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string searchNickname;
        private List<ResponseWgnAccountList> gamerAccounts;

        public string SearchNickname
        {
            get { return searchNickname; }
            set
            {
                searchNickname = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var client=new WGClient.Client();
                    var accounts=await client.SendRequestArray<ResponseWgnAccountList>(new RequestWotAccountList()
                    {
                        ApplicationId = "demo",
                        Search = SearchNickname
                    });
                    GamerAccounts = accounts;
                });
            }
        }

        public List<ResponseWgnAccountList> GamerAccounts
        {
            get { return gamerAccounts; }
            set
            {
                gamerAccounts = value;
                OnPropertyChanged();
            }
        }
    }
}