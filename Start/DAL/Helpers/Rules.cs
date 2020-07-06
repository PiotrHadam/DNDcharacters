using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start.DAL.Helpers {
    public static class Rules {
        public static string[] Abilities {
            get {
                return new string[] {
                    "acrobatics",
                    "animal_handing",
                    "arcana",
                    "athletics",
                    "deception",
                    "history",
                    "insight",
                    "intimidation",
                    "investigation",
                    "medicine",
                    "nature",
                    "perception",
                    "performance",
                    "persuasion",
                    "religion",
                    "sleight_of_hand",
                    "stealh",
                    "survival",
                };

            }
        }
    }
}