namespace IISLog
{
    partial class FrmReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxGroupByType = new System.Windows.Forms.ComboBox();
            this.btnGroupByFileMinutes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numTimes = new System.Windows.Forms.NumericUpDown();
            this.cbxLogFolder = new System.Windows.Forms.ComboBox();
            this.cbxLogFile = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoAvg = new System.Windows.Forms.RadioButton();
            this.rdoSum = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxURL = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxGroupByType);
            this.groupBox1.Controls.Add(this.btnGroupByFileMinutes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numTimes);
            this.groupBox1.Controls.Add(this.cbxLogFolder);
            this.groupBox1.Controls.Add(this.cbxLogFile);
            this.groupBox1.Location = new System.Drawing.Point(21, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NO.1";
            // 
            // cbxGroupByType
            // 
            this.cbxGroupByType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGroupByType.FormattingEnabled = true;
            this.cbxGroupByType.Items.AddRange(new object[] {
            "1Minute",
            "10Minute",
            "1Hour"});
            this.cbxGroupByType.Location = new System.Drawing.Point(310, 55);
            this.cbxGroupByType.Name = "cbxGroupByType";
            this.cbxGroupByType.Size = new System.Drawing.Size(121, 20);
            this.cbxGroupByType.TabIndex = 13;
            // 
            // btnGroupByFileMinutes
            // 
            this.btnGroupByFileMinutes.Location = new System.Drawing.Point(500, 47);
            this.btnGroupByFileMinutes.Name = "btnGroupByFileMinutes";
            this.btnGroupByFileMinutes.Size = new System.Drawing.Size(166, 42);
            this.btnGroupByFileMinutes.TabIndex = 12;
            this.btnGroupByFileMinutes.Text = "Group By File And Minutes";
            this.btnGroupByFileMinutes.UseVisualStyleBackColor = true;
            this.btnGroupByFileMinutes.Click += new System.EventHandler(this.btnGroupByFileMinutes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Group By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Times(ms):";
            // 
            // numTimes
            // 
            this.numTimes.Location = new System.Drawing.Point(125, 53);
            this.numTimes.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTimes.Name = "numTimes";
            this.numTimes.Size = new System.Drawing.Size(72, 21);
            this.numTimes.TabIndex = 9;
            this.numTimes.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cbxLogFolder
            // 
            this.cbxLogFolder.DropDownWidth = 400;
            this.cbxLogFolder.FormattingEnabled = true;
            this.cbxLogFolder.Location = new System.Drawing.Point(15, 20);
            this.cbxLogFolder.Name = "cbxLogFolder";
            this.cbxLogFolder.Size = new System.Drawing.Size(197, 20);
            this.cbxLogFolder.TabIndex = 7;
            this.cbxLogFolder.Leave += new System.EventHandler(this.cbxLogFile_Enter);
            // 
            // cbxLogFile
            // 
            this.cbxLogFile.DropDownWidth = 400;
            this.cbxLogFile.FormattingEnabled = true;
            this.cbxLogFile.Location = new System.Drawing.Point(218, 19);
            this.cbxLogFile.Name = "cbxLogFile";
            this.cbxLogFile.Size = new System.Drawing.Size(448, 20);
            this.cbxLogFile.TabIndex = 7;
            this.cbxLogFile.Enter += new System.EventHandler(this.cbxLogFile_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAvg);
            this.groupBox2.Controls.Add(this.rdoSum);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbxURL);
            this.groupBox2.Location = new System.Drawing.Point(21, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 105);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NO.2";
            // 
            // rdoAvg
            // 
            this.rdoAvg.AutoSize = true;
            this.rdoAvg.Checked = true;
            this.rdoAvg.Location = new System.Drawing.Point(226, 68);
            this.rdoAvg.Name = "rdoAvg";
            this.rdoAvg.Size = new System.Drawing.Size(41, 16);
            this.rdoAvg.TabIndex = 13;
            this.rdoAvg.TabStop = true;
            this.rdoAvg.Text = "Avg";
            this.rdoAvg.UseVisualStyleBackColor = true;
            // 
            // rdoSum
            // 
            this.rdoSum.AutoSize = true;
            this.rdoSum.Location = new System.Drawing.Point(125, 68);
            this.rdoSum.Name = "rdoSum";
            this.rdoSum.Size = new System.Drawing.Size(41, 16);
            this.rdoSum.TabIndex = 13;
            this.rdoSum.Text = "Sum";
            this.rdoSum.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(500, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 42);
            this.button2.TabIndex = 12;
            this.button2.Text = "Gen Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "URL:";
            // 
            // cbxURL
            // 
            this.cbxURL.DropDownWidth = 400;
            this.cbxURL.FormattingEnabled = true;
            this.cbxURL.Location = new System.Drawing.Point(48, 20);
            this.cbxURL.Name = "cbxURL";
            this.cbxURL.Size = new System.Drawing.Size(415, 20);
            this.cbxURL.TabIndex = 7;
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 293);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReport";
            this.Text = "FrmReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGroupByFileMinutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTimes;
        private System.Windows.Forms.ComboBox cbxLogFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxGroupByType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoAvg;
        private System.Windows.Forms.RadioButton rdoSum;
        private System.Windows.Forms.ComboBox cbxLogFolder;
        private System.Windows.Forms.ComboBox cbxURL;
    }
}