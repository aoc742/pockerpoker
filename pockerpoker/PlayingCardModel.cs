using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pockerpoker
{
    public class PlayingCardModel 
    {
        // Maps Card IDs to Card Names
        private readonly Dictionary<int, string> CardNames = new Dictionary<int, string>()
        {
            // Clubs
            {1, "A ♣"},
            {2, "2 ♣"},
            {3, "3 ♣"},
            {4, "4 ♣"},
            {5, "5 ♣"},
            {6, "6 ♣"},
            {7, "7 ♣"},
            {8, "8 ♣"},
            {9, "9 ♣"},
            {10, "10 ♣"},
            {11, "J ♣"},
            {12, "Q ♣"},
            {13, "K ♣"},

            // Spades
            {14, "A ♠"},
            {15, "2 ♠"},
            {16, "3 ♠"},
            {17, "4 ♠"},
            {18, "5 ♠"},
            {19, "6 ♠"},
            {20, "7 ♠"},
            {21, "8 ♠"},
            {22, "9 ♠"},
            {23, "10 ♠"},
            {24, "J ♠"},
            {25, "Q ♠"},
            {26, "K ♠"},

            // Diamonds
            {27, "A ♦"},
            {28, "2 ♦"},
            {29, "3 ♦"},
            {30, "4 ♦"},
            {31, "5 ♦"},
            {32, "6 ♦"},
            {33, "7 ♦"},
            {34, "8 ♦"},
            {35, "9 ♦"},
            {36, "10 ♦"},
            {37, "J ♦"},
            {38, "Q ♦"},
            {39, "K ♦"},

            // Hearts
            {40, "A ♥"},
            {41, "2 ♥"},
            {42, "3 ♥"},
            {43, "4 ♥"},
            {44, "5 ♥"},
            {45, "6 ♥"},
            {46, "7 ♥"},
            {47, "8 ♥"},
            {48, "9 ♥"},
            {49, "10 ♥"},
            {50, "J ♥"},
            {51, "Q ♥"},
            {52, "K ♥"}
        };

        private int _id;
        private string _name;

        public PlayingCardModel(int cardId)
        {
            this._id = cardId;
            this._name= CardNames[cardId];
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
