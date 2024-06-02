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
