using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.UtilityClasses;

namespace AsteroidGame
{
    static class Game
    {
        #region GameObjects
        static List<BaseObject> BackgroundObjects; 
        static List<Asteroid> Asteroids;
        static List<Bullet> Bullets;
        static List<Battery> Batteries;
        static List<BaseObject> ToBeRemovedObjects;
        static Ship Ship;
        #endregion
        #region Properties
        static DateTime startOn = DateTime.Now;
        public static int Score { get; private set; }
        public static int Level { get; private set; }
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        #endregion
        #region Utilities Fields
        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        static Timer timer;
        static Action<object, string, string> logger;
        #endregion
        #region Init Methods
        static Game() {
            logger = new Action<object, string, string>(LogUtils.WriteLogToConsole);
            logger += new Action<object, string, string>(LogUtils.WriteLogToFile);
        }
        public static void Init(Form form)
        {
            if (form.Width < 0 || form.Height < 0
                || form.Width > 1920 || form.Height > 1080)
                throw new ArgumentOutOfRangeException("Form dimensions are out of range.");
            InitGraphics(form);
            SubscribeFormEvents(form);
            InitObjects();
            Score = 0;
            Level = 1;
            logger(null, "GameInitialized", null);
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
        private static void SubscribeFormEvents(Form form)
        {
            form.FormClosing += Form_FormClosing;
            form.KeyUp += Form_KeyUp;
        }
        private static void SetTimer()
        {
            timer = new Timer { Interval = 100 };
            timer.Tick += Timer_Tick;
            timer.Start();
            logger(timer, "Started", null);
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
            Ship = new Ship();
            Ship.ShipDamaged += Ship_ShipDamaged;
            Ship.ShipDied += GameOver; 
            
            Bullets = new List<Bullet>();
            Batteries = new List<Battery>();
            Asteroids = new List<Asteroid>();
            for (int i = 0; i < 10; i++)
            {
                Asteroids.Add(new Asteroid());
            }
            ToBeRemovedObjects = new List<BaseObject>();
        }
        #endregion
        #region EventHandlers Methods
        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger(sender, "Form_FormClosing", e.CloseReason.ToString());
            StopGame();
        }
        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            logger(sender, "Form_KeyUp", e.KeyCode.ToString());
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.A:
                case Keys.S:
                case Keys.D:
                case Keys.Up:
                case Keys.Left:
                case Keys.Down:
                case Keys.Right:
                    Ship.ChangeVelocity(e.KeyCode);
                    break; 
                case Keys.F:                  
                case Keys.Space:
                    Bullet bullet = Ship.Fire();
                    bullet.BulletSpent += Bullet_BulletSpent;
                    Bullets.Add(bullet);
                    break;
                case Keys.Escape:
                    Form gameForm = (Form)sender;
                    gameForm.Close();
                    break;
            }
        }
        private static void Bullet_BulletSpent(object sender, GameObjectEventArgs e)
        {
            Bullet bullet = (Bullet)sender;
            logger(sender, "Bullet_BulletSpent", e.EventType.ToString());
            if (e.EventType == GameObjectEventArgsType.BULLET_COLLIEDED_WITH_ASTEROID) Score+=5;
            logger(null, "Score", Score.ToString());
            ToBeRemovedObjects.Add(bullet);
        }
        private static void Battery_BatterySpent(object sender, GameObjectEventArgs e)
        {
            Battery battery = (Battery)sender;
            logger(sender, "Battery_BatterySpent", e.EventType.ToString());
            ToBeRemovedObjects.Add(battery);
        }
        private static void Ship_ShipDamaged(object sender, GameObjectEventArgs e)
        {
            logger(sender, "Ship_ShipDamaged", e.EventType.ToString());
            if (Score>0) Score--;
            logger(null, "Score", Score.ToString());
        }
        private static void GameOver(object sender, EventArgs e)
        {
            timer.Stop();
            Buffer.Graphics.DrawString("GAME OVER", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 200, 100);
            Buffer.Render();
            logger(null, "GameOver", null);
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        #endregion
        #region Processing Methods
        private static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (BaseObject obj in BackgroundObjects)
                obj.Draw();
            foreach (BaseObject obj in Batteries)
                obj.Draw();
            foreach (BaseObject obj in Bullets)
                obj.Draw();
            Ship.Draw();
            foreach (BaseObject obj in Asteroids)
                obj.Draw();

            string GameSize = Game.Width + "x" + Game.Height;
            string GameTime = (DateTime.Now - startOn).ToString().Substring(0,8);
            Game.Buffer.Graphics.DrawString(GameSize + "\t" + GameTime, SystemFonts.DefaultFont, Brushes.White, 10, 10);
            Buffer.Graphics.DrawString("Energy: " + Ship.Energy + "\tLevel: " + Level + "\tScore: " + Score, SystemFonts.DefaultFont, Brushes.White, 10, 30);

            Buffer.Render();
        }
        private static void Update()
        {
            Ship.Update();
            foreach (BaseObject obj in BackgroundObjects)
                obj.Update();
            foreach (BaseObject obj in Batteries)
                obj.Update();
            foreach (BaseObject obj in Bullets)
                obj.Update();
            foreach (BaseObject obj in Asteroids)
                obj.Update();
            RemoveObjects();
            PerformCollisions();

            if (Batteries.Count < 3 && GlobalRandom.Next(0, 1000) < 100)
            {
                Battery battery = new Battery();
                battery.BatterySpent += Battery_BatterySpent; 
                battery.BatterySpent += Ship.Battery_BatterySpent;
                Batteries.Add(battery);
            }
            if (Score >= 10 * Level)
            {
                Level++;
                Asteroids.Add(new Asteroid());
            }
        }
        private static void PerformCollisions()
        {
            for (int i = 0; i < Asteroids.Count; i++)
            {
                for (int j = 0; j < Bullets.Count; j++)
                {
                    if (Bullets[j].HaveCollision(Asteroids[i])) 
                    {
                        Asteroids[i].ResetPos(); 
                    }
                }
                if (Ship.HaveCollision(Asteroids[i])) 
                {
                    Asteroids[i].ResetPos(); 
                }
            }
            for (int j = 0; j < Batteries.Count; j++)
            {
                Batteries[j].HaveCollision(Ship); 
            }
        }
        private static void RemoveObjects()
        {
            foreach(BaseObject obj in ToBeRemovedObjects)
            {
                if (obj is Bullet)
                {
                    Bullets.Remove((Bullet)obj);
                }
                else if (obj is Battery)
                {
                    Batteries.Remove((Battery)obj);
                }
                else throw new Exception("Unexpected object to be deleted " + obj.ToString());
            }
            ToBeRemovedObjects.Clear();
        }
        private static void StopGame()
        {
            timer.Stop();
            if (Score != 0) LogUtils.WriteScoreToFile(Score);
        }
        #endregion
    }
}
