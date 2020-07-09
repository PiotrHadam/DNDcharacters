using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.ViewModel
{
    using BaseClasses;
    using DAL.Encje;
    using Model;
    using Start.DAL.Helpers;
    using Start.DAL.Repositories;
    using System.Windows.Input;

    class AddItemsViewModel : ViewModelBase
    {
        private Model model = null;
        private ushort char_id;
        private string itemname = "", itemdescription = "", armorname = "", armordescription = "", weaponname = "", attackrange = "", damagetype = "", weapondescription = "";
        private byte armorclassbonus = 0, dmgdice = 0, dmgdicesize = 0;
        private Dice dice;
        public AddItemsViewModel(Model model)
        {
            this.model = model;
            char_id = RepositoryCharacters.ID;
        }

        #region Własności
        public string ItemName
        {
            get { return itemname; }
            set
            {
                itemname = value;
                onPropertyChanged(nameof(ItemName));
            }
        }

        public string ItemDescription
        {
            get { return itemdescription; }
            set
            {
                itemdescription = value;
                onPropertyChanged(nameof(itemdescription));
            }
        }

        public string ArmorName
        {
            get { return armorname; }
            set
            {
                armorname = value;
                onPropertyChanged(nameof(ArmorName));
            }
        }

        public string ArmorDescription
        {
            get { return armordescription; }
            set
            {
                armordescription = value;
                onPropertyChanged(nameof(armordescription));
            }
        }

        public byte ArmorClassBonus
        {
            get { return armorclassbonus; }
            set
            {
                armorclassbonus = value;
                onPropertyChanged(nameof(armorclassbonus));
            }
        }

        public string WeaponName
        {
            get { return weaponname; }
            set
            {
                weaponname = value;
                onPropertyChanged(nameof(WeaponName));
            }
        }

        public string WeaponDescription
        {
            get { return weapondescription; }
            set
            {
                weapondescription = value;
                onPropertyChanged(nameof(WeaponDescription));
            }
        }

        public string AttackRange
        {
            get { return attackrange; }
            set
            {
                attackrange = value;
                onPropertyChanged(nameof(AttackRange));
            }
        }

        public string DamageType
        {
            get { return damagetype; }
            set
            {
                damagetype = value;
                onPropertyChanged(nameof(DamageType));
            }
        }

        public byte DmgDice
        {
            get { return dmgdice; }
            set
            {
                dmgdice = value;
                onPropertyChanged(nameof(dmgdice));
            }
        }

        public byte DmgDiceSize
        {
            get { return dmgdicesize; }
            set
            {
                dmgdicesize = value;
                onPropertyChanged(nameof(dmgdicesize));
            }
        }

        #endregion

        private void ClearItemSheet()
        {
            ItemName = "";
            ItemDescription = "";
        }

        private void ClearWeaponSheet()
        {
            WeaponName = "";
            WeaponDescription = "";
            AttackRange = "";
            DamageType = "";
            DmgDice = 0;
            DmgDiceSize = 0;
        }


        #region Polecenia
        private ICommand additem = null;
        public ICommand AddItem
        {
            get
            {
                if (additem == null)
                    additem = new RelayCommand(
                        arg =>
                        {
                            var item = new Item(char_id, ItemName, ItemDescription);
                            model.AddItemToDatabase(item);
                            ClearItemSheet();
                        },
                        arg => (ItemName != "") && (ItemDescription != ""));
                return additem;
            }
        }

        private ICommand additemnext = null;
        public ICommand AddItemNext
        {
            get
            {
                if (additemnext == null)
                    additemnext = new RelayCommand(
                        arg =>
                        {
                            var item = new Item(char_id, ItemName, ItemDescription);
                            model.AddItemToDatabase(item);
                        },
                        arg => (ItemName != "") && (ItemDescription != ""));
                return additemnext;
            }
        }

        private ICommand addarmornext = null;
        public ICommand AddArmorNext
        {
            get
            {
                if (addarmornext == null)
                    addarmornext = new RelayCommand(
                        arg =>
                        {
                            var armor = new Armor(char_id, ArmorName, ArmorClassBonus, ArmorDescription);
                            model.AddArmorToDatabase(armor);
                        },
                        arg => (ArmorName != "") && (ArmorDescription != ""));
                return addarmornext;
            }
        }

        private ICommand addweapon = null;
        public ICommand AddWeapon
        {
            get
            {
                if (addweapon == null)
                    addweapon = new RelayCommand(
                        arg =>
                        {
                            var weapon = new Weapon(char_id, weaponname, dmgdice, dmgdicesize, attackrange, damagetype, weapondescription);
                            model.AddWeaponToDatabase(weapon);
                            ClearWeaponSheet();
                        },
                        arg => (WeaponName != "") && (WeaponDescription != "") && (AttackRange != "") && (DamageType != ""));
                return addweapon;
            }
        }

        private ICommand addweaponnext = null;
        public ICommand AddWeaponNext
        {
            get
            {
                if (addweaponnext == null)
                    addweaponnext = new RelayCommand(
                        arg =>
                        {
                            var weapon = new Weapon(char_id, weaponname, dmgdice, dmgdicesize, attackrange, damagetype, weapondescription);
                            model.AddWeaponToDatabase(weapon);
                        },
                        arg => (WeaponName != "") && (WeaponDescription != "") && (AttackRange != "") && (DamageType != ""));
                return addweaponnext;
            }
        }
        #endregion
    }
}
