namespace AsteroidGame
{
    partial class SplashScreenV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenV2));
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.ControlsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Coral;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(412, 250);
            this.StartButton.Name = "StartButton";
            this.StartButton.Padding = new System.Windows.Forms.Padding(10);
            this.StartButton.Size = new System.Drawing.Size(200, 50);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1024, 300);
            this.label1.TabIndex = 4;
            this.label1.Text = "ASTEROIDS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(860, 656);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "By M Grigoryan";
            // 
            // ScoreButton
            // 
            this.ScoreButton.BackColor = System.Drawing.Color.Coral;
            this.ScoreButton.FlatAppearance.BorderSize = 0;
            this.ScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreButton.ForeColor = System.Drawing.Color.White;
            this.ScoreButton.Location = new System.Drawing.Point(412, 325);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Padding = new System.Windows.Forms.Padding(10);
            this.ScoreButton.Size = new System.Drawing.Size(200, 50);
            this.ScoreButton.TabIndex = 6;
            this.ScoreButton.Text = "SCORE";
            this.ScoreButton.UseVisualStyleBackColor = false;
            this.ScoreButton.Click += new System.EventHandler(this.ScoreButton_Click);
            // 
            // ControlsButton
            // 
            this.ControlsButton.BackColor = System.Drawing.Color.Coral;
            this.ControlsButton.FlatAppearance.BorderSize = 0;
            this.ControlsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ControlsButton.ForeColor = System.Drawing.Color.White;
            this.ControlsButton.Location = new System.Drawing.Point(412, 400);
            this.ControlsButton.Name = "ControlsButton";
            this.ControlsButton.Padding = new System.Windows.Forms.Padding(10);
            this.ControlsButton.Size = new System.Drawing.Size(200, 50);
            this.ControlsButton.TabIndex = 7;
            this.ControlsButton.Text = "CONTROLS";
            this.ControlsButton.UseVisualStyleBackColor = false;
            this.ControlsButton.Click += new System.EventHandler(this.ControlsButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Coral;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(412, 475);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Padding = new System.Windows.Forms.Padding(10);
            this.ExitButton.Size = new System.Drawing.Size(200, 50);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitGame);
            // 
            // ScoreListBox
            // 
            this.ListBox.BackColor = System.Drawing.Color.Black;
            this.ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBox.ForeColor = System.Drawing.Color.Coral;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 16;
            this.ListBox.Location = new System.Drawing.Point(286, 119);
            this.ListBox.Name = "ScoreListBox";
            this.ListBox.Size = new System.Drawing.Size(474, 468);
            this.ListBox.TabIndex = 9;
            this.ListBox.Visible = false;
            // 
            // SplashScreenV2
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ControlsButton);
            this.Controls.Add(this.ScoreButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreenV2";
            this.Text = "Sp2";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SplashScreenV2_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ScoreButton;
        private System.Windows.Forms.Button ControlsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ListBox ListBox;
    }
}