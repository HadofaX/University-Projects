namespace ImagePuzzleApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnShuffle = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.pnlPuzzle = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();

            // btnLoadImage
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(52, 120, 246);
            this.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImage.FlatAppearance.BorderSize = 0;
            this.btnLoadImage.ForeColor = System.Drawing.Color.White;
            this.btnLoadImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadImage.Location = new System.Drawing.Point(28, 24);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(130, 42);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);

            // btnShuffle
            this.btnShuffle.BackColor = System.Drawing.Color.FromArgb(34, 166, 120);
            this.btnShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShuffle.FlatAppearance.BorderSize = 0;
            this.btnShuffle.ForeColor = System.Drawing.Color.White;
            this.btnShuffle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnShuffle.Location = new System.Drawing.Point(176, 24);
            this.btnShuffle.Name = "btnShuffle";
            this.btnShuffle.Size = new System.Drawing.Size(120, 42);
            this.btnShuffle.TabIndex = 1;
            this.btnShuffle.Text = "Shuffle";
            this.btnShuffle.UseVisualStyleBackColor = false;
            this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);

            // btnReset
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(90, 100, 120);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(314, 24);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 42);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 60, 90);
            this.lblTitle.Location = new System.Drawing.Point(28, 82);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 41);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "IMAGE PUZZLE";

            // picPreview
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(690, 160);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(220, 220);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 4;
            this.picPreview.TabStop = false;

            // pnlPuzzle
            this.pnlPuzzle.BackColor = System.Drawing.Color.FromArgb(230, 235, 243);
            this.pnlPuzzle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPuzzle.Location = new System.Drawing.Point(28, 140);
            this.pnlPuzzle.Name = "pnlPuzzle";
            this.pnlPuzzle.Size = new System.Drawing.Size(620, 620);
            this.pnlPuzzle.TabIndex = 5;

            // lblPreview
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPreview.ForeColor = System.Drawing.Color.FromArgb(40, 60, 90);
            this.lblPreview.Location = new System.Drawing.Point(690, 120);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(143, 28);
            this.lblPreview.TabIndex = 6;
            this.lblPreview.Text = "Image Preview";

            // lblMoves
            this.lblMoves.AutoSize = true;
            this.lblMoves.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMoves.ForeColor = System.Drawing.Color.FromArgb(40, 60, 90);
            this.lblMoves.Location = new System.Drawing.Point(690, 420);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(100, 28);
            this.lblMoves.TabIndex = 7;
            this.lblMoves.Text = "Moves: 0";

            // lblTimer
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(40, 60, 90);
            this.lblTimer.Location = new System.Drawing.Point(690, 465);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(140, 28);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.Text = "Time: 00:00";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 252);
            this.ClientSize = new System.Drawing.Size(950, 800);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.pnlPuzzle);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnShuffle);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Puzzle App";

            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnShuffle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Panel pnlPuzzle;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.Label lblTimer;
    }
}

