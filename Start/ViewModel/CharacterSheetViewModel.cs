using Start.DAL.Encje;
using Start.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;



namespace Start.ViewModel
{

    using DAL.Encje;
    using BaseClasses;
    using Model;
    using Start.DAL.Helpers;
    using System.Diagnostics;

    class CharacterSheetViewModel : ViewModelBase
    {
        //private Model model = null;
        private Character _character = new Character();
        private Model _model = new Model();
        private List<Spell> _spells = new List<Spell>();


        public CharacterSheetViewModel()
        {
            //model = new Model();
            _character = ListOfCharactersViewModel.SelectedCharacter;
        }

        #region Właściwości


        public Character Character
        {
            get { return _character; }
            set
            {
                _character = value;
                onPropertyChanged(nameof(Character));
            }
        }

        public string Name
        {
            get { return _character.Name; }
            set
            {
                _character.Name = value;
                onPropertyChanged(nameof(Name));
            }
        }
        public string Class
        {
            get { return _character.Class.Name; }
            set
            {
                _character.Class.Name = value;
                onPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get { return _character.Description; }
            set
            {
                _character.Description = value;
                onPropertyChanged(nameof(Description));
            }
        }

        public string Story
        {
            get { return _character.Story; }
            set
            {
                _character.Story = value;
                onPropertyChanged(nameof(Story));
            }
        }

        public byte ArmorClass
        {
            get { return _character.ArmorClass; }
            set
            {
                _character.ArmorClass = value;
                onPropertyChanged(nameof(ArmorClass));
            }
        }

        public byte Speed
        {
            get { return _character.Speed; }
            set
            {
                _character.Speed = value;
                onPropertyChanged(nameof(Speed));
            }
        }
        public byte Proficiency
        {
            get { return _character.Proficiency; }
            set
            {
                _character.Proficiency = value;
                onPropertyChanged(nameof(Proficiency));
            }
        }
        public byte MaxHitPoints
        {
            get { return _character.MaxHitPoints; }
            set
            {
                _character.MaxHitPoints = value;
                onPropertyChanged(nameof(MaxHitPoints));
            }
        }



        public uint MoneyCopper
        {
            get { return _character.CHMoney.Copper; }
            set
            {
                _character.CHMoney.Copper = value;
                onPropertyChanged(nameof(MoneyCopper));
            }
        }
        public uint MoneySilver
        {
            get { return _character.CHMoney.Silver; }
            set
            {
                _character.CHMoney.Silver = value;
                onPropertyChanged(nameof(MoneySilver));
            }
        }

        public uint MoneyGold
        {
            get { return _character.CHMoney.Gold; }
            set
            {
                _character.CHMoney.Gold = value;
                onPropertyChanged(nameof(MoneyGold));
            }
        }
        public uint MoneyElectrum
        {
            get { return _character.CHMoney.Electrum; }
            set
            {
                _character.CHMoney.Electrum = value;
                onPropertyChanged(nameof(MoneyElectrum));
            }
        }
        public uint MoneyPlatinium
        {
            get { return _character.CHMoney.Platinium; }
            set
            {
                _character.CHMoney.Platinium = value;
                onPropertyChanged(nameof(MoneyPlatinium));
            }
        }

        public int HitPoints
        {
            get { return _character.HitPoints; }
            set
            {
                _character.HitPoints = value;
                onPropertyChanged(nameof(HitPoints));
            }
        }

        public byte Strength
        {
            get { return _character.Strength; }
            set
            {
                _character.Strength = value;
                onPropertyChanged(nameof(Strength));
            }
        }
        public byte StrengthBonus
        {
            get { return _character.StrengthBonus; }
            set
            {
                _character.StrengthBonus = value;
                onPropertyChanged(nameof(StrengthBonus));
            }
        }

        public List<Weapon> Weapons {
            get { return _character.Weapons; }
            set {                
                onPropertyChanged(nameof(Weapons));
            }
        }
        public List<Item> Equipment {
            get { return _character.Equipment; }
            set {
                onPropertyChanged(nameof(Equipment));
            }
        }

        public byte Dexterity
        {
            get { return _character.Dexterity; }
            set
            {
                _character.Dexterity = value;
                onPropertyChanged(nameof(Dexterity));
            }
        }
        public byte DexterityBonus
        {
            get { return _character.DexterityBonus; }
            set
            {
                _character.DexterityBonus = value;
                onPropertyChanged(nameof(DexterityBonus));
            }
        }
        public byte Constitution
        {
            get { return _character.Constitution; }
            set
            {
                _character.Constitution = value;
                onPropertyChanged(nameof(Constitution));
            }
        }
        public byte ConstitutionBonus
        {
            get { return _character.ConstitutionBonus; }
            set
            {
                _character.ConstitutionBonus = value;
                onPropertyChanged(nameof(ConstitutionBonus));
            }
        }

        public byte Intelligence
        {
            get { return _character.Intelligence; }
            set
            {
                _character.Intelligence = value;
                onPropertyChanged(nameof(Intelligence));
            }
        }
        public byte IntelligenceBonus
        {
            get { return _character.IntelligenceBonus; }
            set
            {
                _character.IntelligenceBonus = value;
                onPropertyChanged(nameof(IntelligenceBonus));
            }
        }

        public byte Wisdom
        {
            get { return _character.Wisdom; }
            set
            {
                _character.Wisdom = value;
                onPropertyChanged(nameof(Wisdom));
            }
        }
        public byte WisdomBonus
        {
            get { return _character.WisdomBonus; }
            set
            {
                _character.WisdomBonus = value;
                onPropertyChanged(nameof(WisdomBonus));
            }
        }


        public byte Charisma
        {
            get { return _character.Charisma; }
            set
            {
                _character.Charisma = value;
                onPropertyChanged(nameof(Charisma));
            }
        }
        public byte CharismaBonus
        {
            get { return _character.CharismaBonus; }
            set
            {
                _character.CharismaBonus = value;
                onPropertyChanged(nameof(CharismaBonus));
            }
        }

        public bool IsInspired
        {
            get { return _character.IsInspired; }
            set
            {
                _character.IsInspired = value;
                onPropertyChanged(nameof(IsInspired));
            }
        }

        public byte Level
        {
            get { return _character.Level; }
            set
            {
                _character.Level = value;
                onPropertyChanged(nameof(Level));
            }
        }

        public Dictionary<string, byte> Abilities
        {
            get { return _character.Abilities; }
            set
            {
                _character.Abilities = value;
                onPropertyChanged(nameof(Abilities));
            }
        }

        public Dictionary<byte, byte> PossibleSpellsPerDay
        {
            get { return _character.PossibleSpellsPerDay; }
            set
            {
                _character.PossibleSpellsPerDay = value;
                onPropertyChanged(nameof(PossibleSpellsPerDay));
            }
        }

        public List<Spell> Spells
        {
            get { _spells = _model.ReadSpellsOfCharacterToList(_character);
                return _spells;
            }
            set
            {
                _spells = value;
                onPropertyChanged(nameof(Spells));
            }
        }

        public byte Acrobatics
        {
            get { return _character.Abilities["acrobatics"]; }
            set
            {
                _character.Abilities["acrobatics"] = value;
                onPropertyChanged(nameof(Acrobatics));
            }
        }

        public byte AnimalHandling
        {
            get { return _character.Abilities["animal_handing"]; }
            set
            {
                _character.Abilities["animal_handing"] = value;
                onPropertyChanged(nameof(AnimalHandling));
            }
        }

        public byte Arcana
        {
            get { return _character.Abilities["arcana"]; }
            set
            {
                _character.Abilities["arcana"] = value;
                onPropertyChanged(nameof(Arcana));
            }
        }

        public byte Athletics
        {
            get { return _character.Abilities["athletics"]; }
            set
            {
                _character.Abilities["athletics"] = value;
                onPropertyChanged(nameof(Athletics));
            }
        }

        public byte Deception
        {
            get { return _character.Abilities["deception"]; }
            set
            {
                _character.Abilities["deception"] = value;
                onPropertyChanged(nameof(Deception));
            }
        }
        public byte History
        {
            get { return _character.Abilities["history"]; }
            set
            {
                _character.Abilities["history"] = value;
                onPropertyChanged(nameof(History));
            }
        }
        public byte Insight
        {
            get { return _character.Abilities["insight"]; }
            set
            {
                _character.Abilities["insight"] = value;
                onPropertyChanged(nameof(Insight));
            }
        }
        public byte Intimidation
        {
            get { return _character.Abilities["intimidation"]; }
            set
            {
                _character.Abilities["intimidation"] = value;
                onPropertyChanged(nameof(Intimidation));
            }
        }
        public byte Investigation
        {
            get { return _character.Abilities["investigation"]; }
            set
            {
                _character.Abilities["investigation"] = value;
                onPropertyChanged(nameof(Investigation));
            }
        }
        public byte Medicine
        {
            get { return _character.Abilities["medicine"]; }
            set
            {
                _character.Abilities["medicine"] = value;
                onPropertyChanged(nameof(Medicine));
            }
        }
        public byte Nature
        {
            get { return _character.Abilities["nature"]; }
            set
            {
                _character.Abilities["nature"] = value;
                onPropertyChanged(nameof(Nature));
            }
        }
        public byte Perception
        {
            get { return _character.Abilities["perception"]; }
            set
            {
                _character.Abilities["perception"] = value;
                onPropertyChanged(nameof(Perception));
            }
        }
        public byte Performance
        {
            get { return _character.Abilities["performance"]; }
            set
            {
                _character.Abilities["performance"] = value;
                onPropertyChanged(nameof(Performance));
            }
        }

        public byte Persuasion
        {
            get { return _character.Abilities["persuasion"]; }
            set
            {
                _character.Abilities["persuasion"] = value;
                onPropertyChanged(nameof(Persuasion));
            }
        }

        public byte Religion
        {
            get { return _character.Abilities["religion"]; }
            set
            {
                _character.Abilities["religion"] = value;
                onPropertyChanged(nameof(Religion));
            }
        }
        public byte SleightOfHand
        {
            get { return _character.Abilities["sleight_of_hand"]; }
            set
            {
                _character.Abilities["sleight_of_hand"] = value;
                onPropertyChanged(nameof(SleightOfHand));
            }
        }

        public byte Stealth
        {
            get { return _character.Abilities["stealh"]; }
            set
            {
                _character.Abilities["stealh"] = value;
                onPropertyChanged(nameof(Stealth));
            }
        }

        public byte Survival
        {
            get { return _character.Abilities["survival"]; }
            set
            {
                _character.Abilities["survival"] = value;
                onPropertyChanged(nameof(Survival));
            }
        }





        #endregion
    }
}