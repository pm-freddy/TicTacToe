using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class SaveData
    {
        private string _playerNameX;
        private string _playerNameO;
        private int _spielstandX;
        private int _spielstandO;
        private int _runde;

        public int SpielstandX
        {
            get { return _spielstandX; }
            set { _spielstandX = value; }
        }
        public int SpielstandO
        {
            get { return _spielstandO; }
            set { _spielstandO = value; }
        }

        public string PlayerNameX
        {
            get { return _playerNameX; }
            set { _playerNameX = value; }
        }
        public string PlayerNameO
        {
            get { return _playerNameO; }
            set { _playerNameO = value; }
        }

        public int Runde
        {
            get { return _runde; }
            set { _runde = value; }
        }
    }
}
