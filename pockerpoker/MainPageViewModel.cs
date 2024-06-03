using System;
using System.Collections.Generic;
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

        private int _card1 = 0;
        public int Card1
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

        private int _card2 = 0;
        public int Card2
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

        private int _card3 = 0;
        public int Card3
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

        private int _card4 = 0;
        public int Card4
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

        private int _card5 = 0;
        public int Card5
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
            Card1 = rng.Next(1, 52);
            Card2 = rng.Next(1, 52);
            Card3 = rng.Next(1, 52);
            Card4 = rng.Next(1, 52);
            Card5 = rng.Next(1, 52);
        }
    }
}
