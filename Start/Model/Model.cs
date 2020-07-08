using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Start.Model
{
    using DAL.Encje;
    using DAL.Repositories;


    class Model
    {
        #region Listy
        public static List<User> Users { get => RepositoryUsers.GetAllUsers(); }

        public ObservableCollection<Armor> Armors { get; set; } = new ObservableCollection<Armor>();
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<CharacterSpell> Links { get; set; } = new ObservableCollection<CharacterSpell>();
        public ObservableCollection<Class> Classes { get; set; } = new ObservableCollection<Class>();
        public ObservableCollection<string> ClassNames { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Race> Races { get; set; } = new ObservableCollection<Race>();
        public ObservableCollection<string> RaceNames { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Spell> Spells { get; set; } = new ObservableCollection<Spell>();
        public ObservableCollection<Weapon> Weapons { get; set; } = new ObservableCollection<Weapon>();
        #endregion

        #region Konstruktor
        public Model()
        {
            var armors = RepositoryArmors.ReadAllArmors();
            foreach (var a in armors)
                Armors.Add(a);
            var characters = RepositoryCharacters.ReadAllCharacters();
            foreach (var c in characters)
                Characters.Add(c);
            var links = RepositoryCharacterSpells.ReadAllLinks();
            foreach (var l in links)
                Links.Add(l);
            var classes = RepositoryClases.ReadAllClases();
            foreach (var c in classes)
            {
                Classes.Add(c);
                ClassNames.Add(c.Name);
            }
            var items = RepositoryItems.ReadAllItems();
            foreach (var i in items)
                Items.Add(i);
            var races = RepositoryRaces.ReadAllRaces();
            foreach (var r in races)
            { 
                Races.Add(r);
                RaceNames.Add(r.Name);
            }
            var spells = RepositorySpells.ReadAllSpells();
            foreach (var s in spells)
                Spells.Add(s);
            var weapons = RepositoryWeapons.ReadAllWeapons();
            foreach (var w in weapons)
                Weapons.Add(w);
        }
        #endregion

        #region Złączenie postaci z zaklęciami
        private Spell FindSpellByID(ushort id)
        {
            foreach (var s in Spells)
            {
                if (s.SpellID == id)
                    return s;
            }
            return null;
        }

        public ObservableCollection<Spell> ReadSpellsOfCharacter(Character character)
        {
            var spells = new ObservableCollection<Spell>();
            foreach (var link in Links)
            {
                if (link.CharacterID == character.CharacterID)
                {
                    spells.Add(FindSpellByID(link.SpellID));
                }
            }

            return spells;
        }
        #endregion
        /*
        #region Złączenie postaci z klasą
        private Class FindClassByID(byte id)
        {
            foreach (var c in Classes)
            {
                if (c.ClassID == id)
                    return c;
            }
            return null;
        }

        public Class ReadClassOfCharacter(Character character)
        {
            var clas = new Class();
            foreach (var c in Classes)
            {
                if (c.ClassID == character.Class.ClassID)
                {
                    clas = FindClassByID(clas.ClassID);
                }
            }
            return clas;
        }
        #endregion

        #region Złączenie postaci z rasą
        private Race FindRaceByID(byte id)
        {
            foreach (var r in Races)
            {
                if (r.RaceID == id)
                    return r;
            }
            return null;
        }

        public Race ReadRaceOfCharacter(Character character)
        {
            var race = new Race();
            foreach (var r in Races)
            {
                if (r.RaceID == character.Race.RaceID)
                {
                    race = FindRaceByID(race.RaceID);
                }
            }
            return race;
        }
        #endregion
        
        #region Złączenie postaci z przedmiotami
        private Item FindItemByID(byte? id)
        {
            foreach (var i in Items)
            {
                if (i.ItemID == id)
                    return i;
            }
            return null;
        }

        public ObservableCollection<Item> ReadItemsOfCharacter(Character character)
        {
            var items = new ObservableCollection<Item>();
            foreach (var item in Items)
            {
                if (item.CharacterID == character.CharacterID)
                {
                    items.Add(FindItemByID(item.ItemID));
                }
            }
            return items;
        }
        #endregion

        #region Złączenie postaci z broniami
        private Weapon FindWeaponByID(byte? id)
        {
            foreach (var w in Weapons)
            {
                if (w.WeaponID == id)
                    return w;
            }
            return null;
        }

        public ObservableCollection<Weapon> ReadWeaponsOfCharacter(Character character)
        {
            var weapons = new ObservableCollection<Weapon>();
            foreach (var weapon in Weapons)
            {
                if (weapon.CharacterID == character.CharacterID)
                {
                    weapons.Add(FindWeaponByID(weapon.WeaponID));
                }
            }
            return weapons;
        }
        #endregion

        #region Złączenie postaci z pancerzem
        private Armor FindArmorByID(byte? id)
        {
            foreach (var a in Armors)
            {
                if (a.ArmorID == id)
                    return a;
            }
            return null;
        }

        public Armor ReadArmorOfCharacter(Character character)
        {
            var armor = new Armor();
            foreach (var a in Armors)
            {
                if (a.CharacterID == character.CharacterID)
                {
                    armor = FindArmorByID(a.ArmorID);
                }
            }
            return armor;
        }
        #endregion
        */
        #region Metody dla postaci
        public bool IsCharacterInRepository(Character character) => Characters.Contains(character);

        public bool AddCharacterToDatabase(Character character)
        {
            if (!IsCharacterInRepository(character))
            {
                if (RepositoryCharacters.AddToDatabase(character))
                {
                    Characters.Add(character);
                    return true;
                }
            }
            return false;
        }

        public bool EditCharacterInDatabase(Character character, ushort? characterID)
        {
            if (RepositoryCharacters.EditCharacter(character, characterID))
            {
                for (int i = 0; i < Characters.Count; i++)
                {
                    if (Characters[i].CharacterID == characterID)
                    {
                        character.CharacterID = characterID;
                        Characters[i] = new Character(character);
                    }
                }
                return true;
            }
            return false;
        }

        public bool DeleteCharacterFromDatabase(Character character)
        {
            if (RepositoryCharacters.DeleteFromDatabase(character))
            {
                for (int i = 0; i < Characters.Count; i++)
                {
                    if (Characters[i].CharacterID == character.CharacterID)
                    {
                        Characters.Remove(Characters[i]);
                    }
                }
                for (int i = 0; i < Links.Count; i++)
                {
                    if (Links[i].CharacterID == character.CharacterID)
                    {
                        Links.Remove(Links[i]);
                        i--;
                    }
                }
                for (int i = 0; i < Armors.Count; i++)
                {
                    if (Armors[i].CharacterID == character.CharacterID)
                    {
                        Armors.Remove(Armors[i]);
                    }
                }
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].CharacterID == character.CharacterID)
                    {
                        Items.Remove(Items[i]);
                        i--;
                    }
                }
                for (int i = 0; i < Weapons.Count; i++)
                {
                    if (Weapons[i].CharacterID == character.CharacterID)
                    {
                        Weapons.Remove(Weapons[i]);
                        i--;
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Metody dla przedmiotów
        public bool IsItemInRepository(Item item) => Items.Contains(item);

        public bool AddItemToDatabase(Item item)
        {
            if (!IsItemInRepository(item))
            {
                if (RepositoryItems.AddToDatabase(item))
                {
                    Items.Add(item);
                    return true;
                }
            }
            return false;
        }

        public bool EditItemInDatabase(Item item, ushort? itemID)
        {
            if (RepositoryItems.EditItem(item, itemID))
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].ItemID == itemID)
                    {
                        item.ItemID = itemID;
                        Items[i] = new Item(item);
                    }
                }
                return true;
            }
            return false;
        }

        public bool DeleteItemFromDatabase(Item item)
        {
            if (RepositoryItems.DeleteFromDatabase(item))
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].ItemID == item.ItemID)
                    {
                        Items.Remove(Items[i]);
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Metody dla pancerza
        public bool IsArmorInRepository(Armor armor) => Armors.Contains(armor);

        public bool AddArmorToDatabase(Armor armor)
        {
            if (!IsArmorInRepository(armor))
            {
                if (RepositoryArmors.AddToDatabase(armor))
                {
                    Armors.Add(armor);
                    return true;
                }
            }
            return false;
        }

        public bool EditArmorInDatabase(Armor armor, ushort? armorID)
        {
            if (RepositoryArmors.EditArmor(armor, armorID))
            {
                for (int i = 0; i < Armors.Count; i++)
                {
                    if (Armors[i].ArmorID == armorID)
                    {
                        armor.ArmorID = armorID;
                        Armors[i] = new Armor(armor);
                    }
                }
                return true;
            }
            return false;
        }

        public bool DeleteArmorFromDatabase(Armor armor)
        {
            if (RepositoryArmors.DeleteFromDatabase(armor))
            {
                for (int i = 0; i < Armors.Count; i++)
                {
                    if (Armors[i].ArmorID == armor.ArmorID)
                    {
                        Armors.Remove(Armors[i]);
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Metody dla broni
        public bool IsWeaponInRepository(Weapon weapon) => Weapons.Contains(weapon);

        public bool AddWeaponToDatabase(Weapon weapon)
        {
            if (!IsWeaponInRepository(weapon))
            {
                if (RepositoryWeapons.AddToDatabase(weapon))
                {
                    Weapons.Add(weapon);
                    return true;
                }
            }
            return false;
        }

        public bool EditWeaponInDatabase(Weapon weapon, ushort? weaponID)
        {
            if (RepositoryWeapons.EditWeapon(weapon, weaponID))
            {
                for (int i = 0; i < Weapons.Count; i++)
                {
                    if (Weapons[i].WeaponID == weaponID)
                    {
                        weapon.WeaponID = weaponID;
                        Weapons[i] = new Weapon(weapon);
                    }
                }
                return true;
            }
            return false;
        }

        public bool DeleteWeaponFromDatabase(Weapon weapon)
        {
            if (RepositoryWeapons.DeleteFromDatabase(weapon))
            {
                for (int i = 0; i < Weapons.Count; i++)
                {
                    if (Weapons[i].WeaponID == weapon.WeaponID)
                    {
                        Weapons.Remove(Weapons[i]);
                    }
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Metody dla połączeń postaci z zaklęciami
        public bool IsLinkInRepository(CharacterSpell link) => Links.Contains(link);

        public bool AddLinkToDatabase(CharacterSpell link)
        {
            if (!IsLinkInRepository(link))
            {
                if (RepositoryCharacterSpells.AddToDatabase(link))
                {
                    Links.Add(link);
                    return true;
                }
            }
            return false;
        }

        public bool EditLinkInDatabase(CharacterSpell link, ushort? linkID)
        {
            if (RepositoryCharacterSpells.EditLink(link, linkID))
            {
                for (int i = 0; i < Links.Count; i++)
                {
                    if (Links[i].LinkID == linkID)
                    {
                        link.LinkID = linkID;
                        Links[i] = new CharacterSpell(link);
                    }
                }
                return true;
            }
            return false;
        }

        public bool DeleteLinkFromDatabase(CharacterSpell link)
        {
            if (RepositoryCharacterSpells.DeleteFromDatabase(link))
            {
                for (int i = 0; i < Links.Count; i++)
                {
                    if (Links[i].LinkID == link.LinkID)
                    {
                        Links.Remove(Links[i]);
                    }
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
