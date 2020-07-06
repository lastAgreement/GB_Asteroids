using System;
using System.Windows.Forms;

namespace AsteroidGame
{
    class Program
    {
        static void Main(string[] args)
        {
           SplashScreen.Init();
            // StartGame();

        }
        static void StartGame()
        {
            Form gameForm = new Form();
            gameForm.Width = 1600;
            gameForm.Height = 900;
            Game.Init(gameForm);
            gameForm.Show();
            Application.Run(gameForm);
        }
    }
}
