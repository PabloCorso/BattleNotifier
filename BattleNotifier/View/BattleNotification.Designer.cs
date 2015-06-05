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
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.AttributesLabel = new System.Windows.Forms.Label();
            this.HeadlineLinkLabel = new System.Windows.Forms.LinkLabel();
            this.BattleTypeLabel = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MapCheckBox = new System.Windows.Forms.CheckBox();
            this.PrintMapButton = new System.Windows.Forms.Button();
            this.AttributesOutlineLabel = new BattleNotifier.View.Controls.OutlineLabel();
            this.HeadlineOutlineLabel = new BattleNotifier.View.Controls.OutlineLabel();
            this.CountdownOutlineLabel = new BattleNotifier.View.Controls.OutlineLabel();
            this.DurationOutlineLabel = new BattleNotifier.View.Controls.OutlineLabel();
            this.BattleTypeOutlineLabel = new BattleNotifier.View.Controls.OutlineLabel();
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
            // BattleTypeLabel
            // 
            this.BattleTypeLabel.AutoSize = true;
            this.BattleTypeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.BattleTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BattleTypeLabel.Location = new System.Drawing.Point(8, 25);
            this.BattleTypeLabel.Name = "BattleTypeLabel";
            this.BattleTypeLabel.Size = new System.Drawing.Size(76, 17);
            this.BattleTypeLabel.TabIndex = 2;
            this.BattleTypeLabel.Text = "First Finish";
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.SystemColors.Control;
            this.MinimizeButton.BackgroundImage = global::BattleNotifier.Properties.Resources.minimize;
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Location = new System.Drawing.Point(186, 2);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(21, 17);
            this.MinimizeButton.TabIndex = 8;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Visible = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            this.MinimizeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseMove);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.SystemColors.Control;
            this.CloseButton.BackgroundImage = global::BattleNotifier.Properties.Resources.close;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(211, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(21, 17);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.TabStop = false;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MapCheckBox
            // 
            this.MapCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.MapCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            // PrintMapButton
            // 
            this.PrintMapButton.BackgroundImage = global::BattleNotifier.Properties.Resources.printer;
            this.PrintMapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrintMapButton.FlatAppearance.BorderSize = 0;
            this.PrintMapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintMapButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.PrintMapButton.Location = new System.Drawing.Point(201, 70);
            this.PrintMapButton.Name = "PrintMapButton";
            this.PrintMapButton.Size = new System.Drawing.Size(21, 20);
            this.PrintMapButton.TabIndex = 4;
            this.PrintMapButton.UseVisualStyleBackColor = true;
            this.PrintMapButton.Click += new System.EventHandler(this.PrintMapButton_Click);
            // 
            // AttributesOutlineLabel
            // 
            this.AttributesOutlineLabel.AutoSize = true;
            this.AttributesOutlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AttributesOutlineLabel.ForeColor = System.Drawing.Color.Yellow;
            this.AttributesOutlineLabel.Location = new System.Drawing.Point(8, 42);
            this.AttributesOutlineLabel.Name = "AttributesOutlineLabel";
            this.AttributesOutlineLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.AttributesOutlineLabel.OutlineWidth = 1.5F;
            this.AttributesOutlineLabel.Size = new System.Drawing.Size(0, 13);
            this.AttributesOutlineLabel.TabIndex = 14;
            this.AttributesOutlineLabel.Visible = false;
            this.AttributesOutlineLabel.Click += new System.EventHandler(this.AttributesLabel_Click);
            // 
            // HeadlineOutlineLabel
            // 
            this.HeadlineOutlineLabel.AutoSize = true;
            this.HeadlineOutlineLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HeadlineOutlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.HeadlineOutlineLabel.ForeColor = System.Drawing.Color.Yellow;
            this.HeadlineOutlineLabel.Location = new System.Drawing.Point(8, 8);
            this.HeadlineOutlineLabel.Name = "HeadlineOutlineLabel";
            this.HeadlineOutlineLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.HeadlineOutlineLabel.OutlineWidth = 1.5F;
            this.HeadlineOutlineLabel.Size = new System.Drawing.Size(113, 17);
            this.HeadlineOutlineLabel.TabIndex = 13;
            this.HeadlineOutlineLabel.Text = "Pob0980 by Pab";
            this.HeadlineOutlineLabel.Visible = false;
            this.HeadlineOutlineLabel.Click += new System.EventHandler(this.HeadlineOutlineLabel_Click);
            // 
            // CountdownOutlineLabel
            // 
            this.CountdownOutlineLabel.AutoSize = true;
            this.CountdownOutlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CountdownOutlineLabel.ForeColor = System.Drawing.Color.Yellow;
            this.CountdownOutlineLabel.Location = new System.Drawing.Point(65, 70);
            this.CountdownOutlineLabel.Name = "CountdownOutlineLabel";
            this.CountdownOutlineLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.CountdownOutlineLabel.OutlineWidth = 1.5F;
            this.CountdownOutlineLabel.Size = new System.Drawing.Size(0, 17);
            this.CountdownOutlineLabel.TabIndex = 12;
            // 
            // DurationOutlineLabel
            // 
            this.DurationOutlineLabel.AutoSize = true;
            this.DurationOutlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DurationOutlineLabel.ForeColor = System.Drawing.Color.Yellow;
            this.DurationOutlineLabel.Location = new System.Drawing.Point(8, 70);
            this.DurationOutlineLabel.Name = "DurationOutlineLabel";
            this.DurationOutlineLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.DurationOutlineLabel.OutlineWidth = 1.5F;
            this.DurationOutlineLabel.Size = new System.Drawing.Size(57, 17);
            this.DurationOutlineLabel.TabIndex = 11;
            this.DurationOutlineLabel.Text = "25 mins";
            this.DurationOutlineLabel.Visible = false;
            // 
            // BattleTypeOutlineLabel
            // 
            this.BattleTypeOutlineLabel.AutoSize = true;
            this.BattleTypeOutlineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BattleTypeOutlineLabel.ForeColor = System.Drawing.Color.Yellow;
            this.BattleTypeOutlineLabel.Location = new System.Drawing.Point(8, 25);
            this.BattleTypeOutlineLabel.Name = "BattleTypeOutlineLabel";
            this.BattleTypeOutlineLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.BattleTypeOutlineLabel.OutlineWidth = 1.5F;
            this.BattleTypeOutlineLabel.Size = new System.Drawing.Size(76, 17);
            this.BattleTypeOutlineLabel.TabIndex = 9;
            this.BattleTypeOutlineLabel.Text = "First Finish";
            this.BattleTypeOutlineLabel.Visible = false;
            // 
            // BattleNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 96);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.AttributesOutlineLabel);
            this.Controls.Add(this.HeadlineOutlineLabel);
            this.Controls.Add(this.CountdownOutlineLabel);
            this.Controls.Add(this.DurationOutlineLabel);
            this.Controls.Add(this.BattleTypeOutlineLabel);
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
        private System.Windows.Forms.Label BattleTypeLabel;
        private Controls.OutlineLabel BattleTypeOutlineLabel;
        private Controls.OutlineLabel DurationOutlineLabel;
        private Controls.OutlineLabel CountdownOutlineLabel;
        private Controls.OutlineLabel HeadlineOutlineLabel;
        private Controls.OutlineLabel AttributesOutlineLabel;
    }
}