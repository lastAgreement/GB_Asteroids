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

        static List<BaseObject> BackgroundObjs;
        static List<BaseObject> GameObjs;

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
            LoadObjects();
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
        private static void LoadObjects()
        {
            LoadBackgroundObjects();
            LoadGameObjects();
        }
        private static void LoadBackgroundObjects()
        {
            BackgroundObjs = new List<BaseObject>();
            for (int i = 0; i < 5; i++)
            {
                BackgroundObjs.Add(new BrightStar());
            }
            for (int i = 0; i < 3; i++)
            {
                BackgroundObjs.Add(new Comet());
            }
            for (int i = 0; i < 50; i++)
            {
                BackgroundObjs.Add(new Star());
        }
        }
        private static void LoadGameObjects()
        {
            GameObjs = new List<BaseObject>();
            GameObjs.Add(new Bullet(new Point(100, 430), new Point(15,15), new Size()));
            GameObjs.Add(new Bullet(new Point(100, 430), new Point(15, 0), new Size()));
            GameObjs.Add(new Bullet(new Point(100, 430), new Point(15, -15), new Size()));
            for (int i = 0; i < 10; i++)
            {
                GameObjs.Add(new Asteroid());
            }
        }
        private static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in BackgroundObjs)
                obj.Draw();
            foreach (BaseObject obj in GameObjs)
                obj.Draw();
            string GameSize = Game.Width + "x" + Game.Height;
            string GameTime = (DateTime.Now - startDate).ToString().Substring(0,8);
            Game.Buffer.Graphics.DrawString(GameSize + "     " + GameTime, new Font("Arial", 10), new SolidBrush(Color.White), 10, 10);
            Buffer.Render();
        }
        private static void Update()
        {
            foreach (BaseObject obj in BackgroundObjs)
                obj.Update();
            foreach (BaseObject obj in GameObjs)
                obj.Update();

            PerformCollisions();            
        }
        private static void PerformCollisions()
        {
            for (int i = 0; i < GameObjs.Count; i++)
                for (int j = i+1; j < GameObjs.Count; j++)
                {
                    if ( GameObjs[j].HaveCollision(GameObjs[i])
                        && (GameObjs[i] is Asteroid && GameObjs[j] is Bullet
                        || GameObjs[i] is Bullet && GameObjs[j] is Asteroid) )
                    {
                        GameObjs[i].ResetPos();
                        GameObjs[j].ResetPos();
                        
                    }
                }
        }
        public static void Close(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
