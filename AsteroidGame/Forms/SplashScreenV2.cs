using AsteroidGame.UtilityClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AsteroidGame
{
    public partial class SplashScreenV2 : Form
    {
        public SplashScreenV2()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
        private void StartGame(object sender, EventArgs e)
        {
            Form gameForm = new Form();
            gameForm.FormBorderStyle = FormBorderStyle.None;
            gameForm.Width = 1600;
            gameForm.Height = 900;
            gameForm.Shown += GameForm_Shown;
            gameForm.FormClosed += GameForm_FormClosed;
            Game.Init(gameForm);
            gameForm.Show();
        }

        private void GameForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GameForm_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ControlsButton_Click(object sender, EventArgs e)
        {
            ListBox.Items.Clear();
            string infoFilePath = "Info/ControlsInfo.txt";
            using (StreamReader sr = new StreamReader(infoFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ListBox.Items.Add(line);
                }
            }
            ListBox.Visible = true;
        }

        private void ScoreButton_Click(object sender, EventArgs e)
        {
            ListBox.Items.Clear();
            List<Tuple<string, int>> ScoreTable = LogUtils.ReadScoreFromFile();
            ScoreTable.Sort((x, y) => y.Item2 - x.Item2);
            foreach (Tuple<string, int> score in ScoreTable)
            {
                ListBox.Items.Add(score.Item2 + "\t" + score.Item1) ;
            }
            ListBox.Visible = true;
        }

        private void SplashScreenV2_MouseClick(object sender, MouseEventArgs e)
        {
            ListBox.Visible = false;
        }
    }
}
