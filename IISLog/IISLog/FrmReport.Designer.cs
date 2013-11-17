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
            this.txtLogFolder = new System.Windows.Forms.TextBox();
            this.cbxLogFile = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSum = new System.Windows.Forms.CheckBox();
            this.chkAvg = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Controls.Add(this.txtLogFolder);
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
            1000,
            0,
            0,
            0});
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.Location = new System.Drawing.Point(21, 20);
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.Size = new System.Drawing.Size(176, 21);
            this.txtLogFolder.TabIndex = 8;
            this.txtLogFolder.Enter += new System.EventHandler(this.cbxLogFile_Enter);
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
            this.groupBox2.Controls.Add(this.chkAvg);
            this.groupBox2.Controls.Add(this.chkSum);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txtURL);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(21, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 105);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NO.2";
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
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(49, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(414, 21);
            this.txtURL.TabIndex = 12;
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
            // chkSum
            // 
            this.chkSum.AutoSize = true;
            this.chkSum.Location = new System.Drawing.Point(146, 66);
            this.chkSum.Name = "chkSum";
            this.chkSum.Size = new System.Drawing.Size(42, 16);
            this.chkSum.TabIndex = 13;
            this.chkSum.Text = "Sum";
            this.chkSum.UseVisualStyleBackColor = true;
            // 
            // chkAvg
            // 
            this.chkAvg.AutoSize = true;
            this.chkAvg.Checked = true;
            this.chkAvg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAvg.Location = new System.Drawing.Point(246, 66);
            this.chkAvg.Name = "chkAvg";
            this.chkAvg.Size = new System.Drawing.Size(42, 16);
            this.chkAvg.TabIndex = 14;
            this.chkAvg.Text = "Avg";
            this.chkAvg.UseVisualStyleBackColor = true;
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 355);
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
        private System.Windows.Forms.TextBox txtLogFolder;
        private System.Windows.Forms.ComboBox cbxLogFile;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxGroupByType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAvg;
        private System.Windows.Forms.CheckBox chkSum;
    }
}