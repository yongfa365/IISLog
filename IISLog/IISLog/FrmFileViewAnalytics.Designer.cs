namespace IISLog
{
    partial class FrmFileViewAnalytics
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
            this.btnRun = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbxLogFile = new System.Windows.Forms.ComboBox();
            this.numTimes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxLogFolder = new System.Windows.Forms.ComboBox();
            this.cbxSystem = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(664, 11);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 49);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(727, 450);
            this.dataGridView1.TabIndex = 1;
            // 
            // cbxLogFile
            // 
            this.cbxLogFile.DropDownWidth = 400;
            this.cbxLogFile.FormattingEnabled = true;
            this.cbxLogFile.Location = new System.Drawing.Point(210, 12);
            this.cbxLogFile.Name = "cbxLogFile";
            this.cbxLogFile.Size = new System.Drawing.Size(448, 20);
            this.cbxLogFile.TabIndex = 2;
            this.cbxLogFile.Enter += new System.EventHandler(this.cbxLogFolder_SelectedIndexChanged);
            // 
            // numTimes
            // 
            this.numTimes.Location = new System.Drawing.Point(117, 40);
            this.numTimes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTimes.Name = "numTimes";
            this.numTimes.Size = new System.Drawing.Size(72, 21);
            this.numTimes.TabIndex = 4;
            this.numTimes.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Times(ms):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "System:";
            // 
            // cbxLogFolder
            // 
            this.cbxLogFolder.DropDownWidth = 400;
            this.cbxLogFolder.FormattingEnabled = true;
            this.cbxLogFolder.Location = new System.Drawing.Point(15, 11);
            this.cbxLogFolder.Name = "cbxLogFolder";
            this.cbxLogFolder.Size = new System.Drawing.Size(189, 20);
            this.cbxLogFolder.TabIndex = 7;
            this.cbxLogFolder.SelectedIndexChanged += new System.EventHandler(this.cbxLogFolder_SelectedIndexChanged);
            // 
            // cbxSystem
            // 
            this.cbxSystem.DropDownWidth = 400;
            this.cbxSystem.FormattingEnabled = true;
            this.cbxSystem.Items.AddRange(new object[] {
            "Package",
            "Hotel",
            "Ticket",
            "CRM"});
            this.cbxSystem.Location = new System.Drawing.Point(271, 42);
            this.cbxSystem.Name = "cbxSystem";
            this.cbxSystem.Size = new System.Drawing.Size(189, 20);
            this.cbxSystem.TabIndex = 7;
            // 
            // FrmFileViewAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 540);
            this.Controls.Add(this.cbxSystem);
            this.Controls.Add(this.cbxLogFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTimes);
            this.Controls.Add(this.cbxLogFile);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRun);
            this.Name = "FrmFileViewAnalytics";
            this.Text = "FrmFileViewAnalytics";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbxLogFile;
        private System.Windows.Forms.NumericUpDown numTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxLogFolder;
        private System.Windows.Forms.ComboBox cbxSystem;
    }
}