using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_ConsoleClient
{
    static class GameState
    {
        public enum Values
        {
            TitleScreen,
            MainMenu,
            LoadGame,
            NewGame,
            InTown,
            InTavern,
            InShop,
            InArena,
            Traveling,
            SaveGame,
            Quit

        }

        static Values Value;

        public static Values Current() { return Value; }

        public static Values Set(Values gameState)
        {
            Values old = Value;
            Value = gameState;
            return old;
        }

    }
}
