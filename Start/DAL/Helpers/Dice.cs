using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Helpers {
    public class Dice {
        private byte[] _dice;

        /// <summary>
        /// Tworzymy kostkę z dwóch jej parametrów 1 to ilość rzutów, drugi to rozmair kostki 
        /// </summary>
        /// <param name="dice_amount">dmg_dice w bazie, oznacza ilość rzutów</param>
        /// <param name="dice_size">dmg_dice_size w bazie, oznacza wielkość kostki</param>
        public byte Amount { get { return _dice[0]; } }
        public byte Size { get { return _dice[1]; } }
        public Dice(byte dice_amount, byte dice_size) {
            _dice = new byte[2];
            _dice[0] = dice_amount;
            _dice[1] = dice_size;

        }
        public Dice(byte dice_size) {
            _dice = new byte[2];
            _dice[0] = 1;
            _dice[1] = dice_size;
        }
        public Dice(string example) {
            try {
                string[] exam = example.Trim().Split('d');
                _dice[0] = Convert.ToByte(exam[0]);
                _dice[1] = Convert.ToByte(exam[1]);
            }
            catch {
                _dice[0] = 1;
                _dice[1] = 4;
            }
        }
        public void EditDiceSize(byte newSize) {
            _dice[1] = newSize;
        }
        public void EditDiceAmount(byte newAmount) {
            _dice[0] = newAmount;
        }
        public override string ToString() {
            return $"{_dice[0]}d{_dice[1]}";
        }

        public override bool Equals(object obj) {
            return obj is Dice dice &&
                   EqualityComparer<byte[]>.Default.Equals(_dice, dice._dice);
        }
        public override int GetHashCode() {
            return 1005566733 + EqualityComparer<byte[]>.Default.GetHashCode(_dice);
        }
    }
}
