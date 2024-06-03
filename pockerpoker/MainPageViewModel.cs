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
        public MainPageViewModel() {
            Console.WriteLine("MainPgeViewModel loaded!");

            OnCounterClickedCommand = new Command(
                execute: () =>
                {
                    OnCounterClicked();
                },
                canExecute: () =>
                {
                    return true;
                });
        }

        private string _headline = string.Empty;
        public string Headline
        {
            get
            {
                return this._headline;
            }
            set
            {
                if (this._headline != value)
                {
                    this._headline = value;
                    OnPropertyChanged(nameof(Headline));
                }
            }
        }

        private string _counterBtn = "click me!";
        public string CounterBtn
        {
            get
            {
                return this._counterBtn;
            }
            set
            {
                if (this._counterBtn != value)
                {
                    this._counterBtn = value;
                    OnPropertyChanged(nameof(CounterBtn));
                }
            }
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

        int count = 0;
        public ICommand OnCounterClickedCommand { get; private set; }
        [RelayCommand]
        private void OnCounterClicked()
        {
            count++;

            if (count == 1)
                CounterBtn = $"Clicked {count} time";
            else
                CounterBtn = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn);
        }
    }
}
