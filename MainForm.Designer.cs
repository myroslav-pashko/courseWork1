namespace courseWorkNew
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView inputGrid;
        private System.Windows.Forms.DataGridView outputGrid;
        private System.Windows.Forms.ComboBox methodComboBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button invertButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox matrixSizeTextBox;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Button manualInputButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            inputGrid = new DataGridView();
            outputGrid = new DataGridView();
            methodComboBox = new ComboBox();
            generateButton = new Button();
            invertButton = new Button();
            loadButton = new Button();
            saveButton = new Button();
            matrixSizeTextBox = new TextBox();
            sizeLabel = new Label();
            manualInputButton = new Button();

            ((System.ComponentModel.ISupportInitialize)inputGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)outputGrid).BeginInit();
            SuspendLayout();
            // 
            // inputGrid
            // 
            inputGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inputGrid.Location = new Point(14, 58);
            inputGrid.Margin = new Padding(4, 3, 4, 3);
            inputGrid.Name = "inputGrid";
            inputGrid.Size = new Size(350, 346);
            inputGrid.TabIndex = 0;
            // 
            // outputGrid
            // 
            outputGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            outputGrid.Location = new Point(385, 58);
            outputGrid.Margin = new Padding(4, 3, 4, 3);
            outputGrid.Name = "outputGrid";
            outputGrid.Size = new Size(350, 346);
            outputGrid.TabIndex = 1;
            // 
            // methodComboBox
            // 
            methodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            methodComboBox.Items.AddRange(new object[] { "Framing", "LUP" });
            methodComboBox.Location = new Point(14, 415);
            methodComboBox.Margin = new Padding(4, 3, 4, 3);
            methodComboBox.Name = "methodComboBox";
            methodComboBox.Size = new Size(174, 23);
            methodComboBox.TabIndex = 2;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(210, 415);
            generateButton.Margin = new Padding(4, 3, 4, 3);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(117, 27);
            generateButton.TabIndex = 3;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // invertButton
            // 
            invertButton.Location = new Point(338, 415);
            invertButton.Margin = new Padding(4, 3, 4, 3);
            invertButton.Name = "invertButton";
            invertButton.Size = new Size(117, 27);
            invertButton.TabIndex = 4;
            invertButton.Text = "Invert";
            invertButton.UseVisualStyleBackColor = true;
            invertButton.Click += invertButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(467, 415);
            loadButton.Margin = new Padding(4, 3, 4, 3);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(117, 27);
            loadButton.TabIndex = 5;
            loadButton.Text = "Load from file";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(595, 415);
            saveButton.Margin = new Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 27);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save to file";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // matrixSizeTextBox
            // 
            matrixSizeTextBox.Location = new Point(105, 14);
            matrixSizeTextBox.Margin = new Padding(4, 3, 4, 3);
            matrixSizeTextBox.Name = "matrixSizeTextBox";
            matrixSizeTextBox.Size = new Size(116, 23);
            matrixSizeTextBox.TabIndex = 7;
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Location = new Point(14, 17);
            sizeLabel.Margin = new Padding(4, 0, 4, 0);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(66, 15);
            sizeLabel.TabIndex = 8;
            sizeLabel.Text = "Matrix Size:";
            // 
            // manualInputButton
            // 
            manualInputButton.Location = new Point(14, 445);
            manualInputButton.Margin = new Padding(4, 3, 4, 3);
            manualInputButton.Name = "manualInputButton";
            manualInputButton.Size = new Size(174, 27);
            manualInputButton.TabIndex = 9;
            manualInputButton.Text = "Preparing for input";
            manualInputButton.UseVisualStyleBackColor = true;
            manualInputButton.Click += manualInputButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 500);

            Controls.Add(manualInputButton);
            Controls.Add(sizeLabel);
            Controls.Add(matrixSizeTextBox);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(invertButton);
            Controls.Add(generateButton);
            Controls.Add(methodComboBox);
            Controls.Add(outputGrid);
            Controls.Add(inputGrid);

            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Matrix Inversion Tool";
            ((System.ComponentModel.ISupportInitialize)inputGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)outputGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
