using System;
using System.Globalization;
using WgClientSample.Helper;
using WGClient.WorldOfTanks;

namespace WgClientSample.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        private string nickName;
        private string registrationDate;
        private string winRatePercentage;
        private string battlesCount;
        private string battleAvgXp;

        public string NickName
        {
            get { return nickName; }
            set
            {
                nickName = value;
                OnPropertyChanged();
            }
        }

        public string RegistrationDate
        {
            get { return registrationDate; }
            set
            {
                registrationDate = value;
                OnPropertyChanged();
            }
        }

        public string WinRatePercentage
        {
            get { return winRatePercentage; }
            set
            {
                winRatePercentage = value;
                OnPropertyChanged();
            }
        }

        public string BattlesCount
        {
            get { return battlesCount; }
            set
            {
                battlesCount = value;
                OnPropertyChanged();
            }
        }

        public string BattleAvgXp
        {
            get { return battleAvgXp; }
            set
            {
                battleAvgXp = value;
                OnPropertyChanged();
            }
        }

        public void ApplyUser(ResponseWotAccountInfo user)
        {
            var nfi = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 0 };
            
            NickName = user.Nickname;
            RegistrationDate = user.CreatedAt.HasValue
                ? ConverterHelper.UnixTimeStampToDateTime(user.CreatedAt.Value).ToString("dd-MM-yyyy"):string.Empty;
            WinRatePercentage = "";
            var statisticsAll = user.Statistics.All;
            if (statisticsAll.Battles!=null && statisticsAll.Battles.Value>0)
            {
                WinRatePercentage = ((double)statisticsAll.Wins*100f/(double)statisticsAll.Battles).ToString("00.00") + "%";
                BattlesCount = string.Format(nfi,"{0:n}",statisticsAll.Battles);

                BattleAvgXp = string.Format(nfi, "{0:n}", statisticsAll.BattleAvgXp);
            }
        }
    }
}