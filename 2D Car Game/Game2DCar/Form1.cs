using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Game2DCar
{
    public partial class Form1 : Form
    {
        private int speed = 8;
        private int score = 0;
        private int roadLineOffset = 0;

        private bool moveLeft = false;
        private bool moveRight = false;
        private bool gameOver = false;

        private readonly Random random = new Random();

        private const int RoadLeft = 40;
        private const int LaneWidth = 166;

        private const int CarWidth = 50;
        private const int CarHeight = 80;

        private const int PlayerMoveSpeed = 6;

        private readonly int[] lanes = { 98, 264, 430 };

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            KeyPreview = true;

            Paint += Form1_Paint;

            LoadCarImages();

            playerCar.Size = new Size(CarWidth, CarHeight);
            obstacle1.Size = new Size(CarWidth, CarHeight);
            obstacle2.Size = new Size(CarWidth, CarHeight);
            obstacle3.Size = new Size(CarWidth, CarHeight);

            playerCar.SizeMode = PictureBoxSizeMode.Zoom;
            obstacle1.SizeMode = PictureBoxSizeMode.Zoom;
            obstacle2.SizeMode = PictureBoxSizeMode.Zoom;
            obstacle3.SizeMode = PictureBoxSizeMode.Zoom;

            lblScore.BringToFront();
            lblGameOver.BringToFront();

            lblGameOver.Visible = false;
        }

        private void LoadCarImages()
        {
            // Player: face north (top of the screen).
            playerCar.Image = LoadCarImage(
                "pitstop_car_3.png",
                RotateFlipType.Rotate180FlipNone
            );

            // Opponent cars: rotate horizontal sprites to vertical.
            obstacle1.Image = LoadCarImage(
                "car_red.png",
                RotateFlipType.Rotate270FlipNone
            );

            obstacle2.Image = LoadCarImage(
                "car_black.png",
                RotateFlipType.Rotate270FlipNone
            );

            obstacle3.Image = LoadCarImage(
                "car_yellow.png",
                RotateFlipType.Rotate270FlipNone
            );
        }

        private Image LoadCarImage(
            string fileName,
            RotateFlipType rotation)
        {
            string assetsPath =
                @"F:\C# AppTest\2D Car Game\Game2DCar\Assets";

            string path = Path.Combine(assetsPath, fileName);

            if (!File.Exists(path))
            {
                MessageBox.Show(
                    "Image not found:\n" + path,
                    "Missing car image",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return null;
            }

            using (Image original = Image.FromFile(path))
            {
                // Create a 32-bit image so PNG transparency is preserved.
                Bitmap image = new Bitmap(
                    original.Width,
                    original.Height,
                    PixelFormat.Format32bppArgb
                );

                using (Graphics g = Graphics.FromImage(image))
                {
                    g.CompositingMode =
                        CompositingMode.SourceCopy;

                    g.DrawImage(
                        original,
                        new Rectangle(
                            0,
                            0,
                            original.Width,
                            original.Height
                        )
                    );
                }

                image.RotateFlip(rotation);

                return image;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Grass
            g.Clear(Color.ForestGreen);

            // Road
            using (SolidBrush roadBrush =
                   new SolidBrush(Color.FromArgb(45, 45, 45)))
            {
                g.FillRectangle(
                    roadBrush,
                    RoadLeft,
                    0,
                    LaneWidth * 3,
                    ClientSize.Height
                );
            }

            // Road borders
            using (Pen borderPen = new Pen(Color.White, 5))
            {
                g.DrawLine(
                    borderPen,
                    RoadLeft,
                    0,
                    RoadLeft,
                    ClientSize.Height
                );

                g.DrawLine(
                    borderPen,
                    RoadLeft + LaneWidth * 3,
                    0,
                    RoadLeft + LaneWidth * 3,
                    ClientSize.Height
                );
            }

            // Moving lane markings
            using (Pen lanePen = new Pen(Color.White, 4))
            {
                lanePen.DashPattern = new float[] { 12, 18 };

                int line1X = RoadLeft + LaneWidth;
                int line2X = RoadLeft + LaneWidth * 2;

                g.DrawLine(
                    lanePen,
                    line1X,
                    -80 + roadLineOffset,
                    line1X,
                    ClientSize.Height
                );

                g.DrawLine(
                    lanePen,
                    line2X,
                    -80 + roadLineOffset,
                    line2X,
                    ClientSize.Height
                );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetGamePositions();

            lblScore.Text = "Score: 0";
            lblGameOver.Visible = false;

            gameTimer.Interval = 20;
            gameTimer.Start();

            ActiveControl = null;
            Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    RestartGame();
                }

                return;
            }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft = true;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight = true;
                e.Handled = true;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft = false;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight = false;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            // Smooth player movement
            if (moveLeft)
            {
                playerCar.Left -= PlayerMoveSpeed;
            }

            if (moveRight)
            {
                playerCar.Left += PlayerMoveSpeed;
            }

            // Keep player inside the road
            int leftLimit = RoadLeft + 5;

            int rightLimit =
                RoadLeft + LaneWidth * 3 - playerCar.Width - 5;

            playerCar.Left = Math.Max(
                leftLimit,
                Math.Min(playerCar.Left, rightLimit)
            );

            // Move road markings
            roadLineOffset += speed;

            if (roadLineOffset >= 30)
            {
                roadLineOffset = 0;
            }

            Invalidate();

            // Move opponent cars
            obstacle1.Top += speed;
            obstacle2.Top += speed;
            obstacle3.Top += speed;

            UpdateObstacle(obstacle1);
            UpdateObstacle(obstacle2);
            UpdateObstacle(obstacle3);

            lblScore.Text = "Score: " + score;

            // Gradually increase difficulty
            speed = Math.Min(8 + score / 5, 20);

            // Collision detection
            if (playerCar.Bounds.IntersectsWith(obstacle1.Bounds) ||
                playerCar.Bounds.IntersectsWith(obstacle2.Bounds) ||
                playerCar.Bounds.IntersectsWith(obstacle3.Bounds))
            {
                GameOver();
            }
        }

        private void UpdateObstacle(PictureBox obstacle)
        {
            if (obstacle.Top > ClientSize.Height)
            {
                obstacle.Top =
                    -CarHeight - random.Next(150, 300);

                int laneIndex = random.Next(lanes.Length);

                obstacle.Left = lanes[laneIndex];

                score++;
            }
        }

        private void ResetGamePositions()
        {
            playerCar.Left = lanes[1];
            playerCar.Top = ClientSize.Height - CarHeight - 30;

            obstacle1.Left = lanes[0];
            obstacle1.Top = -250;

            obstacle2.Left = lanes[1];
            obstacle2.Top = -450;

            obstacle3.Left = lanes[2];
            obstacle3.Top = -650;
        }

        private void GameOver()
        {
            gameOver = true;

            gameTimer.Stop();

            moveLeft = false;
            moveRight = false;

            lblGameOver.Text =
                "GAME OVER\nScore: " + score +
                "\nPress ENTER to restart";

            lblGameOver.Visible = true;
            lblGameOver.BringToFront();
        }

        private void RestartGame()
        {
            score = 0;
            speed = 8;
            roadLineOffset = 0;

            moveLeft = false;
            moveRight = false;
            gameOver = false;

            ResetGamePositions();

            lblScore.Text = "Score: 0";
            lblGameOver.Visible = false;

            Invalidate();

            gameTimer.Start();

            ActiveControl = null;
            Focus();
        }
    }
}



