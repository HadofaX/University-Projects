namespace Game2DCar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            playerCar = new PictureBox();
            obstacle1 = new PictureBox();
            obstacle2 = new PictureBox();
            obstacle3 = new PictureBox();

            lblScore = new Label();
            lblGameOver = new Label();

            gameTimer = new System.Windows.Forms.Timer(components);

            ((System.ComponentModel.ISupportInitialize)playerCar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle3).BeginInit();

            SuspendLayout();

            // Player car
            playerCar.BackColor = Color.FromArgb(45, 45, 45);
            playerCar.Location = new Point(261, 540);
            playerCar.Name = "playerCar";
            playerCar.Size = new Size(60, 80);
            playerCar.SizeMode = PictureBoxSizeMode.Zoom;
            playerCar.TabIndex = 0;
            playerCar.TabStop = false;

            // Obstacle 1
            obstacle1.BackColor = Color.FromArgb(45, 45, 45);
            obstacle1.Location = new Point(60, 50);
            obstacle1.Name = "obstacle1";
            obstacle1.Size = new Size(60, 80);
            obstacle1.SizeMode = PictureBoxSizeMode.Zoom;
            obstacle1.TabIndex = 1;
            obstacle1.TabStop = false;

            // Obstacle 2
            obstacle2.BackColor = Color.FromArgb(45, 45, 45);
            obstacle2.Location = new Point(226, -150);
            obstacle2.Name = "obstacle2";
            obstacle2.Size = new Size(60, 80);
            obstacle2.SizeMode = PictureBoxSizeMode.Zoom;
            obstacle2.TabIndex = 2;
            obstacle2.TabStop = false;

            // Obstacle 3
            obstacle3.BackColor = Color.FromArgb(45, 45, 45);
            obstacle3.Location = new Point(392, -300);
            obstacle3.Name = "obstacle3";
            obstacle3.Size = new Size(60, 80);
            obstacle3.SizeMode = PictureBoxSizeMode.Zoom;
            obstacle3.TabIndex = 3;
            obstacle3.TabStop = false;

            // Score label
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.FromArgb(35, 35, 35);
            lblScore.Font = new Font(
                "Segoe UI",
                14F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(55, 15);
            lblScore.Name = "lblScore";
            lblScore.Padding = new Padding(8, 4, 8, 4);
            lblScore.Size = new Size(110, 40);
            lblScore.TabIndex = 4;
            lblScore.Text = "Score: 0";

            // Game Over label
            lblGameOver.BackColor = Color.FromArgb(210, 20, 20, 20);
            lblGameOver.Font = new Font(
                "Segoe UI",
                17F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblGameOver.ForeColor = Color.Gold;
            lblGameOver.Location = new Point(55, 270);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(470, 90);
            lblGameOver.TabIndex = 5;
            lblGameOver.Text = "GAME OVER - Press Enter";
            lblGameOver.TextAlign = ContentAlignment.MiddleCenter;
            lblGameOver.Visible = false;

            // Game timer
            gameTimer.Enabled = false;
            gameTimer.Interval = 20;
            gameTimer.Tick += gameTimer_Tick;

            // Form
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 115, 55);
            ClientSize = new Size(582, 653);

            Controls.Add(lblScore);
            Controls.Add(lblGameOver);

            Controls.Add(obstacle1);
            Controls.Add(obstacle2);
            Controls.Add(obstacle3);
            Controls.Add(playerCar);

            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "2D Car Game";

            Load += Form1_Load;
            KeyDown += Form1_KeyDown;

            ((System.ComponentModel.ISupportInitialize)playerCar).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle1).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle2).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle3).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox playerCar;
        private PictureBox obstacle1;
        private PictureBox obstacle2;
        private PictureBox obstacle3;

        private Label lblScore;
        private Label lblGameOver;

        private System.Windows.Forms.Timer gameTimer;
    }
}






