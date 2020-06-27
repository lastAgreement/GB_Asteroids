using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static BaseObject[] _objs;
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Random random = new Random();
        static Timer timer = new Timer { Interval = 100 };
        static DateTime startDate = DateTime.Now;
        static Game()
        {
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();            
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Load()
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
                //почему не работает конструктор рандома? :(
                //_objs[i] = new Star();
                _objs[i] = new Star(
                    new Point(random.Next(0, Width), random.Next(0, Height)),
                    new Point(random.Next(1, 15), 0),
                    new Size(0, 0)
                    );

            }           
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();

            string GameSize = Game.Width + "x" + Game.Height;
            string GameTime = (DateTime.Now - startDate).ToString().Substring(0,8);
            Game.Buffer.Graphics.DrawString(GameSize + "     " + GameTime, new Font("Arial", 10), new SolidBrush(Color.White), 10, 10);
            try
            {
                Buffer.Render();
            }
            catch(Exception ex)
            {
                timer.Stop();
            }
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }


    }
}
