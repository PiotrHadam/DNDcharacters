-- MySQL dump 10.13  Distrib 5.5.21, for Win32 (x86)
--
-- Host: localhost    Database: dnd_characters
-- ------------------------------------------------------
-- Server version	5.5.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `armors`
--

DROP TABLE IF EXISTS `armors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `armors` (
  `armor_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `character_id` int(10) unsigned NOT NULL,
  `armor_name` char(20) DEFAULT NULL,
  `armor_class_bonus` tinyint(4) NOT NULL DEFAULT '1',
  `item_description` char(255) DEFAULT NULL,
  PRIMARY KEY (`armor_id`),
  KEY `character_id` (`character_id`),
  CONSTRAINT `armors_ibfk_1` FOREIGN KEY (`character_id`) REFERENCES `characters` (`character_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `armors`
--

LOCK TABLES `armors` WRITE;
/*!40000 ALTER TABLE `armors` DISABLE KEYS */;
INSERT INTO `armors` VALUES (1,1,'chainmail',4,'Light, chain mail created from black metal'),(6,2,'Zbroja skórzana',1,NULL),(8,3,'Zbroja plytowa',4,'Bardzo Ciężka'),(9,4,'casca',0,'ascwca');
/*!40000 ALTER TABLE `armors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `character_spells`
--

DROP TABLE IF EXISTS `character_spells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `character_spells` (
  `link_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `spell_id` int(10) unsigned NOT NULL,
  `character_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`link_id`),
  KEY `character_id` (`character_id`),
  KEY `spell_id` (`spell_id`),
  CONSTRAINT `character_spells_ibfk_1` FOREIGN KEY (`character_id`) REFERENCES `characters` (`character_id`),
  CONSTRAINT `character_spells_ibfk_2` FOREIGN KEY (`spell_id`) REFERENCES `spells` (`spell_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `character_spells`
--

LOCK TABLES `character_spells` WRITE;
/*!40000 ALTER TABLE `character_spells` DISABLE KEYS */;
INSERT INTO `character_spells` VALUES (1,4,1),(2,35,1),(3,95,1),(4,35,1),(5,36,1),(6,20,1),(7,94,1),(8,28,1),(9,13,1),(10,97,1);
/*!40000 ALTER TABLE `character_spells` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characters`
--

DROP TABLE IF EXISTS `characters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characters` (
  `character_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `character_name` char(20) NOT NULL,
  `character_race` int(10) unsigned NOT NULL,
  `character_class` int(10) unsigned NOT NULL,
  `character_image_path` char(50) DEFAULT NULL,
  `character_money` int(10) unsigned NOT NULL,
  `hit_points` int(10) unsigned NOT NULL,
  `charisma` tinyint(3) unsigned NOT NULL,
  `constitution` tinyint(3) unsigned NOT NULL,
  `dexterity` tinyint(3) unsigned NOT NULL,
  `inteligence` tinyint(3) unsigned NOT NULL,
  `stregth` tinyint(3) unsigned NOT NULL,
  `wisdom` tinyint(3) unsigned NOT NULL,
  `ability_acrobatics` tinyint(3) unsigned NOT NULL,
  `ability_animal_handing` tinyint(3) unsigned NOT NULL,
  `ability_arcana` tinyint(3) unsigned NOT NULL,
  `ability_athletics` tinyint(3) unsigned NOT NULL,
  `ability_deception` tinyint(3) unsigned NOT NULL,
  `ability_history` tinyint(3) unsigned NOT NULL,
  `ability_insight` tinyint(3) unsigned NOT NULL,
  `ability_intimidation` tinyint(3) unsigned NOT NULL,
  `ability_investigation` tinyint(3) unsigned NOT NULL,
  `ability_medicine` tinyint(3) unsigned NOT NULL,
  `ability_nature` tinyint(3) unsigned NOT NULL,
  `ability_perception` tinyint(3) unsigned NOT NULL,
  `ability_performance` tinyint(3) unsigned NOT NULL,
  `ability_persuasion` tinyint(3) unsigned NOT NULL,
  `ability_religion` tinyint(3) unsigned NOT NULL,
  `ability_sleight_of_hand` tinyint(3) unsigned NOT NULL,
  `ability_stealh` tinyint(3) unsigned NOT NULL,
  `ability_survival` tinyint(3) unsigned NOT NULL,
  `known_spells_0` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_1` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_2` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_3` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_4` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_5` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_6` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_7` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_8` tinyint(3) unsigned DEFAULT NULL,
  `known_spells_9` tinyint(3) unsigned DEFAULT NULL,
  `is_inpired` bit(1) NOT NULL DEFAULT b'0',
  `character_description` text,
  `character_story` text,
  `character_lvl` tinyint(3) unsigned NOT NULL DEFAULT '1',
  PRIMARY KEY (`character_id`),
  KEY `character_race` (`character_race`),
  KEY `character_class` (`character_class`),
  CONSTRAINT `characters_ibfk_1` FOREIGN KEY (`character_race`) REFERENCES `races` (`race_id`),
  CONSTRAINT `characters_ibfk_2` FOREIGN KEY (`character_class`) REFERENCES `classes` (`class_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characters`
--

LOCK TABLES `characters` WRITE;
/*!40000 ALTER TABLE `characters` DISABLE KEYS */;
INSERT INTO `characters` VALUES (1,'Guddi',2,3,NULL,200000,50,11,13,10,11,13,16,8,8,6,8,7,9,6,8,6,8,11,2,1,4,2,4,2,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','Bardzo Fajny i przyjazny krasnolud','Urodzil sie i chodzil po swiecie tu i tam',5),(2,'Jayne',3,8,NULL,40000,45,12,9,17,13,12,12,4,2,3,1,2,3,1,2,3,2,1,3,3,2,1,3,13,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','Mały, lecz bardzo zwinny, bardzo młodo wyglądający bez żadnego zarostu',NULL,1),(3,'Karim Lothas',1,2,NULL,4054200,56,12,16,8,12,16,12,2,0,5,3,1,4,2,4,4,2,2,3,11,15,10,12,12,13,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'\0','Wyglądający groźnie zarośnięty i nigdy nierozstający się ze swoim toporem',NULL,6),(4,'A',4,3,NULL,60500,100,2,30,1,1,5,3,5,0,13,0,0,0,52,0,0,0,0,20,0,0,0,31,0,21,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'','feac','av',14);
/*!40000 ALTER TABLE `characters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classes` (
  `class_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `class_name` char(20) NOT NULL,
  `primary_ability` char(20) NOT NULL,
  `save_throw_1` char(20) NOT NULL,
  `save_throw_2` char(20) NOT NULL,
  `have_spellcast_abiliy` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`class_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES (1,'Barbarian','Strength','Constitution','Strength','\0'),(2,'Bard','Charisma','Charisma','Desxterity',''),(3,'Cleric','Wisdom','Charisma','Wisdom',''),(4,'Druid','Wisdom','Wisdom','Intelligence',''),(5,'Fighter','Strength','Strength','Constitution','\0'),(6,'Monk','Dexterity','Dexterity','Strength','\0'),(7,'Paladin','Strength','Charisma','Wisdom',''),(8,'Ranger','Dexterity','Dexterity','Strength','\0'),(9,'Rogue','Dexterity','Dexterity','Intelligence','\0'),(10,'Sorcerer','Charisma','Charisma','Constitution',''),(11,'Warlock','Charisma','Charisma','Wisdom',''),(12,'Wizard','Intelligence','Intelligence','Wisdom','');
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `items` (
  `item_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `character_id` int(10) unsigned NOT NULL,
  `item_name` char(20) NOT NULL,
  `item_description` char(50) DEFAULT NULL,
  PRIMARY KEY (`item_id`),
  KEY `character_id` (`character_id`),
  CONSTRAINT `items_ibfk_1` FOREIGN KEY (`character_id`) REFERENCES `characters` (`character_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (8,1,'Swiece',NULL),(9,1,'Oficjalny Stroj kapl','Bardzo znoszony'),(10,2,'Naszyjnik ze szmarag','Widocznie bardzo cenny dla wlascicielki'),(11,3,'Tamburyno',NULL),(12,1,'Lina (15m)',NULL),(13,3,'Racja zywnosciowa (1',NULL),(14,4,'casva','acs');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `races`
--

DROP TABLE IF EXISTS `races`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `races` (
  `race_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `race_name` char(20) NOT NULL,
  `constitution_throw_bonus` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `charisa_throw_bonus` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `dexterity_bonus` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `inteligence_throw_bonus` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `stregth_throw_bonus` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `wisdom_throw_bonus` tinyint(3) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`race_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `races`
--

LOCK TABLES `races` WRITE;
/*!40000 ALTER TABLE `races` DISABLE KEYS */;
INSERT INTO `races` VALUES (1,'Drakon',0,1,0,0,2,0),(2,'Krasnolud',2,0,0,0,0,0),(3,'Elf',0,0,2,0,0,0),(4,'Gnom',0,0,1,0,0,0),(5,'Niziołek',0,0,2,0,0,0),(6,'Półork',1,0,0,0,2,0),(7,'Człowiek',1,1,1,1,1,1),(8,'Diabelstwo',0,2,0,1,0,0),(9,'Półelf',0,2,0,1,0,1);
/*!40000 ALTER TABLE `races` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spells`
--

DROP TABLE IF EXISTS `spells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spells` (
  `spell_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `spell_name` char(40) NOT NULL,
  `required_lvl` tinyint(3) unsigned NOT NULL,
  `domain` char(20) NOT NULL,
  `casting_time` char(20) NOT NULL,
  `spell_range` char(20) NOT NULL,
  `duration` char(20) NOT NULL,
  `damage` char(20) DEFAULT NULL,
  `is_bard_spell` bit(1) NOT NULL DEFAULT b'0',
  `is_cleric_spell` bit(1) NOT NULL DEFAULT b'0',
  `is_druid_spell` bit(1) NOT NULL DEFAULT b'0',
  `is_paladin_spell` bit(1) NOT NULL DEFAULT b'0',
  `is_ranger_spell` bit(1) NOT NULL DEFAULT b'0',
  `is_sorcerer_spell` bit(1) NOT NULL DEFAULT b'0',
  `is_warlock_spell` bit(1) NOT NULL DEFAULT b'0',
  `is_wizzard_spell` bit(1) NOT NULL DEFAULT b'0',
  `description` char(200) NOT NULL,
  PRIMARY KEY (`spell_id`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spells`
--

LOCK TABLES `spells` WRITE;
/*!40000 ALTER TABLE `spells` DISABLE KEYS */;
INSERT INTO `spells` VALUES (1,'Acid Splash',0,'Conjuration','1 Action','60 feet','Instantaneous','1d6','\0','\0','\0','\0','\0','','\0','','Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a Dexterity saving throw or take 1d6 acid damage.'),(2,'Blade Ward',0,'Abjuration','1 Action','Self','1 Round',NULL,'','\0','\0','\0','\0','','','','You extend your hand and trace a sigil of warding in the air. Until the end of your next turn, you have resistance against bludgeoning, piercing, and slashing damage dealt by weapon attacks.'),(3,'Chill Touch',0,'Necromancy','1 Action','120 feet','1 Round','1d8','\0','\0','\0','\0','\0','','','','You create a ghostly, skeletal hand in the space of a creature within range. On a hit, the target takes 1d8 necrotic damage, and it can’t regain hit points until the start of your next turn.'),(4,'Dancing Lights',0,'Evocation','1 Action','120 feet','Up to 1 minute',NULL,'','\0','\0','\0','\0','','\0','','You create up to four torch-sized lights within range, making them appear as torches, lanterns, or glowing orbs that hover in the air for the duration.'),(5,'Druidcraft',0,'Transmutation','1 Action','30 feet','Instantaneous',NULL,'\0','\0','','\0','\0','\0','\0','\0','You create a tiny, harmless sensory effect that predicts what the weather  or an effect such as falling leaves. You also can make a plant ripe or light and snuff out a candle.'),(6,'Eldritch Blast',0,'Evocation','1 Action','120 feet','Instantaneous','1d10','\0','\0','\0','\0','\0','\0','','\0','A beam of crackling energy streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 force damage.'),(7,'Fire Bolt',0,'Evocation','1 Action','120 feet','Instantaneous','1d10','\0','\0','\0','\0','\0','','\0','','You hurl a mote of fire at a creature or object within range. Make a ranged spell attack against the target. A flammable object hit by this spell ignites if it isn’t being worn or carried.'),(8,'Friends',0,'Enchantment','1 Action','Self','Up to 1 minute',NULL,'','\0','\0','\0','\0','','','','For the duration, you have advantage on all Charisma checks directed at one creature of your choice that isn’t hostile toward you.'),(9,'Guidance',0,'Divination','1 Action','Touch','Up to 1 minute',NULL,'\0','','','\0','\0','\0','\0','\0','You touch one willing creature. Once before the spell ends, the target can roll a d4 and add the number rolled to one ability check of its choice'),(10,'Light',0,'Evocation','1 Action','Touch','1 hour',NULL,'','','\0','\0','\0','','\0','','You touch one object that is no larger than 10 feet in any dimension. Until the spell ends, the object sheds bright light in a 20-foot radius and dim light for an additional 20 feet.'),(11,'Mage Hand',0,'Conjuration','1 Action','30 feet','1 minute',NULL,'','\0','\0','\0','\0','','','','A spectral, floating hand appears at a point you choose within range. The hand lasts for the duration or until you dismiss it as an action.'),(12,'Mending',0,'Transmutation','1 Minute','Touch','Instantaneous',NULL,'','','','\0','\0','','\0','','This spell repairs a single break or tear in an object you touch'),(13,'Message',0,'Transmutation','1 Action','120 feet','1 round',NULL,'','\0','\0','\0','\0','','\0','','You point your finger toward a creature within range and whisper a message.'),(14,'Minor Illusion',0,'Illusion','1 Action','30 feet','1 minute',NULL,'','\0','\0','\0','\0','','','','You create a sound or an image of an object within range that lasts for the duration.'),(15,'Poison Spray',0,'Conjuration','1 Action','10 feet','Instantaneous','1d12','\0','\0','','\0','\0','','','','You extend your hand toward a creature you can see within range and project a puff of noxious gas from your palm.'),(16,'Prestidigitation',0,'Transmutation','1 Action','10 feet','Up to 1 hour',NULL,'','\0','\0','\0','\0','','','','This spell is a minor magical trick that novice spellcasters use for practice.'),(17,'Produce Flame',0,'Conjuration','1 Action','self','10 minutes','1d8','\0','\0','','\0','\0','\0','\0','\0','A flickering flame appears in your hand.'),(18,'Ray of Frost',0,'Evocation','1 Action','60 feet','Instantaneous','1d8','\0','\0','\0','\0','\0','','\0','','A frigid beam of blue-white light streaks toward a creature within range.'),(19,'Resistance',0,'Abjuration','1 Action','Touch','Up to 1 minute',NULL,'\0','','','\0','\0','\0','\0','\0','You touch one willing creature.'),(20,'Sacred Flame',0,'Evocation','1 Action','60 feet','Instantaneous','1d8','\0','','\0','\0','\0','\0','\0','\0','Flame-like radiance descends on a creature that you can see within range.'),(21,'Shillelagh',0,'Transmutation','1 Bonus Action','Touch','1 minute','1d8','\0','\0','','\0','\0','\0','\0','\0','The wood of a club or quarterstaff you are holding is imbued with nature’s power.'),(22,'Shocking Grasp',0,'Evocation','1 Action','Touch','Instantaneous','1d8','\0','\0','\0','\0','\0','','\0','','Lightning springs from your hand to deliver a shock to a creature you try to touch.'),(23,'Spare the Dying',0,'Necromancy','1 Action','Touch','Instantaneous',NULL,'\0','','\0','\0','\0','\0','\0','\0','You touch a living creature that has 0 hit points. The creature becomes stable.'),(24,'Thaumaturgy',0,'Transmutation','1 Action','30 feet','Up to 1 minute',NULL,'\0','','\0','\0','\0','\0','\0','\0','You manifest a minor wonder, a sign of supernatural power, within range.'),(25,'Thorn Whip',0,'Transmutation','1 Action','30 feet','Instantaneous','1d6','\0','\0','','\0','\0','\0','\0','\0','You create a long, vine-like whip covered in thorns that lashes out at your command toward a creature in range.'),(26,'True Strike',0,'Divination','1 Action','30 feet','up to 1 round',NULL,'','\0','\0','\0','\0','','','','You extend your hand and point a finger at a target in range.'),(27,'Vicious Mockery',0,'Enchantment','1 Action','60 feet','Instantaneous',NULL,'','\0','\0','\0','\0','\0','\0','\0','You unleash a string of insults laced with subtle enchantments at a creature you can see within range.'),(28,'Alarm (Ritual)',1,'Abjuration','1 Minute','30 feet','8 hours',NULL,'\0','\0','\0','\0','','\0','\0','','You set an alarm against unwanted intrusion. You choose whether the alarm is mental or audible.'),(29,'Animal Friendship',1,'Enchantment','1 Action','30 feet','24 hours',NULL,'','\0','','\0','','\0','\0','\0','This spell lets you convince a beast that you mean it no harm. Choose a beast that you can see within range. It must see and hear you.'),(30,'Armor of Agathys',1,'Abjuration','1 Action','Self','1 hour',NULL,'\0','\0','\0','\0','\0','\0','','\0','A protective magical force surrounds you, manifesting as a spectral frost that covers you and your gear.'),(31,'Arms of Hadar',1,'Conjuration','1 Action','10 feet','Instantaneous','2d6','\0','\0','\0','\0','\0','\0','','\0','You invoke the power of Hadar, the Dark Hunger.Tendrils of dark energy erupt from you and batter all creatures within 10 feet of you.'),(32,'Bane',1,'Enchantment','1 Action','30 feet','Up to 1 minute',NULL,'','','\0','\0','\0','\0','\0','\0','Up to three creatures of your choice that you can see within range must make Charisma saving throws.'),(33,'Bless',1,'Enchantment','1 Action','30 feet','Up to 1 minute',NULL,'\0','','\0','','\0','\0','\0','\0','You bless up to three creatures of your choice within range.'),(34,'Burning Hands',1,'Evocation','1 Action','Self','Instantaneous','3d6','\0','\0','\0','\0','\0','','\0','','Each creature in a 15-foot cone must make a Dexterity saving throw. A creature takes 3d6 fire damage on a failed save, or half as much damage on a successful one.'),(35,'Charm Person',1,'Enchantment','1 Action','30 feet','1 hour',NULL,'','\0','','\0','\0','','','','You attempt to charm a humanoid you can see within range.\r\nIt must make a Wisdom saving throw, and does so with advantage if you or your companions are fighting it.'),(36,'Chromatic Orb',1,'Evocation','1 Action','90 feet','Instantaneous','3d8','\0','\0','\0','\0','\0','','\0','',' You choose acid, cold, fire, lightning, poison, or thunder for the type of orb you create, and then make a ranged spell attack against the target.'),(37,'Color Spray',1,'Illusion','1 Action','Self','1 Round','6d10','\0','\0','\0','\0','\0','','\0','','A dazzling array of flashing, colored light springs from your hand.\r\nRoll 6d10, the total is how many hit points of creatures this spell can effect.'),(38,'Command',1,'Enchantment','1 Action','60 feet','1 Round',NULL,'\0','','\0','','\0','\0','\0','\0','You speak a one-word command to a creature you can see within range: Approach, Drop, Flee, Grovel or Halt.'),(39,'Compelled Duel',1,'Enchantment','1 Bonus Action','30 feet','Up to 1 minute',NULL,'\0','\0','\0','','\0','\0','\0','\0','You attempt to compel a creature into a duel.'),(40,'Comprehend Languages',1,'Divination','1 Action','Self','1 hour',NULL,'','\0','\0','\0','\0','','','','For the duration, you understand the literal meaning of any spoken language that you hear.\r\nYou also understand any spoken language that you hear or read.'),(41,'Create or Destroy Water',1,'Transmutation','1 Action','30 feet','Instantaneous',NULL,'\0','','','\0','\0','\0','\0','\0','You either create or destroy water.'),(42,'Cure Wounds',1,'Evocation','1 Action','Touch','Instantaneous',NULL,'','','','','','\0','\0','\0','A creature you touch regains a number of hit points equal to 1d8 + your spellcasting ability modifier. This spell has no effect on undead or constructs.'),(43,'Detect Evil and Good',1,'Divination','1 Action','Self','Up to 10 minutes',NULL,'\0','','\0','','\0','\0','\0','\0','For the duration, you know if there is an aberration, celestial, elemental, fey, fiend, or undead within 30 feet of you, as well as where the creature is located.'),(44,'Detect Magic (Ritual)',1,'Divination','1 Action','Self','Up to 10 minutes',NULL,'','','','','','','\0','','For the duration, you sense the presence of magic within 30 feet of you.'),(45,'Detect Poison and Disease (Ritual)',1,'Divination','1 Action','Self','Up to 10 minute',NULL,'\0','','','','','\0','\0','\0','For the duration, you can sense the presence and location of poisons, poisonous creatures, and diseases within 30 feet of you.'),(46,'Disguise Self',1,'Illusion','1 Action','Self','1 hour',NULL,'','\0','\0','\0','\0','','\0','','You make yourself – including your clothing, armor, weapons, and other belongings on your person – look different until the spell ends or until you use your action to dismiss it.'),(47,'Dissonant Whispers',1,'Enchantment','1 Action','60 feet','Instantaneous','3d6','','\0','\0','\0','\0','\0','\0','\0','You whisper a discordant melody that only one creature of your choice within range can hear, wracking it with terrible pain.'),(48,'Divine Favor',1,'Evocation','1 Bonus Action','Self','Up to 1 minute',NULL,'\0','\0','\0','','\0','\0','\0','\0','Your prayer empowers you with divine radiance. Until the spell ends, your weapon attacks deal and extra 1d4 radiant damage on a hit.'),(49,'Ensnaring Strike',1,'Conjuration','1 Bonus Action','Self','Up to 1 minute',NULL,'\0','\0','\0','\0','','\0','\0','\0','The next time you hit a creature with a weapon attack before this spell ends, a writhing mass of thorny vines appears at the point of impact'),(50,'Entangle',1,'Conjuration','1 Action','90 feet','Up to 1 minute',NULL,'\0','\0','','\0','\0','\0','\0','\0','Grasping weeds and vines sprout from the ground in a 20-foot square starting from a point within range.'),(51,'Expeditious Retreat',1,'Transmutation','1 Bonus Action','Self','Up to 10 minute',NULL,'\0','\0','\0','\0','\0','','','','This spell allows you to move at an incredible pace.'),(52,'Faerie Fire',1,'Evocation','1 Action','60 feet','Up to 1 minute',NULL,'','\0','','\0','\0','\0','\0','\0','Each object in a 20-foot cube within range is outlined in blue, green, or violet light (your choice).'),(53,'False Life',1,'Necromancy','1 Action','Self','1 hour',NULL,'\0','\0','\0','\0','\0','','\0','','Bolstering yourself with a necromantic facsimile of life, you gain 1d4 + 4 temporary hit points for the duration.'),(54,'Feather Fall',1,'Transmutation','Special','60 feet','1 minute',NULL,'','\0','\0','\0','\0','','\0','','If the creature lands before the spell ends, it takes no falling damage and can land on its feet, and the spell ends for that creature.'),(55,'Find Familiar (Ritual)',1,'Conjuration','1 Hour','10 feet','Instantaneous',NULL,'\0','\0','\0','\0','\0','\0','\0','','You gain the service of a familiar, a spirit that takes an animal form you choose.'),(56,'Fog Cloud',1,'Conjuration','1 Action','120 feet','Up to 1 hour',NULL,'\0','\0','','\0','','','\0','','You create a 20-foot-radius sphere of fog centered on a point within range.'),(57,'Goodberry',1,'Transmutation','1 Action','Touch','Instantaneous',NULL,'\0','\0','','\0','','\0','\0','\0','Up to ten berries appear in your hand and are infused with magic for the duration.'),(58,'Grease',1,'Conjuration','1 Action','60 feet','1 minute',NULL,'\0','\0','\0','\0','\0','\0','\0','','Slick grease covers the ground in a 10-foot square centered on a point within range and turns it into difficult terrain for the duration.'),(59,'Guiding Bolt',1,'Evocation','1 Action','120 feet','1 round','4d6','\0','','\0','\0','\0','\0','\0','\0','A flash of light streaks toward a creature of your choice within range.'),(60,'Hail of Thorns',1,'Conjuration','1 Bonus Action','Self','Up to 1 minute','1d10','\0','\0','\0','\0','','\0','\0','\0','The next time you hit a creature with a ranged weapon attack before the spell ends, this spell creates a rain of thorns that sprouts from your ranged weapon or ammunition.'),(61,'Healing Word',1,'Evocation','1 Bonus Action','60 feet','Instantaneous',NULL,'','','','\0','\0','\0','\0','\0','A creature of your choice that you can see within range regains hit points equal to 1d4 + your spellcasting ability modifier.'),(62,'Hellish Rebuke',1,'Evocation','Special','60 feet','Instantaneous','2d10','\0','\0','\0','\0','\0','\0','','\0','You point your finger, and the creature that damaged you is momentarily surrounded by hellish flames.'),(63,'Heroism',1,'Enchantment','1 Action','Touch','Up to 1 minute',NULL,'','\0','\0','','\0','\0','\0','\0','Until the spell ends, the creature is immune to being frightened and gains temporary hit points equal to your spellcasting ability modifier at the start of each of its turns.'),(64,'Hex',1,'Enchantment','1 Bonus Action','90 feet','Up to 1 hour','1d6','\0','\0','\0','\0','\0','\0','','\0','You place a curse on a creature that you can see within range. Until the spell ends, you deal an extra 1d6 necrotic damage to the target whenever you hit it with an attack.'),(65,'Hunter’s Mark',1,'Divination','1 Bonus Action','90 feet','Up to 1 hour','1d6','\0','\0','\0','\0','','\0','\0','\0','You choose a creature you can see within range and mystically mark it as your quarry. Until the spell ends, you deal an extra 1d6 damage to the target whenever you hit it with a weapon attack'),(66,'Identify (Ritual)',1,'Divination','1 Minute','Touch','Instantaneous',NULL,'','\0','\0','\0','\0','\0','\0','','You learn whether any spells are affecting the item and what they are. If the item was created by a spell, you learn which spell created it.'),(67,'Illusory Script (Ritual)',1,'Illusion','1 Minute','Touch','10 days',NULL,'','\0','\0','\0','\0','\0','','','You write on parchment, paper, or some other suitable writing material and imbue it with a potent illusion that lasts for the duration.'),(68,'Inflict Wounds',1,'Necromancy','1 Action','Touch','Instantaneous','3d10','\0','','\0','\0','\0','\0','\0','\0','Make a melee spell attack against a creature you can reach. On a hit, the target takes 3d10 necrotic damage.'),(69,'Jump',1,'Transmutation','1 Action','Touch','1 minute',NULL,'\0','\0','','\0','','','\0','','You touch a creature. The creature’s jump distance is tripled until the spell ends.'),(70,'Longstrider',1,'Transmutation','1 Action','Touch','1 hour',NULL,'','\0','','\0','','\0','\0','','You touch a creature. The target’s speed increases by 10 feet until the spell ends.'),(71,'Mage Armor',1,'Abjuration','1 Action','Touch','8 hours',NULL,'\0','\0','\0','\0','\0','','\0','','You touch a willing creature who isn’t wearing armor, and a protective magical force surrounds it until the spell ends.'),(72,'Magic Missile',1,'Evocation','1 Action','120 feet','Instantaneous','1d4','\0','\0','\0','\0','\0','','\0','','You create three glowing darts of magical force. Each dart hits a creature of your choice that you can see within range.'),(73,'Protection from Evil and Good',1,'Abjuration','1 Action','Touch','Up to 10 minute',NULL,'\0','','\0','','\0','\0','','','Until the spell ends, one willing creature you touch is protected against certain types of creatures: aberrations, celestials, elementals, fey, fiends, and undead.'),(74,'Purify Food and Drink (Ritual)',1,'Transmutation','1 Action','10 feet','Instantaneous',NULL,'\0','','','','\0','\0','\0','\0','All nonmagical food and drink within a 5-foot-radius sphere centered on a point of your choice within range is purified and rendered free of poison and disease.'),(75,'Ray of Sickness',1,'Necromancy','1 Action','60 feet','Instantaneous','2d8','\0','\0','\0','\0','\0','','\0','','A ray of sickening greenish energy lashes out toward a creature within range.'),(76,'Sanctuary',1,'Abjuration','1 Bonus Action','30 feet','1 minute',NULL,'\0','','\0','\0','\0','\0','\0','\0','Until the spell ends, any creature who targets the warded creature with an attack or a harmful spell must first make a Wisdom saving throw.'),(77,'Searing Smite',1,'Evocation','1 Bonus Action','Self','Up to 1 minute','1d6','\0','\0','\0','','\0','\0','\0','\0','The next time you hit a creature with a melee weapon attack during the spell’s duration, your weapon flares with white-hot intensitity, and the attack deals an extra fire damage.'),(78,'Shield',1,'Abjuration','Special','Self','1 round',NULL,'\0','\0','\0','\0','\0','','\0','','An invisible barrier of magical force appears and protects you.'),(79,'Shield of Faith',1,'Abjuration','1 Bonus Action','60 feet','Up to 10 minute',NULL,'\0','','\0','','\0','\0','\0','\0','A shimmering field appears and surrounds a creature of your choice within range, granting it a +2 bonus to AC for the duration.'),(80,'Silent Image',1,'Illusion','1 Action','60 feet','Up to 10 minute',NULL,'','\0','\0','\0','\0','','\0','','You create the image of an object, a creature, or some other visible phenomenon that is no larger than a 15-foot cube. The image appears at a spot within range and lasts for the duration.'),(81,'Sleep',1,'Enchantment','1 Action','90 feet','1 minute',NULL,'','\0','\0','\0','\0','','\0','','This spell sends creatures into a magical slumber.'),(82,'Speak with Animals (Ritual)',1,'Divination','1 Action','Self','10 minutes',NULL,'','\0','','\0','','\0','\0','\0','You gain the ability to comprehend and verbally communicate with beasts for the duration.'),(83,'Tasha’s Hideous Laughter',1,'Enchantment','1 Action','30 feet','Up to 1 minute',NULL,'','\0','\0','\0','\0','\0','\0','','A creature of your choice that you can see within range perceives everything as hilariously funny and falls into fits of laughter if this spell affects it.'),(84,'Tenser’s Floating Disk (Ritual)',1,'Conjuration','1 Action','30 feet','1 hour',NULL,'\0','\0','\0','\0','\0','\0','\0','','This spell creates a circular, horizontal plane of force, 3 feet in diameter and 1 inch thick, that floats 3 feet above the ground in an unoccupied space of your choice that you can see within range.'),(85,'Thunderous Smite',1,'Evocation','1 Bonus Action','Self','Up to 1 minute','2d6','\0','\0','\0','','\0','\0','\0','\0','The first time you hit with a melee weapon attack during this spell’s duration, your weapon rings with thunder that is audible within 300 feet of you.'),(86,'Thunderwave',1,'Evocation','1 Action','Self','Instantaneous','2d8','','\0','','\0','\0','','\0','','A wave of thunderous force sweeps out from you.'),(87,'Unseen Servant (Ritual)',1,'Conjuration','1 Action','60 feet','1 hour',NULL,'','\0','\0','\0','\0','\0','','','This spell creates a force that performs simple tasks at your command until the spell ends.'),(88,'Witch Bolt',1,'Evocation','1 Action','30 feet','Up to 1 minute','1d12','\0','\0','\0','\0','\0','','','','A beam of crackling, blue energy lances out toward a creature within range, forming a sustained arc of lightning between you and the target.'),(89,'Wrathful Smite',1,'Evocation','1 Bonus Action','Self','Up to 1 minute','1d6','\0','\0','\0','','\0','\0','\0','\0','The next time you hit with a melee weapon attack during this spell’s duration, your attack deals an extra 1d6 psychic damage.'),(90,'Aid',2,'Abjuration','1 Action','30 feet','8 hours',NULL,'\0','','\0','','\0','\0','\0','\0','Choose up to three creatures within range. Each target’s hit point maximum and current hit points increase by 5 for the duration.'),(91,'Alter Self',2,'Transmutation','1 Action','Self','Up to 1 hour',NULL,'\0','\0','\0','\0','\0','','\0','','You assume a different form.'),(92,'Animal Messenger (Ritual)',2,'Enchantment','1 Action','30 feet','24 hours',NULL,'','\0','','\0','','\0','\0','\0','By means of this spell, you use an animal to deliver a message.'),(93,'Arcane Lock',2,'Abjuration','1 Action','Touch','Until dispelled',NULL,'\0','\0','\0','\0','\0','\0','\0','','You touch a closed door, window, gate, chest, or other entryway, and it becomes locked for the duration.'),(94,'Augury (Ritual)',2,'Divination','1 Minute','Self','Instantaneous',NULL,'\0','','\0','\0','\0','\0','\0','\0','By casting gem-inlaid sticks, rolling dragon bones, laying out ornate cards, or employing some other divining tool, you receive an omen from an otherworldly entity.'),(95,'Barkskin',2,'Transmutation','1 Action','Touch','Up to 1 hour',NULL,'\0','\0','','\0','','\0','\0','\0','You touch a willing creature. Until the spellends, the target’s skin has a rough, bark-like appearance, and the target’s AC can’t be less than 16, regardless of what kind of armor it is wearing.'),(96,'Beast Sense (Ritual)',2,'Divination','1 Action','Touch','Up to 1 hour',NULL,'\0','\0','','\0','','\0','\0','\0','For the duration of the spell, you can use your action to see through the beast’s eyes and hear what it hears.'),(97,'Blindness/Deafness',2,'Necromancy','1 Action','30 feet','1 minute',NULL,'','','\0','\0','\0','','\0','','Choose one creature that you can see within range to make a Constitution saving throw. If it fails, the target is blinded or deafened for the duration.'),(98,'Blur',2,'Illusion','1 Action','Self','Up to 1 minute',NULL,'\0','\0','\0','\0','\0','','\0','','For the duration, any creature has disadvantage on attack rolls against you.'),(99,'Branding Smite',2,'Evocation','1 Bonus Action','Self','Up to 1 minute','2d6','\0','\0','\0','','\0','\0','\0','\0','The next time you hit a creature with a weapon attack before this spell ends, the weapon glemas with astral radiance as you strike.'),(100,'Calm Emotions',2,'Enchantment','1 Action','60 feet','Up to 1 minute',NULL,'','','\0','\0','\0','\0','\0','\0','You attempt to suppress strong emotions in a group of people.');
/*!40000 ALTER TABLE `spells` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `login` varchar(20) COLLATE utf8_polish_ci NOT NULL,
  `password` varchar(100) COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('dnduser','207023ccb44feb4d7dadca005ce29a64'),('user_DND','207023ccb44feb4d7dadca005ce29a64');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `weapons`
--

DROP TABLE IF EXISTS `weapons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `weapons` (
  `weapon_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `character_id` int(10) unsigned NOT NULL,
  `weapon_name` char(20) NOT NULL,
  `dmg_dice` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `dmg_dice_size` tinyint(3) unsigned NOT NULL DEFAULT '4',
  `attack_range` char(20) NOT NULL,
  `damage_type` char(20) DEFAULT NULL,
  `item_description` char(255) DEFAULT NULL,
  PRIMARY KEY (`weapon_id`),
  KEY `character_id` (`character_id`),
  CONSTRAINT `weapons_ibfk_1` FOREIGN KEY (`character_id`) REFERENCES `characters` (`character_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weapons`
--

LOCK TABLES `weapons` WRITE;
/*!40000 ALTER TABLE `weapons` DISABLE KEYS */;
INSERT INTO `weapons` VALUES (1,1,'Topór dwuręczny',1,8,'mele',NULL,NULL),(2,1,'miecz krotki',1,6,'mele',NULL,NULL),(3,1,'lekka kusza',1,7,'20m',NULL,NULL),(4,2,'Łuk Długi',1,8,'35m',NULL,NULL),(5,2,'Sztylet',1,4,'mele',NULL,NULL),(6,3,'Miecz dwureczny',1,10,'mele',NULL,NULL),(7,4,'accas',1,2,'acas','acac',''),(8,4,'acsas',3,3,'21caw','acs','');
/*!40000 ALTER TABLE `weapons` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-07-10 21:51:54
