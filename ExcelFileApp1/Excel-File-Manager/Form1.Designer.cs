namespace ExcelFileApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCreateFolder = new Button();
            btnWriteLog = new Button();
            btnCreateExcel = new Button();
            btnReadFiles = new Button();
            btnDeleteFolder = new Button();
            lstFiles = new ListBox();
            lblFileCount = new Label();
            lblFileCount.AutoSize = true;
            lblFileCount.Name = "lblFileCount";
            lblFileCount.Text = "Files: 0";

            Controls.Add(lblFileCount);
            SuspendLayout();
            // 
            // btnCreateFolder
            // 
            btnCreateFolder.Location = new Point(37, 28);
            btnCreateFolder.Name = "btnCreateFolder";
            btnCreateFolder.Size = new Size(148, 29);
            btnCreateFolder.TabIndex = 0;
            btnCreateFolder.Text = "Create Folder";
            btnCreateFolder.UseVisualStyleBackColor = true;
            btnCreateFolder.Click += btnCreateFolder_Click;
            // 
            // btnWriteLog
            // 
            btnWriteLog.Location = new Point(37, 82);
            btnWriteLog.Name = "btnWriteLog";
            btnWriteLog.Size = new Size(148, 29);
            btnWriteLog.TabIndex = 1;
            btnWriteLog.Text = "Write Log";
            btnWriteLog.UseVisualStyleBackColor = true;
            btnWriteLog.Click += btnWriteLog_Click;
            // 
            // btnCreateExcel
            // 
            btnCreateExcel.Location = new Point(37, 132);
            btnCreateExcel.Name = "btnCreateExcel";
            btnCreateExcel.Size = new Size(148, 29);
            btnCreateExcel.TabIndex = 2;
            btnCreateExcel.Text = "Create Excel";
            btnCreateExcel.UseVisualStyleBackColor = true;
            btnCreateExcel.Click += btnCreateExcel_Click;
            // 
            // btnReadFiles
            // 
            btnReadFiles.Location = new Point(37, 188);
            btnReadFiles.Name = "btnReadFiles";
            btnReadFiles.Size = new Size(148, 29);
            btnReadFiles.TabIndex = 3;
            btnReadFiles.Text = "Read Files";
            btnReadFiles.UseVisualStyleBackColor = true;
            btnReadFiles.Click += btnReadFiles_Click;
            // 
            // btnDeleteFolder
            // 
            btnDeleteFolder.Location = new Point(37, 246);
            btnDeleteFolder.Name = "btnDeleteFolder";
            btnDeleteFolder.Size = new Size(148, 29);
            btnDeleteFolder.TabIndex = 4;
            btnDeleteFolder.Text = "Delete Folder";
            btnDeleteFolder.UseVisualStyleBackColor = true;
            btnDeleteFolder.Click += btnDeleteFolder_Click;
            // 
            // lstFiles
            // 
            lstFiles.FormattingEnabled = true;
            lstFiles.Location = new Point(271, 132);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(152, 144);
            lstFiles.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 450);
            Controls.Add(lstFiles);
            Controls.Add(btnDeleteFolder);
            Controls.Add(btnReadFiles);
            Controls.Add(btnCreateExcel);
            Controls.Add(btnWriteLog);
            Controls.Add(btnCreateFolder);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreateFolder;
        private Button btnWriteLog;
        private Button btnCreateExcel;
        private Button btnReadFiles;
        private Button btnDeleteFolder;
        private ListBox lstFiles;
        private Label lblFileCount;
    }
}
