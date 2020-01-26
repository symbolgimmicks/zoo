using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            System.Timers.Timer titleScreenTimer = new System.Timers.Timer(5000);
            titleScreenTimer.Elapsed += TitleScreenTimer_Elapsed;

            Tuple<bool, int> lastMainMenuChoice;
            do
            {
                switch (GameState.Current())
                {
                    case GameState.Values.Quit:
                        done = true;
                        break;
                    case GameState.Values.TitleScreen:
                        if (!titleScreenTimer.Enabled)
                        {
                            Console.WriteLine("JJB RPG!");
                            Console.Write("Press spacebar to continue");
                            titleScreenTimer.Start();
                        }
                        else
                        {

                        }

                        if (Console.KeyAvailable && Console.ReadKey().Key == System.ConsoleKey.Spacebar)
                        {
                            GameState.Set(GameState.Values.MainMenu);
                            titleScreenTimer.Stop();
                        }
                        break;
                    case GameState.Values.MainMenu:
                        lastMainMenuChoice = ShowMainMenu();
                        break;

                }
            }
            while (!done);
        }

        private static void TitleScreenTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.Write(".");
        }

        private static Tuple<bool, int> ShowMainMenu()
        {
            string[] Menu = new string[]
            {
                "1.) New Game",
                "2.) Load Game",
                "3.) Quit Game",
            };

            while (true)
            {
                foreach(string val in Menu)
                {
                    Console.WriteLine(val);
                }

                Console.Write("Choice?: ");
                string line = Console.ReadLine();
                try
                {
                    int val = Convert.ToInt32(line);
                    switch(val)
                    {
                        case 1:
                            GameState.Set(GameState.Values.NewGame);
                            break;
                        case 2:
                            GameState.Set(GameState.Values.LoadGame);
                            break;
                        case 3:
                            GameState.Set(GameState.Values.Quit);
                            break;
                    }

                    return new Tuple<bool, int>(true, val);
                }
                catch
                {

                }
            }
        }
    }
}
