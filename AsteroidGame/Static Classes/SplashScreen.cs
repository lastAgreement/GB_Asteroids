using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class SplashScreen
    {
        static Form mainForm = new Form();
        static SplashScreen()
        {
            SetFormProperties();
        }
        public static void Init()
        {
            mainForm.Show();
            Application.Run(mainForm);
        }
        static void SetFormProperties()
        {
            mainForm.Width = 1024;
            mainForm.Height = 720;
            mainForm.BackColor = Color.Black;
            //TO DO
            //эти конструкторы можно написать приличнее
            mainForm.Controls.Add(CreateStartButton());
            mainForm.Controls.Add(CreateRecordsButton());
            mainForm.Controls.Add(CreateExitButton());
            mainForm.Controls.Add(CreateLabel("DirectedBy M.Grigorian", new Point(mainForm.Width - 300, mainForm.Height - 50), new Font("Arial", 10)));
            mainForm.Controls.Add(CreateLabel("ASTEROIDS", new Point(mainForm.Width / 2, mainForm.Height / 6), new Font("Arial", 32)));
        }
        static Button CreateStartButton()
        {
            Button button = CreateButton("StartButton");
            button.Location = new Point(mainForm.Width / 2 - button.Size.Width / 2,
                3 * mainForm.Height / 8 - button.Size.Height / 2);
            button.Click += StartGame;
            return button;
        }
        static Button CreateRecordsButton()
        {
            Button button = CreateButton("Records");
            button.Location = new Point(mainForm.Width / 2 - button.Size.Width / 2,
                4 * mainForm.Height / 8 - button.Size.Height / 2);
            //TO DO
            //button.Click += ShowRecordsList;
            return button;
        }
        static Button CreateExitButton()
        {
            Button button = CreateButton("Exit");
            button.Location = new Point(mainForm.Width / 2 - button.Size.Width / 2,
                5 * mainForm.Height / 8 - button.Size.Height / 2);
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
            gameForm.Shown += HideMainForm;
            gameForm.FormClosing += Game.Close;
            gameForm.FormClosing += ShowForm;
            Game.Init(gameForm);
            gameForm.Show();
        }
        static void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
        static void HideMainForm(object sender, EventArgs e)
        {
            mainForm.Hide();
        }
        static void ShowForm(object sender, EventArgs e)
        {
            mainForm.Show();
        }
    }
}
