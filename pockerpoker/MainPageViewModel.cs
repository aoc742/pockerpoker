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
            _gameModel.ResultsObtained += _gameModel_WinObtained;
            _gameModel.GameOverTriggered += _gameModel_GameOverTriggered;

            _gameModel.Start();


            this.OnDealDrawBtnCommand = new Command(
                execute: () =>
                {
                    OnDealDrawBtnClicked();
                },
                canExecute: () =>
                {
                    return true;
                });

            this.HoldCard1BtnCommand = new RelayCommand(execute: () =>
            {
                HoldCard1BtnClicked();
            }, canExecute: () => { return !toggleDealDraw; });
            this.HoldCard2BtnCommand = new RelayCommand(execute: () =>
            {
                HoldCard2BtnClicked();
            }, canExecute: () => { return !toggleDealDraw; });
            this.HoldCard3BtnCommand = new RelayCommand(execute: () =>
            {
                HoldCard3BtnClicked();
            }, canExecute: () => { return !toggleDealDraw; });
            this.HoldCard4BtnCommand = new RelayCommand(execute: () =>
            {
                HoldCard4BtnClicked();
            }, canExecute: () => { return !toggleDealDraw; });
            this.HoldCard5BtnCommand = new RelayCommand(execute: () =>
            {
                HoldCard5BtnClicked();
            }, canExecute: () => { return !toggleDealDraw; });
        }

        private void _gameModel_GameOverTriggered(object? sender, EventArgs e)
        {
            GameOver = "Game Over";
            DealDrawBtn = "Start New Game";
        }

        private void _gameModel_WinObtained(object sender, ResultsObtainedEventArgs e)
        {
            WinLoss = e.WinLoss ? "Win: " + e.WinCondition.ToString() : "Loss";
        }

        private void _gameModel_ScoreUpdated(object sender, ScoreUpdatedEventArgs e)
        {
            this.Score = e.Score;
            if (e.ScoreChange > 0)
            {
                ScoreChange = $" (+{e.ScoreChange})";
            }
        }

        private void _gameModel_CardsUpdated(object sender, CardsUpdatedEventArgs e)
        {
            Card1 = new PlayingCardViewModel(e.NewCards.ToList()[0]);
            Card2 = new PlayingCardViewModel(e.NewCards.ToList()[1]);
            Card3 = new PlayingCardViewModel(e.NewCards.ToList()[2]);
            Card4 = new PlayingCardViewModel(e.NewCards.ToList()[3]);
            Card5 = new PlayingCardViewModel(e.NewCards.ToList()[4]);
        }

        private string _gameOver = string.Empty;
        public string GameOver
        {
            get
            {
                return _gameOver;
            }
            set
            {
                this._gameOver = value;
                OnPropertyChanged(nameof(GameOver));
            }
        }

        // Represents how much the score changes after a round
        private string _scoreChange = string.Empty;
        public string ScoreChange
        {
            get
            {
                return _scoreChange;
            }
            set
            {
                _scoreChange = value;
                OnPropertyChanged(nameof(ScoreChange));
            }
        }

        private string _winLoss = string.Empty;
        public string WinLoss
        {
            get
            {
                return _winLoss;
            }
            set
            {
                _winLoss = value;
                OnPropertyChanged(nameof(WinLoss));
            }
        }

        private int _score = 0;
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged(nameof(Score));
                }
            }
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

        private string _dealDrawBtn = "Start";
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

        private bool holdCard1 = false;
        public bool HoldCard1
        {
            get
            {
                return holdCard1;
            }
            set
            {
                holdCard1 = value;
                OnPropertyChanged(nameof(HoldCard1));
            }
        }
        public ICommand HoldCard1BtnCommand { get; private set; }
        private void HoldCard1BtnClicked()
        {
            HoldCard1 = !holdCard1;
        }
        private bool holdCard2 = false;
        public bool HoldCard2
        {
            get
            {
                return holdCard2;
            }
            set
            {
                holdCard2 = value;
                OnPropertyChanged(nameof(HoldCard2));
            }
        }

        public ICommand HoldCard2BtnCommand { get; private set; }
        private void HoldCard2BtnClicked()
        {
            HoldCard2 = !holdCard2;
        }
        private bool holdCard3 = false;
        public bool HoldCard3
        {
            get
            {
                return holdCard3;
            }
            set
            {
                holdCard3 = value;
                OnPropertyChanged(nameof(HoldCard3));
            }
        }

        public ICommand HoldCard3BtnCommand { get; private set; }
        private void HoldCard3BtnClicked()
        {
            HoldCard3 = !holdCard3;
        }
        private bool holdCard4 = false;
        public bool HoldCard4
        {
            get
            {
                return holdCard4;
            }
            set
            {
                holdCard4 = value;
                OnPropertyChanged(nameof(HoldCard4));
            }
        }

        public ICommand HoldCard4BtnCommand { get; private set; }
        private void HoldCard4BtnClicked()
        {
            HoldCard4 = !holdCard4;
        }
        private bool holdCard5 = false;
        public bool HoldCard5
        {
            get
            {
                return holdCard5;
            }
            set
            {
                holdCard5 = value;
                OnPropertyChanged(nameof(HoldCard5));
            }
        }
        public ICommand HoldCard5BtnCommand { get; private set; }
        private void HoldCard5BtnClicked()
        {
            HoldCard5 = !holdCard5;
        }

        private bool toggleDealDraw = true;
        public ICommand OnDealDrawBtnCommand { get; private set; }
        [RelayCommand]
        private void OnDealDrawBtnClicked()
        {
            GameOver = string.Empty;

            if (toggleDealDraw)
            {
                _gameModel.Deal();
                DealDrawBtn = "Draw";
                WinLoss = "";
                ScoreChange = "";
            }
            else
            {
                List<int> cardsToDiscard = new List<int>();
                if (!holdCard1) cardsToDiscard.Add(0);
                if (!holdCard2) cardsToDiscard.Add(1);
                if (!holdCard3) cardsToDiscard.Add(2);
                if (!holdCard4) cardsToDiscard.Add(3);
                if (!holdCard5) cardsToDiscard.Add(4);
                _gameModel.Draw(cardsToDiscard);
                DealDrawBtn = "Deal";
                HoldCard1 = HoldCard2 = HoldCard3 = HoldCard4 = HoldCard5 = false;
            }
            toggleDealDraw = !toggleDealDraw;
            ((RelayCommand)HoldCard1BtnCommand).NotifyCanExecuteChanged();
            ((RelayCommand)HoldCard2BtnCommand).NotifyCanExecuteChanged();
            ((RelayCommand)HoldCard3BtnCommand).NotifyCanExecuteChanged();
            ((RelayCommand)HoldCard4BtnCommand).NotifyCanExecuteChanged();
            ((RelayCommand)HoldCard5BtnCommand).NotifyCanExecuteChanged();
        }
    }
}
