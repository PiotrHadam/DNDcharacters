using Start.DAL.Encje;
using Start.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;



namespace Start.ViewModel {
    
    using DAL.Encje;
    using BaseClasses;
    using Model;
    using System.Windows.Input;
    using System.Runtime.InteropServices;

    class CharacterSheetViewModel:ViewModelBase {
        private Model model = null;
        private Character _character = null;

        private string name, image, description, story;
        private int money = 0, hitpoints = 0;
        private byte strength = 0, dexterity = 0, constitution = 0, intelligence = 0, wisdom = 0, charisma = 0, isinspired = 0, level = 0;
        private Dictionary<string, byte> abilities;
        private Dictionary<byte, byte> possiblespellsperday;
        private bool editingAbility = true;

        public CharacterSheetViewModel(Character character) {
            _character = character;
        }

        #region Właściwości

        public Character Character {
            get { return _character; }
            set {
                _character = value;
                onPropertyChanged(nameof(Character));
            }
        }

        public string Name {
            get { return _character.Name; }
            set {
                _character.Name = value;
                onPropertyChanged(nameof(Name));
            }
        }

        public string Description {
            get { return _character.Description; }
            set {
                _character.Description = value;
                onPropertyChanged(nameof(Description));
            }
        }

        public string Story {
            get { return _character.Story; }
            set {
                _character.Story = value;
                onPropertyChanged(nameof(Story));
            }
        }

        public uint MoneyCopper {
            get { return _character.CHMoney.Copper; }
            set {
                _character.CHMoney.Copper = value;
                onPropertyChanged(nameof(MoneyCopper));
            }
        }
        public uint MoneySilver {
            get { return _character.CHMoney.Silver; }
            set {
                _character.CHMoney.Silver = value;
                onPropertyChanged(nameof(MoneySilver));
            }
        }

        public uint MoneyGold {
            get { return _character.CHMoney.Gold; }
            set {
                _character.CHMoney.Gold = value;
                onPropertyChanged(nameof(MoneyGold));
            }
        }
        public uint MoneyElectrum {
            get { return _character.CHMoney.Electrum; }
            set {
                _character.CHMoney.Electrum = value;
                onPropertyChanged(nameof(MoneyElectrum));
            }
        }
        public uint MoneyPlatinium {
            get { return _character.CHMoney.Platinium; }
            set {
                _character.CHMoney.Platinium = value;
                onPropertyChanged(nameof(MoneyPlatinium));
            }
        }

        public int HitPoints {
            get { return _character.HitPoints; }
            set {
                _character.HitPoints = value;
                onPropertyChanged(nameof(HitPoints));
            }
        }

        public byte Strength {
            get { return _character.Strength; }
            set {
                _character.Strength = value;
                onPropertyChanged(nameof(Strength));
            }
        }

        public byte Dexterity {
            get { return _character.Dexterity; }
            set {
                _character.Dexterity = value;
                onPropertyChanged(nameof(Dexterity));
            }
        }
        public byte Constitution {
            get { return _character.Constitution; }
            set {
                _character.Constitution = value;
                onPropertyChanged(nameof(Constitution));
            }
        }

        public byte Intelligence {
            get { return _character.Intelligence; }
            set {
                _character.Intelligence = value;
                onPropertyChanged(nameof(Intelligence));
            }
        }

        public byte Wisdom {
            get { return _character.Wisdom; }
            set {
                _character.Wisdom = value;
                onPropertyChanged(nameof(Wisdom));
            }
        }

        public byte Charisma {
            get { return _character.Charisma; }
            set {
                _character.Charisma = value;
                onPropertyChanged(nameof(Charisma));
            }
        }

        public byte IsInspired {
            get { return isinspired; }
            set {
                isinspired = value;
                onPropertyChanged(nameof(IsInspired));
            }
        }

        public byte Level {
            get { return level; }
            set {
                level = value;
                onPropertyChanged(nameof(Level));
            }
        }

        public Dictionary<string, byte> Abilities {
            get { return abilities; }
            set {
                abilities = value;
                onPropertyChanged(nameof(Abilities));
            }
        }

        public Dictionary<byte, byte> PossibleSpellsPerDay {
            get { return possiblespellsperday; }
            set {
                possiblespellsperday = value;
                onPropertyChanged(nameof(PossibleSpellsPerDay));
            }
        }

        public bool EditingAbility {
            get { return editingAbility; }
            set {
                editingAbility = value;
                onPropertyChanged(nameof(EditingAbility));
            }
        }
        #endregion
    }
}
