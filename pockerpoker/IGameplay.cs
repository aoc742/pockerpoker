using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pockerpoker
{
    public class ResultsObtainedEventArgs : EventArgs
    {
        public bool WinLoss { get; set; } // Win = True, Loss = False
        public IEnumerable<PlayingCardModel> WinningCards { get; set; } = new List<PlayingCardModel>();
    }

    public class CardsUpdatedEventArgs : EventArgs
    {
        public IEnumerable<PlayingCardModel> NewCards { get; set; } = new List<PlayingCardModel>();
    }

    public class ScoreUpdatedEventArgs : EventArgs
    {
        public int Score { get; set; }
        public int ScoreChange { get; set; }
    }

    public delegate void CardsUpdatedEventHandler(Object sender, CardsUpdatedEventArgs e);
    public delegate void ScoreUpdatedEventHandler(Object sender, ScoreUpdatedEventArgs e);
    public delegate void ResultsObtainedEventHandler(Object sender, ResultsObtainedEventArgs e);

    public interface IGameplay
    {
        public event CardsUpdatedEventHandler CardsUpdated;
        public event ScoreUpdatedEventHandler ScoreUpdated;
        public event ResultsObtainedEventHandler ResultsObtained;

        void Start();

        void Reset();

        // Deal a new set of 5 cards
        void Deal();

        // Discard selected cards, draw new cards
        void Draw(IEnumerable<int> indicesOfCardsToDiscard);
    }
}
