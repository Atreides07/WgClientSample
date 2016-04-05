using System;
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
        private bool isLoadData;

        public bool IsLoadData
        {
            get
            {
                return isLoadData;
            }
            set
            {
                isLoadData = value;
                OnPropertyChanged();
            }
        }

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
                    try
                    {
                        IsLoadData = true;
                        var client = new WGClient.Client();
                        var accounts = await client.SendRequestArray<ResponseWgnAccountList>(new RequestWotAccountList()
                        {
                            ApplicationId = "demo",
                            Search = SearchNickname
                        });
                        GamerAccounts = accounts;
                    }
                    catch (Exception exp)
                    {
                        await Application.Current.MainPage.DisplayAlert("error", exp.Message, "Ok");
                    }
                    finally
                    {
                        IsLoadData = false;
                    }
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