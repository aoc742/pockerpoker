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
        private int _score = 0;

        private Random rng = new Random();

        public event CardsUpdatedEventHandler? CardsUpdated;
        public event ScoreUpdatedEventHandler? ScoreUpdated;
        public event ResultsObtainedEventHandler? ResultsObtained;

        public GameModel()
        {
            // Create card deck
            for (int i = 1; i <= 52; i++)
            {
                this._deck.Add(new PlayingCardModel(i));
            }
        }

        private bool isRoyalFlush()
        {
            return false; 
        }

        private bool isStraightFlush()
        {
            return false;
        }

        private bool is4OfAKind()
        {  
            return false; 
        }

        private bool isFullHouse()
        {
            return true;
        }

        private bool isFlush()
        {
            return false;
        }

        private bool isStraight()
        {
            return false;
        }

        private bool is3OfAKind()
        {
            return false;
        }

        private bool is2Pair()
        {
            return false;
        }

        private bool isJacksOrBetter()
        {
            return false;
        }

        private int calculateScore()
        {
            if (isRoyalFlush())     return 5000;
            if (isStraightFlush())  return 250;
            if (is4OfAKind())       return 125;
            if (isFullHouse())      return 40;
            if (isFlush())          return 25;
            if (isStraight())       return 20;
            if (is3OfAKind())       return 15;
            if (is2Pair())          return 10;
            if (isJacksOrBetter())  return 5;
                                    return 0;
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
            // Upon dealing new hand, automatically bet 5 points for the user
            this._score -= 5;
            ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs(){
                Score = this._score,
                ScoreChange = 0
            });

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

        public void Draw(IEnumerable<int> indicesOfCardsToDiscard)
        {
            int nextDeckIndex = 5; // draw the next card in the shuffled deck
            foreach(int index in indicesOfCardsToDiscard)
            {
                _hand[index] = _deck[nextDeckIndex];
                ++nextDeckIndex;
            }

            CardsUpdated?.Invoke(this, new CardsUpdatedEventArgs()
            {
                NewCards = _hand
            });

            EndOfTurn();
        }

        public void EndOfTurn()
        {
            int scoreChange = calculateScore();
            this._score += scoreChange;

            ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs() { Score = _score, ScoreChange = scoreChange });

            // If not a winner
            ResultsObtained?.Invoke(this, new ResultsObtainedEventArgs()
            {
                WinLoss = scoreChange > 0,
            });

        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            // TODO check for saved state. If exists, load it

            // Otherwise start a new game
            this._score = 100; // Upon game over, add 100 points to the total to start over
            ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs() { Score = _score, ScoreChange = 0 });

        }
    }
}
