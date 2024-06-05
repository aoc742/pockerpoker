using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pockerpoker
{
    public class WinObtainedEventArgs : EventArgs
    {
        public IEnumerable<PlayingCardModel> WinningCards { get; set; } = new List<PlayingCardModel>();
    }

    public class CardsUpdatedEventArgs : EventArgs
    {
        public IEnumerable<PlayingCardModel> NewCards { get; set; } = new List<PlayingCardModel>();
    }

    public class ScoreUpdatedEventArgs : EventArgs
    {
        public int Score { get; set; }
    }

    public delegate void CardsUpdatedEventHandler(Object sender, CardsUpdatedEventArgs e);
    public delegate void ScoreUpdatedEventHandler(Object sender, ScoreUpdatedEventArgs e);
    public delegate void WinObtainedEventHandler(Object sender, WinObtainedEventArgs e);

    public interface IGameplay
    {
        public event CardsUpdatedEventHandler CardsUpdated;
        public event ScoreUpdatedEventHandler ScoreUpdated;
        public event WinObtainedEventHandler WinObtained;

        void Start();

        void Reset();

        // Deal a new set of 5 cards
        void Deal();

        // Discard selected cards, draw new cards
        void Draw(IEnumerable<PlayingCardModel> cardsToDiscard);
    }
}
