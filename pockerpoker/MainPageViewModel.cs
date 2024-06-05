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
        private GameModel _gameModel;
        public MainPageViewModel() 
        {
            _gameModel = new GameModel();

            _gameModel.CardsUpdated += _gameModel_CardsUpdated;
            _gameModel.ScoreUpdated += _gameModel_ScoreUpdated;
            _gameModel.WinObtained += _gameModel_WinObtained;


            this.OnDealDrawBtnCommand = new Command(
                execute: () =>
                {
                    OnDealDrawBtnClicked();
                },
                canExecute: () =>
                {
                    return true;
                });


        }

        private void _gameModel_WinObtained(object sender, WinObtainedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _gameModel_ScoreUpdated(object sender, ScoreUpdatedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _gameModel_CardsUpdated(object sender, CardsUpdatedEventArgs e)
        {
            Card1 = new PlayingCardViewModel(e.NewCards.ToList()[0]);
            Card2 = new PlayingCardViewModel(e.NewCards.ToList()[1]);
            Card3 = new PlayingCardViewModel(e.NewCards.ToList()[2]);
            Card4 = new PlayingCardViewModel(e.NewCards.ToList()[3]);
            Card5 = new PlayingCardViewModel(e.NewCards.ToList()[4]);
        }

        private PlayingCardViewModel _card1 = new PlayingCardViewModel(new PlayingCardModel(1));
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

        private PlayingCardViewModel _card2 = new PlayingCardViewModel(new PlayingCardModel(2));
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

        private PlayingCardViewModel _card3 = new PlayingCardViewModel(new PlayingCardModel(3));
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

        private PlayingCardViewModel _card4 = new PlayingCardViewModel(new PlayingCardModel(4));
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

        private PlayingCardViewModel _card5 = new PlayingCardViewModel(new PlayingCardModel(5));
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

        public ICommand OnDealDrawBtnCommand { get; private set; }
        [RelayCommand]
        private void OnDealDrawBtnClicked()
        {
            _gameModel.Deal();
        }
    }
}
