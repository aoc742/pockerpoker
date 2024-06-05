using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pockerpoker
{
    public partial class PlayingCardViewModel : ObservableObject
    {
        private int _id;
        private string _name;
        public string Name { get { return _name; } }


        private Color _cardTextColor;
        public Color CardTextColor { get { return _cardTextColor; } }

        public PlayingCardViewModel(PlayingCardModel model)
        {
            this._name = model.GetName();
            this._id = model.GetId();
            this._cardTextColor = this._id <= 26 ? Colors.Black : Colors.Red;
        }
    }
}
