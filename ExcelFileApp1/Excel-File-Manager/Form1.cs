using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ExcelFileApp1
{
    public partial class Form1 : Form
    {
        private readonly string dataFolder =
            Path.Combine(Application.StartupPath, "Data");

        public Form1()
        {
            InitializeComponent();
            RefreshFileList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(dataFolder);
                WriteLog("Data folder created or already exists.");
                RefreshFileList();

                MessageBox.Show(
                    "Data folder is ready.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Could not create the folder.", ex);
            }
        }

        private void btnWriteLog_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(dataFolder);
                WriteLog("User requested an activity log.");

                RefreshFileList();

                MessageBox.Show(
                    "Activity logged successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Could not write the activity log.", ex);
            }
        }

        private void btnCreateExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(dataFolder);

                DataTable dt = new DataTable("Employees");
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Department", typeof(string));
                dt.Columns.Add("Salary", typeof(decimal));

                dt.Rows.Add(1, "Ahmet", "IT", 30000m);
                dt.Rows.Add(2, "Mehmet", "HR", 12000m);
                dt.Rows.Add(3, "Ayse", "Finance", 20000m);

                string excelPath =
                    Path.Combine(dataFolder, "Report.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Employees");

                    worksheet.Cell(1, 1).InsertTable(dt);

                    var header = worksheet.Range(
                        1, 1, 1, dt.Columns.Count);

                    header.Style.Font.Bold = true;
                    header.Style.Font.FontColor =
                        XLColor.White;
                    header.Style.Fill.BackgroundColor =
                        XLColor.DarkBlue;

                    worksheet.Column(4).Style.NumberFormat.Format =
                        "#,##0.00";

                    worksheet.SheetView.FreezeRows(1);
                    worksheet.Columns().AdjustToContents();

                    worksheet.Cell(5, 1).Value = "Report generated:";
                    worksheet.Cell(5, 2).Value = DateTime.Now;
                    worksheet.Cell(5, 2).Style.DateFormat.Format =
                        "yyyy-MM-dd HH:mm:ss";

                    workbook.SaveAs(excelPath);
                }

                WriteLog("Excel report created: Report.xlsx");
                RefreshFileList();

                MessageBox.Show(
                    "Excel report created successfully!\n\n" + excelPath,
                    "Report Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError(
                    "Could not create the Excel report. If the file is open in Excel, close it and try again.",
                    ex);
            }
        }

        private void btnReadFiles_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshFileList();
                WriteLog("Files list refreshed.");
                RefreshFileList();
            }
            catch (Exception ex)
            {
                ShowError("Could not read the files.", ex);
            }
        }

        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(dataFolder))
                {
                    MessageBox.Show(
                        "The Data folder does not exist.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete the Data folder and all its contents?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                Directory.Delete(dataFolder, true);
                lstFiles.Items.Clear();
                UpdateFileCount();

                MessageBox.Show(
                    "Data folder deleted successfully.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Could not delete the Data folder.", ex);
            }
        }

        private void RefreshFileList()
        {
            lstFiles.Items.Clear();

            if (Directory.Exists(dataFolder))
            {
                string[] files = Directory.GetFiles(
                    dataFolder, "*", SearchOption.TopDirectoryOnly);

                foreach (string file in files.OrderBy(Path.GetFileName))
                {
                    lstFiles.Items.Add(Path.GetFileName(file));
                }
            }

            UpdateFileCount();
        }

        private void UpdateFileCount()
        {
            lblFileCount.Text = $"Files: {lstFiles.Items.Count}";
        }

        private void WriteLog(string message)
        {
            Directory.CreateDirectory(dataFolder);

            string logPath = Path.Combine(dataFolder, "app_log.txt");

            string logEntry =
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";

            File.AppendAllText(logPath, logEntry);
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                $"{message}\n\nDetails: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}


