using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HotsScores.Hots;

namespace HotsScores.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IHotsApiService hotsApiService;
        private Hero[] heroes;
        private Talent[] talents;
        private Replay[] replays;

        private DateTime startDate;
        private DateTime endDate;
        private string playerBattleTag;

        public MainWindowViewModel(IHotsApiService hotsApiService)
        {
            this.hotsApiService = hotsApiService;
        }

        public async Task LoadHotsDataAsync()
        {
            try
            {
                var argumentsError = GetReplayArgumentsErrorStatus();
                if (String.IsNullOrEmpty(argumentsError))
                {
                    this.Replays = await hotsApiService.RequestReplaysAsync(this.StartDate, this.EndDate, this.PlayerBattleTag);
                    this.Heroes = await hotsApiService.RequestHeroesAsync();
                    this.Talents = await hotsApiService.RequestTalentsAsync();
                }
                else
                {
                    ShowErrorMessage(argumentsError);
                }
              
            }
            catch (Flurl.Http.FlurlHttpException e)
            {
                Console.Error.WriteLine("Could not fetch replays, request failed: " + e.Message);
            }
            catch (Newtonsoft.Json.JsonException e)
            {
                Console.Error.WriteLine("Could not fetch replays, JSON parsing error: " + e.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime StartDate
        {
            get => this.startDate;
            set
            {
                if (this.startDate != value)
                {
                    this.startDate = value;
                    OnPropertyChanged(nameof(this.StartDate));
                }
            }
        }

        public DateTime EndDate
        {
            get => this.endDate;
            set
            {
                if (this.endDate != value)
                {
                    this.endDate = value;
                    OnPropertyChanged(nameof(this.EndDate));
                }
            }
        }

        public string PlayerBattleTag
        {
            get => this.playerBattleTag;
            set
            {
                if (this.playerBattleTag != value)
                {
                    this.playerBattleTag = value;
                    OnPropertyChanged(nameof(this.PlayerBattleTag));
                }
            }
        }

        public IEnumerable<Hero> Heroes
        {
            get => this.heroes;
            private set {
                if (this.heroes != value)
                {
                    this.heroes = value.ToArray();
                }
            }
        }

        public IEnumerable<Talent> Talents
        {
            get => this.talents;
            private set
            {
                if (this.talents != value)
                {
                    this.talents = value.ToArray();
                }
            }
        }

        public IEnumerable<Replay> Replays
        {
            get => this.replays;
            private set
            {
                if (this.replays != value)
                {
                    this.replays = value.ToArray();
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string GetReplayArgumentsErrorStatus()
        {
            if (this.StartDate.Year < 2016)
            {
                return "StartDate should be after 2016";
            }

            if (this.EndDate.Year > 2017)
            {
                return "EndDate should not be after 2017";
            }

            if (this.StartDate > this.EndDate)
            {
                return "StartDate should be before EndDate";
            }

            if (String.IsNullOrEmpty(this.PlayerBattleTag))
            {
                return "Player's battle tag should not be empty";
            }

            return String.Empty;
        }

        private void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error");
        }
    }
}
