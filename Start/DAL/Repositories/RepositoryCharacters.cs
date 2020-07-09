using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryCharacters
    {
        public static ushort ID { get; set; }
        #region ZAPYTANIA
        private const string ALL_CHARACTERS = "SELECT * FROM `characters`";
        private const string ADD_CHARACTER = "INSERT INTO `characters` (character_name, character_race, character_class, character_image_path, character_money, hit_points, charisma, constitution, dexterity, inteligence, stregth, wisdom, ability_acrobatics, ability_animal_handing, ability_arcana, ability_athletics, ability_deception, ability_history, ability_insight, ability_intimidation, ability_investigation, ability_medicine, ability_nature, ability_perception, ability_performance, ability_persuasion, ability_religion, ability_sleight_of_hand, ability_stealh, ability_survival, known_spells_0, known_spells_1, known_spells_2, known_spells_3, known_spells_4, known_spells_5, known_spells_6, known_spells_7, known_spells_8, known_spells_9, is_inpired, character_description, character_story, character_lvl) VALUES ";
        private const string DELETE_CHARACTER = "DELETE FROM characters WHERE character_id = ";
        #endregion

        #region Metody
        public static List<Character> ReadAllCharacters()
        {
            List<Character> characters = new List<Character>();
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand command = new MySqlCommand(ALL_CHARACTERS, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        characters.Add(new Character(reader));
                    connection.Close();
                }
            }
            catch { }
            return characters;
        }

        public static bool AddToDatabase(Character character)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    //MySqlCommand command = new MySqlCommand($"{ADD_CHARACTER} {character.ToInsert()}", connection);
                    MySqlCommand command = new MySqlCommand($"{character.ToInsert()}", connection);
                    connection.Open();
                    var id = command.ExecuteNonQuery();
                    state = true;
                    character.CharacterID = (ushort)command.LastInsertedId;
                    ID = (ushort)character.CharacterID;
                    connection.Close();
                }
            }
            catch { }
            return state;
        }

        public static bool EditCharacter(Character character, ushort? characterID)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    string EDIT_CHARACTER = $"UPDATE characters SET character_name='{character.Name}', character_race={character.Race.RaceID}, character_class={character.Class.ClassID}, character_image_path='{character.Image}', character_money={character.Money}, hit_points={character.HitPoints}, charisma={character.Charisma}, constitution={character.Constitution}, dexterity={character.Dexterity}, inteligence={character.Intelligence}, strength={character.Strength}, wisdom={character.Wisdom}, " +
                        $"ability_acrobatics={character.Abilities["acrobatics"]}, ability_animal_handing={character.Abilities["animalhanding"]}, ability_arcana={character.Abilities["arcana"]}, ability_athletics={character.Abilities["athletics"]}, ability_deception={character.Abilities["deception"]}, ability_history={character.Abilities["history"]}, ability_insight={character.Abilities["insight"]}, ability_intimidation={character.Abilities["intimidation"]}, ability_investigation={character.Abilities["investigation"]}, ability_medicine={character.Abilities["medicine"]}, ability_nature={character.Abilities["nature"]}, ability_perception={character.Abilities["perception"]}, " +
                        $"ability_performance={character.Abilities["performance"]}, ability_persuasion={character.Abilities["persuasion"]}, ability_religion={character.Abilities["religion"]}, ability_sleight_of_hand={character.Abilities["sleightOfHand"]}, ability_stealh={character.Abilities["stealth"]}, ability_survival={character.Abilities["survival"]}, known_spells_0={character.PossibleSpellsPerDay[1]}, known_spells_1={character.PossibleSpellsPerDay[2]}, known_spells_2={character.PossibleSpellsPerDay[3]}, known_spells_3={character.PossibleSpellsPerDay[4]}, known_spells_4={character.PossibleSpellsPerDay[5]}, known_spells_5={character.PossibleSpellsPerDay[6]}, known_spells_6={character.PossibleSpellsPerDay[7]}, known_spells_7={character.PossibleSpellsPerDay[8]}, known_spells_8={character.PossibleSpellsPerDay[9]}, known_spells_9={character.PossibleSpellsPerDay[10]}, is_inpired={character.IsInspired}, character_description={character.Description}, character_story={character.Story}, character_lvl={character.Level} WHERE character_id={characterID}";

                    MySqlCommand command = new MySqlCommand(EDIT_CHARACTER, connection);
                    connection.Open();
                    var n = command.ExecuteNonQuery();
                    if (n == 1) state = true;

                    connection.Close();
                }
            }
            catch { }
            return state;
        }

        public static bool DeleteFromDatabase(Character character)
        {
            bool state = false;
            try
            {
                using (var connection = DBConnection.Instance.Connection)
                {
                    MySqlCommand commanddeletecharacter = new MySqlCommand($"{DELETE_CHARACTER} {character.ToDelete()}", connection);
                    MySqlCommand commanddeletearmor = new MySqlCommand($"DELETE FROM `armors` WHERE character_id = {character.ToDelete()}", connection);
                    MySqlCommand commanddeleteitem = new MySqlCommand($"DELETE FROM `items` WHERE character_id = {character.ToDelete()}", connection);
                    MySqlCommand commanddeleteweapon = new MySqlCommand($"DELETE FROM `weapons` WHERE character_id = {character.ToDelete()}", connection);
                    MySqlCommand commanddeletelink = new MySqlCommand($"DELETE FROM `character_spells` WHERE character_id = {character.ToDelete()}", connection);
                    connection.Open();
                    commanddeletearmor.ExecuteNonQuery();
                    commanddeleteitem.ExecuteNonQuery();
                    commanddeletelink.ExecuteNonQuery();
                    commanddeleteweapon.ExecuteNonQuery();
                    commanddeletecharacter.ExecuteNonQuery();
                    state = true;
                    connection.Close();
                }
            }
            catch { }
            return state;
        }

        #endregion
    }
}
