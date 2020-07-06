using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Start.DAL.Repositories
{
    using Encje;
    class RepositoryCharacters
    {
        #region ZAPYTANIA
        private const string ALL_CHARACTERS = "SELECT * FROM characters";
        private const string ADD_CHARACTER = "INSERT INTO characters (character_name, character_race, character_class, character_image_path, character_money, hit_points, charisma, constitution, dexterity, inteligence, stregth, wisdom, ability_acrobatics, ability_animal_handing, ability_arcana, ability_deception, ability_history, ability_insight, ability_intimidation, ability_investigation, ability_medicine, ability_nature, ability_perception, ability_performance, ability_persuasion, ability_religion, ability_sleight_of_hand, ability_stealh, ability_survival, known_spells_0, known_spells_1, known_spells_2, known_spells_3, known_spells_4, known_spells_5, known_spells_6, known_spells_7, known_spells_8, known_spells_9, known_spells_10, is_inspired, character_description, character_story, character_lvl) VALUES ";
        private const string DELETE_CHARACTER = "DELETE FROM characters WHERE character_id = ";
        #endregion

        #region Metody
        public static List<Character> ReadAllCharacters()
        {
            List<Character> characters = new List<Character>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_CHARACTERS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    characters.Add(new Character(reader));
                connection.Close();
            }
            return characters;
        }

        public static bool AddToDatabase(Character character)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_CHARACTER} {character.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                character.CharacterID = (byte)command.LastInsertedId;
                connection.Close();
            }
            return stan;
        }

        public static bool EditCharacter(Character character, byte characterID)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_CHARACTER = $"UPDATE characters SET character_name='{character.Name}', character_race={character.Race}, character_class={character.Clas}, character_image_path='{character.Image}', character_money={character.Money}, hit_points={character.HitPoints}, charisma={character.Charisma}, constitution={character.Constitution}, dexterity={character.Dexterity}, inteligence={character.Intelligence}, strength={character.Strength}, wisdom={character.Wisdom}, ability_acrobatics={character.A_Acrobatics}, ability_animal_handing={character.A_AnimalHanding}, ability_arcana={character.A_Arcana}, ability_athletics={character.A_Athletics}, ability_deception={character.A_Deception}, ability_history={character.A_History}, ability_insight={character.A_Insight}, ability_intimidation={character.A_Intimidation}, ability_investigation={character.A_Investigation}, ability_medicine={character.A_Medicine}, ability_nature={character.A_Nature}, ability_perception={character.A_Perception}, ability_performance={character.A_Performance}, ability_persuasion={character.A_Persuasion}, ability_religion={character.A_Religion}, ability_sleight_of_hand={character.A_SleightOfHand}, ability_stealh={character.A_Stealth}, ability_survival={character.A_Survival}, known_spells_0={character.KnownSpells0}, known_spells_1={character.KnownSpells1}, known_spells_2={character.KnownSpells2}, known_spells_3={character.KnownSpells3}, known_spells_4={character.KnownSpells4}, known_spells_5={character.KnownSpells5}, known_spells_6={character.KnownSpells6}, known_spells_7={character.KnownSpells7}, known_spells_8={character.KnownSpells8}, known_spells_9={character.KnownSpells9}, known_spells_10={character.KnownSpells10}, is_inspired={character.IsInspired}, character_description={character.Description}, character_story={character.Story}, character_lvl={character.Level} WHERE character_id={characterID}";

                MySqlCommand command = new MySqlCommand(EDIT_CHARACTER, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) stan = true;

                connection.Close();
            }
            return stan;
        }

        public static bool DeleteFromDatabase(Character character)
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE_CHARACTER} {character.ToDelete()}", connection);
                connection.Open();
                stan = true;
                connection.Close();
            }
            return stan;
        }

        #endregion
    }
}
