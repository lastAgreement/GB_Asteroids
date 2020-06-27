using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class SplashScreen
    {
        static Form form = new Form();
        //private static BufferedGraphicsContext _context;
        //public static BufferedGraphics Buffer;

        //public static BaseObject[] _objs;
        //public static int Width { get; set; }
        //public static int Height { get; set; }
        //static Random random = new Random();
        static SplashScreen()
        {
            SetFormProperties();
        }
        public static void Init()
        {
            form.Show();
            Application.Run(form);
        }
        static void SetFormProperties()
        {
            form.Width = 1024;
            form.Height = 720;
            form.BackColor = Color.Black;
            form.Controls.Add(CreateStartButton());
            form.Controls.Add(CreateRecordsButton());
            form.Controls.Add(CreateExitButton());
            form.Controls.Add(CreateLabel("DirectedBy M.Grigorian", new Point(form.Width - 300, form.Height - 50), new Font("Arial", 10)));
            form.Controls.Add(CreateLabel("ASTEROIDS", new Point(form.Width / 2, form.Height / 6), new Font("Arial", 32)));
        }
        static Button CreateStartButton()
        {
            Button button = CreateButton("Start");
            button.Location = new Point(form.Width / 2 - button.Size.Width / 2,
                3 * form.Height / 8 - button.Size.Height / 2);
            button.Click += StartGame;
            return button;
        }
        static Button CreateRecordsButton()
        {
            Button button = CreateButton("Records");
            button.Location = new Point(form.Width / 2 - button.Size.Width / 2,
                4 * form.Height / 8 - button.Size.Height / 2);
            return button;
        }
        static Button CreateExitButton()
        {
            Button button = CreateButton("Exit");
            button.Location = new Point(form.Width / 2 - button.Size.Width / 2,
                5 * form.Height / 8 - button.Size.Height / 2);
            button.Click += ExitGame;
            return button;
        }
        static Button CreateButton(string Caption)
        {
            Button button = new Button();
            button.Name = Caption;
            button.Text = Caption;
            button.Size = new Size(200, 40);
            button.BackColor = Color.Red;
            button.Location = new Point(10, 10);
            return button;
        }
        static Label CreateLabel(string Caption, Point location, Font font)
        {
            Label label = new Label();
            label.Text = Caption;
            label.Size = new Size(300, 40);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = font;
            label.ForeColor = Color.Red;
            label.Location = new Point(location.X - label.Size.Width / 2, location.Y - label.Size.Height / 2);
            return label;
        }
        static void StartGame(object sender, EventArgs e)
        {
            Form gameForm = new Form();
            gameForm.Width = 1600;
            gameForm.Height = 900;
            Game.Init(gameForm);
            gameForm.Show();
        }
        static void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
