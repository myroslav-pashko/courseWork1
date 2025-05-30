using System;
using System.Windows.Forms;
using courseWorkNew.Core;
using courseWorkNew.Services;

namespace courseWorkNew
{
    public partial class MainForm : Form
    {
        private double[,] currentMatrix;

        public MainForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;

            inputGrid.CellFormatting += Grid_CellFormatting;
            outputGrid.CellFormatting += Grid_CellFormatting;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(matrixSizeTextBox.Text))
            {
                MessageBox.Show("Please enter the matrix size.");
                return;
            }

            if (!int.TryParse(matrixSizeTextBox.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Matrix size must be a positive integer.");
                return;
            }

            currentMatrix = MatrixGenerator.GenerateRandom(size);
            MatrixUtils.DisplayToGrid(inputGrid, currentMatrix);
        }

        private void manualInputButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(matrixSizeTextBox.Text))
            {
                MessageBox.Show("Please enter the matrix size.");
                return;
            }

            if (!int.TryParse(matrixSizeTextBox.Text, out int size) || size <= 0)
            {
                MessageBox.Show("Matrix size must be a positive integer.");
                return;
            }

            inputGrid.Columns.Clear();
            inputGrid.Rows.Clear();
            inputGrid.AllowUserToAddRows = false;
            inputGrid.AutoGenerateColumns = false;

            inputGrid.ColumnCount = size;
            inputGrid.RowCount = size;

            for (int i = 0; i < size; i++)
            {
                inputGrid.Columns[i].Width = 50;
            }

            MessageBox.Show("Input data manually into the table.");
        }

        private void invertButton_Click(object sender, EventArgs e)
        {
            if (methodComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a matrix inversion method.");
                return;
            }

            if (inputGrid.RowCount == 0 || inputGrid.ColumnCount == 0)
            {
                MessageBox.Show("Input matrix is empty. Generate or load a matrix first.");
                return;
            }

            try
            {
                currentMatrix = MatrixUtils.ReadFromGrid(inputGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to read matrix: {ex.Message}");
                return;
            }

            try
            {
                string method = methodComboBox.SelectedItem.ToString();
                double[,] result = method switch
                {
                    "Framing" => FramingMethod.Invert(currentMatrix),
                    "LUP" => LUPDecomposition.Invert(currentMatrix),
                    _ => throw new Exception("Invalid method selected.")
                };

                MatrixUtils.DisplayToGrid(outputGrid, result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Matrix inversion failed: {ex.Message}");
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentMatrix = FileService.LoadFromFile(ofd.FileName);
                    MatrixUtils.DisplayToGrid(inputGrid, currentMatrix);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load matrix: {ex.Message}");
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (outputGrid.RowCount == 0 || outputGrid.ColumnCount == 0)
            {
                MessageBox.Show("No output matrix to save.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    double[,] result = MatrixUtils.ReadFromGrid(outputGrid);
                    FileService.SaveToFile(result, sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save matrix: {ex.Message}");
                }
            }
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is double doubleValue)
            {
                e.Value = doubleValue.ToString("F4");
                e.FormattingApplied = true;
            }
        }
    }
}
