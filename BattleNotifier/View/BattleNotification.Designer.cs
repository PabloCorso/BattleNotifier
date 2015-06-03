namespace BattleNotifier.View
{
    partial class BattleNotification
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
            this.components = new System.ComponentModel.Container();
            this.PrintMapDialog = new System.Windows.Forms.PrintDialog();
            this.PrintMapDocument = new System.Drawing.Printing.PrintDocument();
            this.BattleCountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.AttributesToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MapCheckBox = new System.Windows.Forms.CheckBox();
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.BattleTypeLabel = new System.Windows.Forms.Label();
            this.AttributesLabel = new System.Windows.Forms.Label();
            this.HeadlineLinkLabel = new System.Windows.Forms.LinkLabel();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PrintMapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrintMapDialog
            // 
            this.PrintMapDialog.UseEXDialog = true;
            // 
            // PrintMapDocument
            // 
            this.PrintMapDocument.OriginAtMargins = true;
            this.PrintMapDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintMapDocument_PrintPage);
            // 
            // BattleCountdownTimer
            // 
            this.BattleCountdownTimer.Interval = 1000;
            this.BattleCountdownTimer.Tick += new System.EventHandler(this.BattleCountdownTimer_Tick);
            // 
            // AttributesToolTip
            // 
            this.AttributesToolTip.IsBalloon = true;
            // 
            // MapCheckBox
            // 
            this.MapCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.MapCheckBox.AutoSize = true;
            this.MapCheckBox.FlatAppearance.BorderSize = 0;
            this.MapCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MapCheckBox.Location = new System.Drawing.Point(157, 69);
            this.MapCheckBox.Name = "MapCheckBox";
            this.MapCheckBox.Size = new System.Drawing.Size(38, 23);
            this.MapCheckBox.TabIndex = 6;
            this.MapCheckBox.Text = "Map";
            this.MapCheckBox.UseVisualStyleBackColor = true;
            this.MapCheckBox.CheckedChanged += new System.EventHandler(this.MapCheckBox_CheckedChanged);
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.AutoSize = true;
            this.CountdownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountdownLabel.Location = new System.Drawing.Point(65, 70);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(0, 17);
            this.CountdownLabel.TabIndex = 5;
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurationLabel.Location = new System.Drawing.Point(8, 70);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(57, 17);
            this.DurationLabel.TabIndex = 3;
            this.DurationLabel.Text = "25 mins";
            // 
            // BattleTypeLabel
            // 
            this.BattleTypeLabel.AutoSize = true;
            this.BattleTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.BattleTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BattleTypeLabel.Location = new System.Drawing.Point(8, 25);
            this.BattleTypeLabel.Name = "BattleTypeLabel";
            this.BattleTypeLabel.Size = new System.Drawing.Size(76, 17);
            this.BattleTypeLabel.TabIndex = 2;
            this.BattleTypeLabel.Text = "First Finish";
            // 
            // AttributesLabel
            // 
            this.AttributesLabel.AutoSize = true;
            this.AttributesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttributesLabel.Location = new System.Drawing.Point(8, 42);
            this.AttributesLabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.AttributesLabel.Name = "AttributesLabel";
            this.AttributesLabel.Size = new System.Drawing.Size(0, 13);
            this.AttributesLabel.TabIndex = 1;
            this.AttributesLabel.Click += new System.EventHandler(this.AttributesLabel_Click);
            // 
            // HeadlineLinkLabel
            // 
            this.HeadlineLinkLabel.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.HeadlineLinkLabel.AutoSize = true;
            this.HeadlineLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadlineLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.HeadlineLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.HeadlineLinkLabel.Location = new System.Drawing.Point(8, 8);
            this.HeadlineLinkLabel.Name = "HeadlineLinkLabel";
            this.HeadlineLinkLabel.Size = new System.Drawing.Size(113, 17);
            this.HeadlineLinkLabel.TabIndex = 0;
            this.HeadlineLinkLabel.TabStop = true;
            this.HeadlineLinkLabel.Text = "Pob0984 by Pab";
            this.HeadlineLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HeadlineLinkLabel_LinkClicked);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.SystemColors.Control;
            this.MinimizeButton.BackgroundImage = global::BattleNotifier.Properties.Resources.minimize_window_16;
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Location = new System.Drawing.Point(193, 1);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(20, 17);
            this.MinimizeButton.TabIndex = 8;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Visible = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.SystemColors.Control;
            this.CloseButton.BackgroundImage = global::BattleNotifier.Properties.Resources.close_window_16;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(214, 1);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(20, 17);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.TabStop = false;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PrintMapButton
            // 
            this.PrintMapButton.BackgroundImage = global::BattleNotifier.Properties.Resources.printer;
            this.PrintMapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrintMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintMapButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.PrintMapButton.Location = new System.Drawing.Point(201, 70);
            this.PrintMapButton.Name = "PrintMapButton";
            this.PrintMapButton.Size = new System.Drawing.Size(21, 20);
            this.PrintMapButton.TabIndex = 4;
            this.PrintMapButton.UseVisualStyleBackColor = true;
            this.PrintMapButton.Click += new System.EventHandler(this.PrintMapButton_Click);
            // 
            // BattleNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 96);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.MapCheckBox);
            this.Controls.Add(this.CountdownLabel);
            this.Controls.Add(this.PrintMapButton);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.BattleTypeLabel);
            this.Controls.Add(this.AttributesLabel);
            this.Controls.Add(this.HeadlineLinkLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BattleNotification";
            this.Text = "Battle Notification";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BattleNotification_FormClosed_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel HeadlineLinkLabel;
        private System.Windows.Forms.Label AttributesLabel;
        private System.Windows.Forms.Label BattleTypeLabel;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.Button PrintMapButton;
        private System.Windows.Forms.PrintDialog PrintMapDialog;
        private System.Drawing.Printing.PrintDocument PrintMapDocument;
        private System.Windows.Forms.Timer BattleCountdownTimer;
        private System.Windows.Forms.Label CountdownLabel;
        private System.Windows.Forms.ToolTip AttributesToolTip;
        private System.Windows.Forms.CheckBox MapCheckBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MinimizeButton;
    }
}