using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImagePuzzleApp
{
    public partial class Form1 : Form
    {
        private const int gridSize = 4;
        private const int puzzleSize = 620;

        private int pieceSize;
        private Bitmap originalImage;
        private readonly List<Bitmap> puzzlePieces = new List<Bitmap>();
        private List<int> currentOrder = new List<int>();
        private readonly List<Button> pieceButtons = new List<Button>();

        private int firstSelectedIndex = -1;
        private int moves = 0;
        private int elapsedSeconds = 0;

        private readonly System.Windows.Forms.Timer gameTimer =
        new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();

            pieceSize = puzzleSize / gridSize;
            CreatePuzzleGrid();

            gameTimer.Interval = 1000;
            gameTimer.Tick += (s, e) =>
            {
                elapsedSeconds++;
                UpdateStats();
            };

            lblTitle.ForeColor = Color.FromArgb(40, 60, 90);
            lblTitle.Text = "IMAGE PUZZLE";
        }

        private void CreatePuzzleGrid()
        {
            pnlPuzzle.Controls.Clear();
            pieceButtons.Clear();

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button
                    {
                        Width = pieceSize,
                        Height = pieceSize,
                        Left = col * pieceSize,
                        Top = row * pieceSize,
                        Tag = row * gridSize + col,
                        FlatStyle = FlatStyle.Flat,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BackColor = Color.White
                    };

                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.White;
                    btn.Click += PieceButton_Click;

                    pnlPuzzle.Controls.Add(btn);
                    pieceButtons.Add(btn);
                }
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (Image loaded = Image.FromFile(ofd.FileName))
                    {
                        originalImage?.Dispose();
                        originalImage = new Bitmap(loaded, new Size(puzzleSize, puzzleSize));

                        Image oldPreview = picPreview.Image;
                        picPreview.Image = new Bitmap(
                            loaded,
                            new Size(picPreview.Width, picPreview.Height));
                        oldPreview?.Dispose();
                    }

                    SplitImageIntoPieces();
                    ResetPuzzle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Could not load the selected image.\n" + ex.Message,
                        "Image Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SplitImageIntoPieces()
        {
            foreach (Bitmap piece in puzzlePieces)
                piece.Dispose();

            puzzlePieces.Clear();

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Rectangle srcRect = new Rectangle(
                        col * pieceSize,
                        row * pieceSize,
                        pieceSize,
                        pieceSize);

                    Bitmap piece = new Bitmap(pieceSize, pieceSize);

                    using (Graphics g = Graphics.FromImage(piece))
                    {
                        g.DrawImage(
                            originalImage,
                            new Rectangle(0, 0, pieceSize, pieceSize),
                            srcRect,
                            GraphicsUnit.Pixel);
                    }

                    puzzlePieces.Add(piece);
                }
            }
        }

        private void ResetPuzzle()
        {
            if (puzzlePieces.Count == 0)
                return;

            currentOrder = Enumerable.Range(0, puzzlePieces.Count).ToList();

            moves = 0;
            elapsedSeconds = 0;
            firstSelectedIndex = -1;

            gameTimer.Stop();
            UpdateStats();
            DisplayPuzzle();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetPuzzle();
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            if (puzzlePieces.Count == 0)
            {
                MessageBox.Show(
                    "Please load an image first.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Random rnd = new Random();
            currentOrder = currentOrder.OrderBy(x => rnd.Next()).ToList();

            if (IsSolved())
                currentOrder.Reverse();

            moves = 0;
            elapsedSeconds = 0;
            firstSelectedIndex = -1;

            DisplayPuzzle();
            UpdateStats();

            gameTimer.Stop();
            gameTimer.Start();
        }

        private void DisplayPuzzle()
        {
            for (int i = 0; i < pieceButtons.Count; i++)
            {
                int pieceIndex = currentOrder[i];

                pieceButtons[i].BackgroundImage = puzzlePieces[pieceIndex];
                pieceButtons[i].Text = "";
                pieceButtons[i].BackColor = Color.White;
                pieceButtons[i].FlatAppearance.BorderColor =
                    Color.FromArgb(220, 225, 235);
            }
        }

        private void PieceButton_Click(object sender, EventArgs e)
        {
            if (puzzlePieces.Count == 0)
                return;

            Button clickedButton = sender as Button;
            int clickedIndex = pieceButtons.IndexOf(clickedButton);

            if (firstSelectedIndex == -1)
            {
                firstSelectedIndex = clickedIndex;
                pieceButtons[clickedIndex].BackColor = Color.LightBlue;
                pieceButtons[clickedIndex].FlatAppearance.BorderColor =
                    Color.DodgerBlue;
            }
            else if (clickedIndex != firstSelectedIndex)
            {
                int first = firstSelectedIndex;

                int temp = currentOrder[first];
                currentOrder[first] = currentOrder[clickedIndex];
                currentOrder[clickedIndex] = temp;

                moves++;
                firstSelectedIndex = -1;

                DisplayPuzzle();
                UpdateStats();
                CheckIfSolved();
            }
            else
            {
                firstSelectedIndex = -1;
                DisplayPuzzle();
            }
        }

        private bool IsSolved()
        {
            for (int i = 0; i < currentOrder.Count; i++)
            {
                if (currentOrder[i] != i)
                    return false;
            }

            return true;
        }

        private void CheckIfSolved()
        {
            if (!IsSolved())
                return;

            gameTimer.Stop();

            MessageBox.Show(
                $"Congratulations! You solved the puzzle!\n\n" +
                $"Moves: {moves}\n" +
                $"Time: {elapsedSeconds / 60:00}:{elapsedSeconds % 60:00}",
                "Puzzle Completed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void UpdateStats()
        {
            lblMoves.Text = $"Moves: {moves}";
            lblTimer.Text =
                $"Time: {elapsedSeconds / 60:00}:{elapsedSeconds % 60:00}";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gameTimer.Stop();
            gameTimer.Dispose();

            originalImage?.Dispose();

            foreach (Bitmap piece in puzzlePieces)
                piece.Dispose();

            picPreview.Image?.Dispose();

            base.OnFormClosed(e);
        }
    }
}

