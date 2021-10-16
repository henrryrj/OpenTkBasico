using System;
using OpenTK;

namespace OpenTkBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(500, 500);
            Game miCasita = new Game(window);
        }
    }
}
