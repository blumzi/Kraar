namespace ASCOM.DenkoviUSB
{
    partial class SetupDialogForm
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.textBoxFtdiIndex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxLabel7 = new System.Windows.Forms.TextBox();
            this.textBoxLabel6 = new System.Windows.Forms.TextBox();
            this.textBoxLabel5 = new System.Windows.Forms.TextBox();
            this.textBoxLabel4 = new System.Windows.Forms.TextBox();
            this.textBoxLabel3 = new System.Windows.Forms.TextBox();
            this.textBoxLabel2 = new System.Windows.Forms.TextBox();
            this.textBoxLabel1 = new System.Windows.Forms.TextBox();
            this.textBoxLabel0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxPersistance = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.tableLayoutPanelLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(381, 267);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(59, 24);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(381, 297);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 25);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Denkovi 8 Relays USB card driver.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.DenkoviUSB.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(392, 9);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "FTDI index";
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(24, 296);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(69, 17);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Trace on";
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // textBoxFtdiIndex
            // 
            this.textBoxFtdiIndex.Location = new System.Drawing.Point(91, 44);
            this.textBoxFtdiIndex.Name = "textBoxFtdiIndex";
            this.textBoxFtdiIndex.Size = new System.Drawing.Size(16, 20);
            this.textBoxFtdiIndex.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Relay labels";
            // 
            // tableLayoutPanelLabels
            // 
            this.tableLayoutPanelLabels.ColumnCount = 2;
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel7, 1, 7);
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel6, 1, 6);
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel5, 1, 5);
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel4, 1, 4);
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel3, 1, 3);
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel2, 1, 2);
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel1, 1, 1);
            this.tableLayoutPanelLabels.Controls.Add(this.textBoxLabel0, 1, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanelLabels.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanelLabels.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanelLabels.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanelLabels.Controls.Add(this.label10, 0, 6);
            this.tableLayoutPanelLabels.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanelLabels.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(24, 128);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 8;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(344, 152);
            this.tableLayoutPanelLabels.TabIndex = 9;
            // 
            // textBoxLabel7
            // 
            this.textBoxLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel7.Location = new System.Drawing.Point(49, 136);
            this.textBoxLabel7.Name = "textBoxLabel7";
            this.textBoxLabel7.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel7.TabIndex = 17;
            this.textBoxLabel7.Tag = "7";
            this.textBoxLabel7.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // textBoxLabel6
            // 
            this.textBoxLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel6.Location = new System.Drawing.Point(49, 117);
            this.textBoxLabel6.Name = "textBoxLabel6";
            this.textBoxLabel6.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel6.TabIndex = 16;
            this.textBoxLabel6.Tag = "6";
            this.textBoxLabel6.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // textBoxLabel5
            // 
            this.textBoxLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel5.Location = new System.Drawing.Point(49, 98);
            this.textBoxLabel5.Name = "textBoxLabel5";
            this.textBoxLabel5.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel5.TabIndex = 15;
            this.textBoxLabel5.Tag = "5";
            this.textBoxLabel5.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // textBoxLabel4
            // 
            this.textBoxLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel4.Location = new System.Drawing.Point(49, 79);
            this.textBoxLabel4.Name = "textBoxLabel4";
            this.textBoxLabel4.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel4.TabIndex = 14;
            this.textBoxLabel4.Tag = "4";
            this.textBoxLabel4.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // textBoxLabel3
            // 
            this.textBoxLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel3.Location = new System.Drawing.Point(49, 60);
            this.textBoxLabel3.Name = "textBoxLabel3";
            this.textBoxLabel3.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel3.TabIndex = 13;
            this.textBoxLabel3.Tag = "3";
            this.textBoxLabel3.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // textBoxLabel2
            // 
            this.textBoxLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel2.Location = new System.Drawing.Point(49, 41);
            this.textBoxLabel2.Name = "textBoxLabel2";
            this.textBoxLabel2.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel2.TabIndex = 12;
            this.textBoxLabel2.Tag = "2";
            this.textBoxLabel2.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // textBoxLabel1
            // 
            this.textBoxLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel1.Location = new System.Drawing.Point(49, 22);
            this.textBoxLabel1.Name = "textBoxLabel1";
            this.textBoxLabel1.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel1.TabIndex = 11;
            this.textBoxLabel1.Tag = "1";
            this.textBoxLabel1.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // textBoxLabel0
            // 
            this.textBoxLabel0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLabel0.Location = new System.Drawing.Point(49, 3);
            this.textBoxLabel0.Name = "textBoxLabel0";
            this.textBoxLabel0.Size = new System.Drawing.Size(292, 20);
            this.textBoxLabel0.TabIndex = 10;
            this.textBoxLabel0.Tag = "0";
            this.textBoxLabel0.Validated += new System.EventHandler(this.textBox_Validated);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Relay1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Relay2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Relay3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 19);
            this.label7.TabIndex = 3;
            this.label7.Text = "Relay4";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 19);
            this.label9.TabIndex = 5;
            this.label9.Text = "Relay6";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "Relay7";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 19);
            this.label11.TabIndex = 7;
            this.label11.Text = "Relay8";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Relay5";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxPersistance
            // 
            this.checkBoxPersistance.AutoSize = true;
            this.checkBoxPersistance.Checked = true;
            this.checkBoxPersistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPersistance.Location = new System.Drawing.Point(24, 72);
            this.checkBoxPersistance.Name = "checkBoxPersistance";
            this.checkBoxPersistance.Size = new System.Drawing.Size(158, 17);
            this.checkBoxPersistance.TabIndex = 10;
            this.checkBoxPersistance.Text = "Save and restore relay state";
            this.checkBoxPersistance.UseVisualStyleBackColor = true;
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 330);
            this.Controls.Add(this.checkBoxPersistance);
            this.Controls.Add(this.tableLayoutPanelLabels);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFtdiIndex);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DenkoviUSB Setup";
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.TextBox textBoxFtdiIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabels;
        private System.Windows.Forms.TextBox textBoxLabel7;
        private System.Windows.Forms.TextBox textBoxLabel6;
        private System.Windows.Forms.TextBox textBoxLabel5;
        private System.Windows.Forms.TextBox textBoxLabel4;
        private System.Windows.Forms.TextBox textBoxLabel3;
        private System.Windows.Forms.TextBox textBoxLabel2;
        private System.Windows.Forms.TextBox textBoxLabel1;
        private System.Windows.Forms.TextBox textBoxLabel0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxPersistance;
    }
}