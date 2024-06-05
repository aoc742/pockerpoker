using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pockerpoker
{
    class GameModel : IGameplay
    {
        private List<PlayingCardModel> _deck = new List<PlayingCardModel>(); // 52 card deck
        private List<PlayingCardModel> _hand = new List<PlayingCardModel>(new PlayingCardModel[5]); // 5 card hand

        private Random rng = new Random();

        public event CardsUpdatedEventHandler? CardsUpdated;
        public event ScoreUpdatedEventHandler? ScoreUpdated;
        public event WinObtainedEventHandler? WinObtained;

        public GameModel()
        {
            // Create card deck
            for (int i = 1; i <= 52; i++)
            {
                this._deck.Add(new PlayingCardModel(i));
            }
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

        public void Deal()
        {
            this.Shuffle(this._deck);
            _hand[0] = _deck[0];
            _hand[1] = _deck[1];
            _hand[2] = _deck[2];
            _hand[3] = _deck[3];
            _hand[4] = _deck[4];

            CardsUpdated?.Invoke(this, new CardsUpdatedEventArgs()
            {
                NewCards = _hand
            });
        }

        public void Draw(IEnumerable<PlayingCardModel> cardsToDiscard)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            // TODO check for saved state. If exists, load it

            // Otherwise start a new game
        }
    }
}
