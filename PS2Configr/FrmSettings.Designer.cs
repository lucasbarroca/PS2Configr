namespace PS2Configr
{
    partial class FrmSettings
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
            this.txtEmuPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btEmuPath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkGPad = new System.Windows.Forms.CheckBox();
            this.chkFull = new System.Windows.Forms.CheckBox();
            this.chkNoGUI = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiskPath = new System.Windows.Forms.TextBox();
            this.btDiskPath = new System.Windows.Forms.Button();
            this.oEmuPath = new System.Windows.Forms.OpenFileDialog();
            this.fbDiskPath = new System.Windows.Forms.FolderBrowserDialog();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmuPath
            // 
            this.txtEmuPath.Location = new System.Drawing.Point(9, 32);
            this.txtEmuPath.Name = "txtEmuPath";
            this.txtEmuPath.Size = new System.Drawing.Size(195, 20);
            this.txtEmuPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location";
            // 
            // btEmuPath
            // 
            this.btEmuPath.Location = new System.Drawing.Point(210, 32);
            this.btEmuPath.Name = "btEmuPath";
            this.btEmuPath.Size = new System.Drawing.Size(35, 20);
            this.btEmuPath.TabIndex = 2;
            this.btEmuPath.Text = "...";
            this.btEmuPath.UseVisualStyleBackColor = true;
            this.btEmuPath.Click += new System.EventHandler(this.btEmuPath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEmuPath);
            this.groupBox1.Controls.Add(this.btEmuPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PCSX2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkGPad);
            this.groupBox2.Controls.Add(this.chkFull);
            this.groupBox2.Controls.Add(this.chkNoGUI);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDiskPath);
            this.groupBox2.Controls.Add(this.btDiskPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Games Default";
            // 
            // chkGPad
            // 
            this.chkGPad.AutoSize = true;
            this.chkGPad.Location = new System.Drawing.Point(9, 104);
            this.chkGPad.Name = "chkGPad";
            this.chkGPad.Size = new System.Drawing.Size(112, 17);
            this.chkGPad.TabIndex = 7;
            this.chkGPad.Text = "Use global Lilypad";
            this.chkGPad.UseVisualStyleBackColor = true;
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Location = new System.Drawing.Point(9, 58);
            this.chkFull.Name = "chkFull";
            this.chkFull.Size = new System.Drawing.Size(124, 17);
            this.chkFull.TabIndex = 5;
            this.chkFull.Text = "Launch in Fullscreen";
            this.chkFull.UseVisualStyleBackColor = true;
            // 
            // chkNoGUI
            // 
            this.chkNoGUI.AutoSize = true;
            this.chkNoGUI.Location = new System.Drawing.Point(9, 81);
            this.chkNoGUI.Name = "chkNoGUI";
            this.chkNoGUI.Size = new System.Drawing.Size(130, 17);
            this.chkNoGUI.TabIndex = 6;
            this.chkNoGUI.Text = "Hide PCSX2 Interface";
            this.chkNoGUI.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Disk path";
            // 
            // txtDiskPath
            // 
            this.txtDiskPath.Location = new System.Drawing.Point(9, 32);
            this.txtDiskPath.Name = "txtDiskPath";
            this.txtDiskPath.Size = new System.Drawing.Size(195, 20);
            this.txtDiskPath.TabIndex = 3;
            this.txtDiskPath.TextChanged += new System.EventHandler(this.txtDiskPath_TextChanged);
            // 
            // btDiskPath
            // 
            this.btDiskPath.Location = new System.Drawing.Point(210, 32);
            this.btDiskPath.Name = "btDiskPath";
            this.btDiskPath.Size = new System.Drawing.Size(35, 20);
            this.btDiskPath.TabIndex = 4;
            this.btDiskPath.Text = "...";
            this.btDiskPath.UseVisualStyleBackColor = true;
            this.btDiskPath.Click += new System.EventHandler(this.btDiskPath_Click);
            // 
            // oEmuPath
            // 
            this.oEmuPath.FileName = "pcsx2.exe";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(12, 214);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(159, 34);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "SAVE";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(177, 214);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(86, 34);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "CANCEL";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 260);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmuPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btEmuPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiskPath;
        private System.Windows.Forms.Button btDiskPath;
        private System.Windows.Forms.OpenFileDialog oEmuPath;
        private System.Windows.Forms.FolderBrowserDialog fbDiskPath;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.CheckBox chkFull;
        private System.Windows.Forms.CheckBox chkNoGUI;
        private System.Windows.Forms.CheckBox chkGPad;
    }
}