using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        static BaseObject[] _objs;
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        static Timer timer;
        static DateTime startDate = DateTime.Now;
        static Game() { }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        private static void Load()
        {
            _objs = new BaseObject[50];
            for (int i = 0; i < 5; i++)
            {
                _objs[i] = new BrightStar();
            }
            for (int i = 5; i < 8; i++)
            {
                _objs[i] = new Comet();
            }
            for (int i = 8; i < _objs.Length; i++)
            {
                _objs[i] = new Star();
            }           
        }
        private static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();

            string GameSize = Game.Width + "x" + Game.Height;
            string GameTime = (DateTime.Now - startDate).ToString().Substring(0,8);
            Game.Buffer.Graphics.DrawString(GameSize + "     " + GameTime, new Font("Arial", 10), new SolidBrush(Color.White), 10, 10);
            Buffer.Render();
        }
        private static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        public static void Close(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
