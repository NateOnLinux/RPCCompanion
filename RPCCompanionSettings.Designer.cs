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
            this.checkBox_EnableRPC = new System.Windows.Forms.CheckBox();
            this.label_NotRunningWarn = new System.Windows.Forms.Label();
            this.groupBox_StyleSelection = new System.Windows.Forms.GroupBox();
            this.radioButton_Minimal = new System.Windows.Forms.RadioButton();
            this.radioButton_Detailed = new System.Windows.Forms.RadioButton();
            this.label_WarnRPCConflicts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.profileLinkTb = new System.Windows.Forms.TextBox();
            this.groupBox_StyleSelection.SuspendLayout();
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
            this.groupBox_StyleSelection.Controls.Add(this.profileLinkTb);
            this.groupBox_StyleSelection.Controls.Add(this.label1);
            this.groupBox_StyleSelection.Controls.Add(this.radioButton_Minimal);
            this.groupBox_StyleSelection.Controls.Add(this.radioButton_Detailed);
            this.groupBox_StyleSelection.Location = new System.Drawing.Point(3, 44);
            this.groupBox_StyleSelection.Name = "groupBox_StyleSelection";
            this.groupBox_StyleSelection.Size = new System.Drawing.Size(601, 345);
            this.groupBox_StyleSelection.TabIndex = 2;
            this.groupBox_StyleSelection.TabStop = false;
            this.groupBox_StyleSelection.Text = "Style";
            // 
            // radioButton_Minimal
            // 
            this.radioButton_Minimal.AutoSize = true;
            this.radioButton_Minimal.Location = new System.Drawing.Point(6, 109);
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
            this.radioButton_Detailed.Location = new System.Drawing.Point(6, 41);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your profile link";
            // 
            // profileLinkTb
            // 
            this.profileLinkTb.Location = new System.Drawing.Point(6, 81);
            this.profileLinkTb.Name = "profileLinkTb";
            this.profileLinkTb.PlaceholderText = "https://osu.ppy.sh/users/...";
            this.profileLinkTb.Size = new System.Drawing.Size(197, 23);
            this.profileLinkTb.TabIndex = 5;
            this.profileLinkTb.TextChanged += new System.EventHandler(this.profileLinkTb_TextChanged);
            // 
            // RPCCompanionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_WarnRPCConflicts);
            this.Controls.Add(this.groupBox_StyleSelection);
            this.Controls.Add(this.label_NotRunningWarn);
            this.Controls.Add(this.checkBox_EnableRPC);
            this.Name = "RPCCompanionSettings";
            this.Size = new System.Drawing.Size(607, 424);
            this.groupBox_StyleSelection.ResumeLayout(false);
            this.groupBox_StyleSelection.PerformLayout();
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
        private TextBox profileLinkTb;
        private Label label1;
    }
}
