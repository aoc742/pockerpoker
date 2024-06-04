using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;

namespace pockerpoker
{
    internal partial class MainPageViewModel : BaseViewModel
    {
        private Random rng = new Random();

        public MainPageViewModel() {
            // Create card deck
            for (int i = 1; i <= 52; i++)
            {
                this.Deck.Add(new PlayingCardViewModel(i));
            }

            this.OnDealDrawBtnCommand = new Command(
                execute: () =>
                {
                    OnDealDrawBtnClicked();
                },
                canExecute: () =>
                {
                    return true;
                });

            OnDealDrawBtnClicked(); // Trigger start of game
        }

        private PlayingCardViewModel _card1 = new PlayingCardViewModel(1);
        public PlayingCardViewModel Card1
        {
            get
            {
                return this._card1;
            }
            set
            {
                if (value != this._card1)
                {
                    this._card1 = value;
                    OnPropertyChanged(nameof(Card1));
                }
            }
        }

        private PlayingCardViewModel _card2 = new PlayingCardViewModel(1);
        public PlayingCardViewModel Card2
        {
            get
            {
                return this._card2;
            }
            set
            {
                if (value != this._card2)
                {
                    this._card2 = value;
                    OnPropertyChanged(nameof(Card2));
                }
            }
        }

        private PlayingCardViewModel _card3 = new PlayingCardViewModel(1);
        public PlayingCardViewModel Card3
        {
            get
            {
                return this._card3;
            }
            set
            {
                if (value != this._card3)
                {
                    this._card3 = value;
                    OnPropertyChanged(nameof(Card3));
                }
            }
        }

        private PlayingCardViewModel _card4 = new PlayingCardViewModel(1);
        public PlayingCardViewModel Card4
        {
            get
            {
                return this._card4;
            }
            set
            {
                if (value != this._card4)
                {
                    this._card4 = value;
                    OnPropertyChanged(nameof(Card4));
                }
            }
        }

        private PlayingCardViewModel _card5 = new PlayingCardViewModel(1);
        public PlayingCardViewModel Card5
        {
            get
            {
                return this._card5;
            }
            set
            {
                if (value != this._card5)
                {
                    this._card5 = value;
                    OnPropertyChanged(nameof(Card5));
                }
            }
        }

        private string _dealDrawBtn = "Deal / Draw";
        public string DealDrawBtn
        {
            get
            {
                return this._dealDrawBtn;
            }
            set
            {
                if (this._dealDrawBtn != value)
                {
                    this._dealDrawBtn = value;
                    OnPropertyChanged(nameof(DealDrawBtn));
                }
            }
        }

        public ObservableCollection<PlayingCardViewModel> Deck { get; set; } = new ObservableCollection<PlayingCardViewModel>();

        public ICommand OnDealDrawBtnCommand { get; private set; }
        [RelayCommand]
        private void OnDealDrawBtnClicked()
        {
            this.Shuffle<PlayingCardViewModel>(this.Deck);

            Card1 = this.Deck[0];
            Card2 = this.Deck[1];
            Card3 = this.Deck[2];
            Card4 = this.Deck[3];
            Card5 = this.Deck[4];
        }

        private void Shuffle<T>(IList<T> values)
        {
            int inputArrayLength = values.Count();

            for (int i = inputArrayLength - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = values[i];
                values[i] = values[j];
                values[j] = temp;
            }
        }
    }
}
