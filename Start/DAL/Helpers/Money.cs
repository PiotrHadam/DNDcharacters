using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Start.DAL.Helpers {
    class Money {
        private uint _copper;
        private uint _silver;
        private uint _electrum;
        private uint _gold;
        private uint _platinium;
        public uint Copper {
            get { return _copper; }
            set {
                SumAllToCopper();
                _copper += value;
                Calculate();
            }
        }
        public uint Silver {
            get { return _silver; }
            set {
                SumAllToCopper();
                _copper += value;
                Calculate();
            }
        }
        public uint Electrum {
            get { return _electrum; }
            set {
                SumAllToCopper();
                _copper += value;
                Calculate();
            }
        }
        public uint Gold {
            get { return _gold; }
            set {
                SumAllToCopper();
                _copper += value;
                Calculate();
            }
        }
        public uint Platinium {
            get { return _platinium; }
            set {
                SumAllToCopper();
                _copper += value;
                Calculate();
            }
        }

        public Money(uint copper) {
            _copper = copper;
            Calculate();
        }
        private void Calculate() {
            _platinium = _copper / 1000;
            _copper -= (_platinium * 1000);
            _gold = _copper / 1000;
            _copper -= (_gold * 100);
            _electrum = _copper / 50;
            _copper -= (_electrum * 50);
            _silver = _copper / 10;
            _copper -= (_silver * 10);
        }
        private void SumAllToCopper() {
            _copper += (_platinium * 1000) + (_gold * 100) + (_electrum * 50) + (_silver * 10);
            _platinium = 0;
            _electrum = 0;
            _gold = 0;
            _silver = 0;
        }
    }

}
