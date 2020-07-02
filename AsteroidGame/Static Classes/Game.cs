using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        static List<BaseObject> BackgroundObjects; 
        static List<BaseObject> GameObjects;

        public static int Width { get; private set; }
        public static int Height { get; private set; }
        static Timer timer;
        static DateTime startDate = DateTime.Now;
        static Game() { }
        public static void Init(Form form)
        {
            if (form.Width < 0 || form.Height < 0
                || form.Width > 1920 || form.Height > 1080)
                throw new ArgumentOutOfRangeException("Form dimensions are out of range.");
            InitGraphics(form);
            InitObjects();
            SetTimer();
        }
        private static void InitGraphics(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }
        private static void SetTimer()
        {
            timer = new Timer { Interval = 100 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        private static void InitObjects()
        {
            InitBackgroundObjects();
            InitGameObjects();
        }
        private static void InitBackgroundObjects()
        {
            BackgroundObjects = new List<BaseObject>();
            for (int i = 0; i < 5; i++)
            {
                BackgroundObjects.Add(new BrightStar());
            }
            for (int i = 0; i < 3; i++)
            {
                BackgroundObjects.Add(new Comet());
            }
            for (int i = 0; i < 50; i++)
            {
                BackgroundObjects.Add(new Star());
        }
        }
        private static void InitGameObjects()
        {
            GameObjects = new List<BaseObject>();
            GameObjects.Add(new Bullet(new Point(100, 430), new Point(15,15), new Size()));
            GameObjects.Add(new Bullet(new Point(100, 430), new Point(15, 0), new Size()));
            GameObjects.Add(new Bullet(new Point(100, 430), new Point(15, -15), new Size()));
            for (int i = 0; i < 10; i++)
            {
                GameObjects.Add(new Asteroid());
            }
        }
        private static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in BackgroundObjects)
                obj.Draw();
            foreach (BaseObject obj in GameObjects)
                obj.Draw();
            string GameSize = Game.Width + "x" + Game.Height;
            string GameTime = (DateTime.Now - startDate).ToString().Substring(0,8);
            Game.Buffer.Graphics.DrawString(GameSize + "     " + GameTime, new Font("Arial", 10), new SolidBrush(Color.White), 10, 10);
            Buffer.Render();
        }
        private static void Update()
        {
            foreach (BaseObject obj in BackgroundObjects)
                obj.Update();
            foreach (BaseObject obj in GameObjects)
                obj.Update();

            PerformCollisions();            
        }
        private static void PerformCollisions()
        {
            for (int i = 0; i < GameObjects.Count; i++)
                for (int j = i+1; j < GameObjects.Count; j++)
                {
                    if ( GameObjects[j].HaveCollision(GameObjects[i])
                        && (GameObjects[i] is Asteroid && GameObjects[j] is Bullet
                        || GameObjects[i] is Bullet && GameObjects[j] is Asteroid) )
                    {
                        GameObjects[i].ResetPos();
                        GameObjects[j].ResetPos();                        
                    }
                }
        }
        public static void Close(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
