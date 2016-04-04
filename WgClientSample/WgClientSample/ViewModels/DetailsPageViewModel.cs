using WGClient.WorldOfTanks;

namespace WgClientSample.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        private string nickName;

        public string NickName
        {
            get { return nickName; }
            set
            {
                nickName = value;
                OnPropertyChanged();
            }
        }

        public void ApplyUser(ResponseWotAccountInfo user)
        {
            NickName = user.Nickname;
        }
    }
}