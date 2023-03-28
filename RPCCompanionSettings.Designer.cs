namespace RPCCompanion
{
    partial class RPCCompanionSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPCCompanionSettings));
            this.checkBox_EnableRPC = new System.Windows.Forms.CheckBox();
            this.label_NotRunningWarn = new System.Windows.Forms.Label();
            this.groupBox_StyleSelection = new System.Windows.Forms.GroupBox();
            this.minimalScreenshot = new System.Windows.Forms.PictureBox();
            this.detailedScreenshot = new System.Windows.Forms.PictureBox();
            this.radioButton_Minimal = new System.Windows.Forms.RadioButton();
            this.radioButton_Detailed = new System.Windows.Forms.RadioButton();
            this.label_WarnRPCConflicts = new System.Windows.Forms.Label();
            this.groupBox_ServerSelection = new System.Windows.Forms.GroupBox();
            this.radioButton_Akatsuki = new System.Windows.Forms.RadioButton();
            this.radioButton_Ripple = new System.Windows.Forms.RadioButton();
            this.radioButton_Bancho = new System.Windows.Forms.RadioButton();
            this.bugLabel = new System.Windows.Forms.LinkLabel();
            this.versionLabel = new System.Windows.Forms.LinkLabel();
            this.versionInfo = new System.Windows.Forms.Label();
            this.groupBox_StyleSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimalScreenshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailedScreenshot)).BeginInit();
            this.groupBox_ServerSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_EnableRPC
            // 
            this.checkBox_EnableRPC.AutoSize = true;
            this.checkBox_EnableRPC.Location = new System.Drawing.Point(3, 3);
            this.checkBox_EnableRPC.Name = "checkBox_EnableRPC";
            this.checkBox_EnableRPC.Size = new System.Drawing.Size(152, 19);
            this.checkBox_EnableRPC.TabIndex = 0;
            this.checkBox_EnableRPC.Text = "Enable RPC Companion";
            this.checkBox_EnableRPC.UseVisualStyleBackColor = true;
            this.checkBox_EnableRPC.CheckedChanged += new System.EventHandler(this.checkBox_EnableRPC_CheckedChanged);
            // 
            // label_NotRunningWarn
            // 
            this.label_NotRunningWarn.AutoSize = true;
            this.label_NotRunningWarn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_NotRunningWarn.ForeColor = System.Drawing.Color.Red;
            this.label_NotRunningWarn.Location = new System.Drawing.Point(357, 18);
            this.label_NotRunningWarn.Name = "label_NotRunningWarn";
            this.label_NotRunningWarn.Size = new System.Drawing.Size(247, 15);
            this.label_NotRunningWarn.TabIndex = 1;
            this.label_NotRunningWarn.Text = "RPC Companion requires osu! to be running";
            this.label_NotRunningWarn.Visible = false;
            // 
            // groupBox_StyleSelection
            // 
            this.groupBox_StyleSelection.Controls.Add(this.minimalScreenshot);
            this.groupBox_StyleSelection.Controls.Add(this.detailedScreenshot);
            this.groupBox_StyleSelection.Controls.Add(this.radioButton_Minimal);
            this.groupBox_StyleSelection.Controls.Add(this.radioButton_Detailed);
            this.groupBox_StyleSelection.Location = new System.Drawing.Point(3, 44);
            this.groupBox_StyleSelection.Name = "groupBox_StyleSelection";
            this.groupBox_StyleSelection.Size = new System.Drawing.Size(641, 346);
            this.groupBox_StyleSelection.TabIndex = 2;
            this.groupBox_StyleSelection.TabStop = false;
            this.groupBox_StyleSelection.Text = "Style";
            // 
            // minimalScreenshot
            // 
            this.minimalScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("minimalScreenshot.Image")));
            this.minimalScreenshot.Location = new System.Drawing.Point(329, 47);
            this.minimalScreenshot.Name = "minimalScreenshot";
            this.minimalScreenshot.Size = new System.Drawing.Size(306, 236);
            this.minimalScreenshot.TabIndex = 7;
            this.minimalScreenshot.TabStop = false;
            // 
            // detailedScreenshot
            // 
            this.detailedScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("detailedScreenshot.Image")));
            this.detailedScreenshot.Location = new System.Drawing.Point(6, 47);
            this.detailedScreenshot.Name = "detailedScreenshot";
            this.detailedScreenshot.Size = new System.Drawing.Size(304, 299);
            this.detailedScreenshot.TabIndex = 6;
            this.detailedScreenshot.TabStop = false;
            // 
            // radioButton_Minimal
            // 
            this.radioButton_Minimal.AutoSize = true;
            this.radioButton_Minimal.Location = new System.Drawing.Point(329, 22);
            this.radioButton_Minimal.Name = "radioButton_Minimal";
            this.radioButton_Minimal.Size = new System.Drawing.Size(69, 19);
            this.radioButton_Minimal.TabIndex = 3;
            this.radioButton_Minimal.Tag = "Minimal";
            this.radioButton_Minimal.Text = "Minimal";
            this.radioButton_Minimal.UseVisualStyleBackColor = true;
            // 
            // radioButton_Detailed
            // 
            this.radioButton_Detailed.AutoSize = true;
            this.radioButton_Detailed.Checked = true;
            this.radioButton_Detailed.Location = new System.Drawing.Point(6, 22);
            this.radioButton_Detailed.Name = "radioButton_Detailed";
            this.radioButton_Detailed.Size = new System.Drawing.Size(68, 19);
            this.radioButton_Detailed.TabIndex = 2;
            this.radioButton_Detailed.TabStop = true;
            this.radioButton_Detailed.Tag = "Detailed";
            this.radioButton_Detailed.Text = "Detailed";
            this.radioButton_Detailed.UseVisualStyleBackColor = true;
            this.radioButton_Detailed.CheckedChanged += new System.EventHandler(this.radioButton_Detailed_CheckedChanged);
            // 
            // label_WarnRPCConflicts
            // 
            this.label_WarnRPCConflicts.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label_WarnRPCConflicts.AutoSize = true;
            this.label_WarnRPCConflicts.Location = new System.Drawing.Point(259, 0);
            this.label_WarnRPCConflicts.Name = "label_WarnRPCConflicts";
            this.label_WarnRPCConflicts.Size = new System.Drawing.Size(345, 15);
            this.label_WarnRPCConflicts.TabIndex = 3;
            this.label_WarnRPCConflicts.Text = "RPC Companion requires Rich Presence disabled in osu! settings";
            // 
            // groupBox_ServerSelection
            // 
            this.groupBox_ServerSelection.Controls.Add(this.radioButton_Akatsuki);
            this.groupBox_ServerSelection.Controls.Add(this.radioButton_Ripple);
            this.groupBox_ServerSelection.Controls.Add(this.radioButton_Bancho);
            this.groupBox_ServerSelection.Location = new System.Drawing.Point(9, 396);
            this.groupBox_ServerSelection.Name = "groupBox_ServerSelection";
            this.groupBox_ServerSelection.Size = new System.Drawing.Size(152, 121);
            this.groupBox_ServerSelection.TabIndex = 6;
            this.groupBox_ServerSelection.TabStop = false;
            this.groupBox_ServerSelection.Text = "Server";
            // 
            // radioButton_Akatsuki
            // 
            this.radioButton_Akatsuki.AutoSize = true;
            this.radioButton_Akatsuki.Location = new System.Drawing.Point(0, 72);
            this.radioButton_Akatsuki.Name = "radioButton_Akatsuki";
            this.radioButton_Akatsuki.Size = new System.Drawing.Size(70, 19);
            this.radioButton_Akatsuki.TabIndex = 2;
            this.radioButton_Akatsuki.Tag = "Akatsuki";
            this.radioButton_Akatsuki.Text = "Akatsuki";
            this.radioButton_Akatsuki.UseVisualStyleBackColor = true;
            this.radioButton_Akatsuki.CheckedChanged += new System.EventHandler(this.radioButtons_Server_CheckChanged);
            // 
            // radioButton_Ripple
            // 
            this.radioButton_Ripple.AutoSize = true;
            this.radioButton_Ripple.Location = new System.Drawing.Point(0, 47);
            this.radioButton_Ripple.Name = "radioButton_Ripple";
            this.radioButton_Ripple.Size = new System.Drawing.Size(58, 19);
            this.radioButton_Ripple.TabIndex = 1;
            this.radioButton_Ripple.Tag = "Ripple";
            this.radioButton_Ripple.Text = "Ripple";
            this.radioButton_Ripple.UseVisualStyleBackColor = true;
            this.radioButton_Ripple.CheckedChanged += new System.EventHandler(this.radioButtons_Server_CheckChanged);
            // 
            // radioButton_Bancho
            // 
            this.radioButton_Bancho.AutoSize = true;
            this.radioButton_Bancho.Checked = true;
            this.radioButton_Bancho.Location = new System.Drawing.Point(0, 22);
            this.radioButton_Bancho.Name = "radioButton_Bancho";
            this.radioButton_Bancho.Size = new System.Drawing.Size(65, 19);
            this.radioButton_Bancho.TabIndex = 0;
            this.radioButton_Bancho.TabStop = true;
            this.radioButton_Bancho.Tag = "Bancho";
            this.radioButton_Bancho.Text = "Bancho";
            this.radioButton_Bancho.UseVisualStyleBackColor = true;
            this.radioButton_Bancho.CheckedChanged += new System.EventHandler(this.radioButtons_Server_CheckChanged);
            // 
            // bugLabel
            // 
            this.bugLabel.AutoSize = true;
            this.bugLabel.Location = new System.Drawing.Point(398, 533);
            this.bugLabel.Name = "bugLabel";
            this.bugLabel.Size = new System.Drawing.Size(246, 15);
            this.bugLabel.TabIndex = 7;
            this.bugLabel.TabStop = true;
            this.bugLabel.Text = "Click here to report a bug or request a feature";
            this.bugLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bugLabel_LinkClicked);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(453, 518);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(185, 15);
            this.versionLabel.TabIndex = 8;
            this.versionLabel.TabStop = true;
            this.versionLabel.Text = "Click here to get the latest version";
            this.versionLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.versionLabel_LinkClicked);
            // 
            // versionInfo
            // 
            this.versionInfo.AutoSize = true;
            this.versionInfo.Location = new System.Drawing.Point(513, 503);
            this.versionInfo.Name = "versionInfo";
            this.versionInfo.Size = new System.Drawing.Size(125, 15);
            this.versionInfo.TabIndex = 9;
            this.versionInfo.Text = "RPCCompanion v0.3.0";
            // 
            // RPCCompanionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.versionInfo);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.bugLabel);
            this.Controls.Add(this.groupBox_ServerSelection);
            this.Controls.Add(this.label_WarnRPCConflicts);
            this.Controls.Add(this.groupBox_StyleSelection);
            this.Controls.Add(this.label_NotRunningWarn);
            this.Controls.Add(this.checkBox_EnableRPC);
            this.Name = "RPCCompanionSettings";
            this.Size = new System.Drawing.Size(647, 557);
            this.groupBox_StyleSelection.ResumeLayout(false);
            this.groupBox_StyleSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimalScreenshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailedScreenshot)).EndInit();
            this.groupBox_ServerSelection.ResumeLayout(false);
            this.groupBox_ServerSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox checkBox_EnableRPC;
        private Label label_NotRunningWarn;
        private GroupBox groupBox_StyleSelection;
        private RadioButton radioButton_Minimal;
        private RadioButton radioButton_Detailed;
        private Label label_WarnRPCConflicts;
        private GroupBox groupBox_ServerSelection;
        private RadioButton radioButton_Akatsuki;
        private RadioButton radioButton_Ripple;
        private RadioButton radioButton_Bancho;
        private PictureBox detailedScreenshot;
        private PictureBox minimalScreenshot;
        private LinkLabel bugLabel;
        private LinkLabel versionLabel;
        private Label versionInfo;
    }
}
