using Start.DAL.Encje;
using System.Collections.Generic;

namespace Start.DAL.Helpers
{
    interface ICharacterSheet
    {
        #region Main things
        string Name { get; set; }
        ushort CurrentHitPoints { get; set; }
        string Class { get; set; }
        ushort MaxHitPoints { get; set; }
        ushort ArmorClass { get; set; }
        ushort ProficencyBonus { get; set; }
        bool IsInspired { get; set; }
        #endregion

        #region atributes, abilities, saving throws
        ushort Strenght { get; set; }
        ushort Dexterity { get; set; }
        ushort Constitution { get; set; }
        ushort Inteligence { get; set; }
        ushort Wisdom { get; set; }
        ushort Charisma { get; set; }
        Dictionary<string, ushort> Abilities { get; set; }
        Dictionary<string, ushort> SavingThrows { get; set; }
        #endregion

        #region equipment
        Weapon Weapon1 { get; set; }
        Weapon Weapon2 { get; set; }
        Weapon Weapon3 { get; set; }
        Armor Armor { get; set; }
        Armor Shield { get; set; }
        List<Item> OtherEquipment { get; set; }
        #endregion

        #region text descriptions etc
        string Description { get; set; }
        string CharacterStory { get; set; }
        #endregion
    }
}
