using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace ByDR
{
    class _
    {
        public static bool gameOver = false;
        public static int score = 0;
        static int speed = 240;
        public enum direction { left, up, right, down }
        static Thread background = new Thread(BackgroundGame);
        public static Map map = new Map();
        public static Pacman pacman;
        public static List<StupidGhost> stupidGhosts = new List<StupidGhost>();
        public static List<SmartGhost> smartGhosts = new List<SmartGhost>();

        static void Main()
        {
            Title = "ByDR";
            CursorVisible = false;
            ForegroundColor = ConsoleColor.Cyan;
            SetCursorPosition(12, 15);
            WriteLine("PacManGame");
            Thread.Sleep(1500);

            map.RenderMap();
            map.RenderJewels();

            _.pacman = new Pacman(13, 23);

            _.stupidGhosts.Add(new StupidGhost(13, 11, Object.direction.left));

            _.smartGhosts.Add(new SmartGhost(15, 11, Object.direction.right));

            background.Start();
            background.IsBackground = true;      
            pacman.Control(background);
            Clear();

            if (score < 2430)
            {
                SetCursorPosition(12, 6);
                ForegroundColor = ConsoleColor.Red;
                Write("Game Over");
                SetCursorPosition(12, 8);
                ForegroundColor = ConsoleColor.Red;
                Write("Score: {0}", score);
                Thread.Sleep(500);
                SetCursorPosition(12, 10);
                ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                SetCursorPosition(12, 6);
                ForegroundColor = ConsoleColor.Red;
                Write("You Win!");
                SetCursorPosition(12, 8);
                ForegroundColor = ConsoleColor.Red;
                Write("Score: {0}", score);
                Thread.Sleep(500);
                SetCursorPosition(12, 10);
                ForegroundColor = ConsoleColor.Red;
            }
        }
        public static void BackgroundGame()
        {
            while (!_.gameOver)
            {
                if (score == 2430) gameOver = true;
                pacman.Step();
                foreach (SmartGhost ghost in _.smartGhosts) ghost.Step();
                if (_.score > 300)
                {
                    foreach (StupidGhost ghost in _.stupidGhosts) ghost.Step();
                }
                ForegroundColor = ConsoleColor.Yellow;
                SetCursorPosition(31, 1);
                Write("Score: {0}", score);
                Thread.Sleep(speed);
            }
        }
    }
}