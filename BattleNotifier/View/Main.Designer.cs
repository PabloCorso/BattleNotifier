﻿namespace BattleNotifier.View
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.SeparatorLabel = new System.Windows.Forms.Label();
            this.NavigateToCurrentBattleButton = new System.Windows.Forms.Button();
            this.NavigateToSettingsButton = new System.Windows.Forms.Button();
            this.NavigateHomeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.BalloonTipText = "Battle Notifier";
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Battle Notifier";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            this.NotifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDown);
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.Location = new System.Drawing.Point(14, 34);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(413, 297);
            this.BackgroundPanel.TabIndex = 0;
            // 
            // SeparatorLabel
            // 
            this.SeparatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SeparatorLabel.Location = new System.Drawing.Point(12, 34);
            this.SeparatorLabel.Name = "SeparatorLabel";
            this.SeparatorLabel.Size = new System.Drawing.Size(420, 2);
            this.SeparatorLabel.TabIndex = 43;
            // 
            // NavigateToCurrentBattleButton
            // 
            this.NavigateToCurrentBattleButton.Enabled = false;
            this.NavigateToCurrentBattleButton.Location = new System.Drawing.Point(160, 6);
            this.NavigateToCurrentBattleButton.Name = "NavigateToCurrentBattleButton";
            this.NavigateToCurrentBattleButton.Size = new System.Drawing.Size(120, 23);
            this.NavigateToCurrentBattleButton.TabIndex = 42;
            this.NavigateToCurrentBattleButton.TabStop = false;
            this.NavigateToCurrentBattleButton.Text = "∧ Current Battle ∧";
            this.NavigateToCurrentBattleButton.UseVisualStyleBackColor = true;
            // 
            // NavigateToSettingsButton
            // 
            this.NavigateToSettingsButton.Location = new System.Drawing.Point(352, 6);
            this.NavigateToSettingsButton.Name = "NavigateToSettingsButton";
            this.NavigateToSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.NavigateToSettingsButton.TabIndex = 41;
            this.NavigateToSettingsButton.TabStop = false;
            this.NavigateToSettingsButton.Text = "Settings  >>";
            this.NavigateToSettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NavigateToSettingsButton.UseVisualStyleBackColor = true;
            this.NavigateToSettingsButton.Click += new System.EventHandler(this.NavigateToSettingsButton_Click);
            // 
            // NavigateHomeButton
            // 
            this.NavigateHomeButton.Location = new System.Drawing.Point(14, 6);
            this.NavigateHomeButton.Name = "NavigateHomeButton";
            this.NavigateHomeButton.Size = new System.Drawing.Size(75, 23);
            this.NavigateHomeButton.TabIndex = 40;
            this.NavigateHomeButton.TabStop = false;
            this.NavigateHomeButton.Text = "<<    Home";
            this.NavigateHomeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NavigateHomeButton.UseVisualStyleBackColor = true;
            this.NavigateHomeButton.Click += new System.EventHandler(this.NavigateHomeButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 339);
            this.Controls.Add(this.SeparatorLabel);
            this.Controls.Add(this.NavigateToCurrentBattleButton);
            this.Controls.Add(this.NavigateToSettingsButton);
            this.Controls.Add(this.NavigateHomeButton);
            this.Controls.Add(this.BackgroundPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Battle Notifier";
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Panel BackgroundPanel;
        private System.Windows.Forms.Label SeparatorLabel;
        private System.Windows.Forms.Button NavigateToCurrentBattleButton;
        private System.Windows.Forms.Button NavigateToSettingsButton;
        private System.Windows.Forms.Button NavigateHomeButton;
    }
}
