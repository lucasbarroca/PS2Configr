namespace PS2Configr
{
    partial class FrmAddGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.btAddGame = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.btGamePath = new System.Windows.Forms.Button();
            this.chkNoGUI = new System.Windows.Forms.CheckBox();
            this.chkFull = new System.Windows.Forms.CheckBox();
            this.oGamePath = new System.Windows.Forms.OpenFileDialog();
            this.chkGPad = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File";
            // 
            // txtGameName
            // 
            this.txtGameName.Location = new System.Drawing.Point(12, 64);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(375, 20);
            this.txtGameName.TabIndex = 2;
            // 
            // btAddGame
            // 
            this.btAddGame.Location = new System.Drawing.Point(12, 113);
            this.btAddGame.Name = "btAddGame";
            this.btAddGame.Size = new System.Drawing.Size(283, 34);
            this.btAddGame.TabIndex = 6;
            this.btAddGame.Text = "ADD GAME";
            this.btAddGame.UseVisualStyleBackColor = true;
            this.btAddGame.Click += new System.EventHandler(this.btAddGame_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(301, 113);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(86, 34);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "CANCEL";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Title";
            // 
            // txtGamePath
            // 
            this.txtGamePath.Location = new System.Drawing.Point(12, 25);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(334, 20);
            this.txtGamePath.TabIndex = 0;
            // 
            // btGamePath
            // 
            this.btGamePath.Location = new System.Drawing.Point(352, 25);
            this.btGamePath.Name = "btGamePath";
            this.btGamePath.Size = new System.Drawing.Size(35, 20);
            this.btGamePath.TabIndex = 1;
            this.btGamePath.Text = "...";
            this.btGamePath.UseVisualStyleBackColor = true;
            this.btGamePath.Click += new System.EventHandler(this.btGamePath_Click);
            // 
            // chkNoGUI
            // 
            this.chkNoGUI.AutoSize = true;
            this.chkNoGUI.Location = new System.Drawing.Point(142, 90);
            this.chkNoGUI.Name = "chkNoGUI";
            this.chkNoGUI.Size = new System.Drawing.Size(130, 17);
            this.chkNoGUI.TabIndex = 4;
            this.chkNoGUI.Text = "Hide PCSX2 Interface";
            this.chkNoGUI.UseVisualStyleBackColor = true;
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Location = new System.Drawing.Point(12, 90);
            this.chkFull.Name = "chkFull";
            this.chkFull.Size = new System.Drawing.Size(124, 17);
            this.chkFull.TabIndex = 3;
            this.chkFull.Text = "Launch in Fullscreen";
            this.chkFull.UseVisualStyleBackColor = true;
            // 
            // oGamePath
            // 
            this.oGamePath.FileName = "pcsx2.exe";
            // 
            // chkGPad
            // 
            this.chkGPad.AutoSize = true;
            this.chkGPad.Location = new System.Drawing.Point(275, 90);
            this.chkGPad.Name = "chkGPad";
            this.chkGPad.Size = new System.Drawing.Size(112, 17);
            this.chkGPad.TabIndex = 5;
            this.chkGPad.Text = "Use global Lilypad";
            this.chkGPad.UseVisualStyleBackColor = true;
            // 
            // FrmAddGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 159);
            this.Controls.Add(this.chkGPad);
            this.Controls.Add(this.chkFull);
            this.Controls.Add(this.chkNoGUI);
            this.Controls.Add(this.btGamePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGamePath);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAddGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGameName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAddGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Game";
            this.Load += new System.EventHandler(this.FrmAddGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Button btAddGame;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Button btGamePath;
        private System.Windows.Forms.CheckBox chkNoGUI;
        private System.Windows.Forms.CheckBox chkFull;
        private System.Windows.Forms.OpenFileDialog oGamePath;
        private System.Windows.Forms.CheckBox chkGPad;
    }
}