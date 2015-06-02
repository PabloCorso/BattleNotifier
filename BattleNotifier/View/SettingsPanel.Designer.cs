namespace BattleNotifier.View
{
    partial class SettingsPanel
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
            this.GeneralSettingsGroup = new System.Windows.Forms.GroupBox();
            this.StartupCheckBox = new System.Windows.Forms.CheckBox();
            this.FadeCheckBox = new System.Windows.Forms.CheckBox();
            this.HideInTraybarCheckBox = new System.Windows.Forms.CheckBox();
            this.NotificationSoundGroup = new System.Windows.Forms.GroupBox();
            this.DefaultSoundComboBox = new System.Windows.Forms.ComboBox();
            this.DefaultSoundLabel = new System.Windows.Forms.Label();
            this.CustomSoundPathTextBox = new System.Windows.Forms.TextBox();
            this.UseCustomSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.SetSoundButton = new System.Windows.Forms.Button();
            this.ShowOnMapGroup = new System.Windows.Forms.GroupBox();
            this.OnMapLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapDesignerCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapAttsCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.MapTextColorPicker = new System.Windows.Forms.ComboBox();
            this.MapTextLabel = new System.Windows.Forms.Label();
            this.GeneralSettingsGroup.SuspendLayout();
            this.NotificationSoundGroup.SuspendLayout();
            this.ShowOnMapGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralSettingsGroup
            // 
            this.GeneralSettingsGroup.Controls.Add(this.ShowOnTopCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.StartupCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.FadeCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.HideInTraybarCheckBox);
            this.GeneralSettingsGroup.Location = new System.Drawing.Point(9, 15);
            this.GeneralSettingsGroup.Name = "GeneralSettingsGroup";
            this.GeneralSettingsGroup.Size = new System.Drawing.Size(188, 113);
            this.GeneralSettingsGroup.TabIndex = 0;
            this.GeneralSettingsGroup.TabStop = false;
            this.GeneralSettingsGroup.Text = "General settings";
            // 
            // StartupCheckBox
            // 
            this.StartupCheckBox.AutoSize = true;
            this.StartupCheckBox.Location = new System.Drawing.Point(7, 22);
            this.StartupCheckBox.Name = "StartupCheckBox";
            this.StartupCheckBox.Size = new System.Drawing.Size(140, 17);
            this.StartupCheckBox.TabIndex = 2;
            this.StartupCheckBox.Text = "Start notifying on startup";
            this.StartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // FadeCheckBox
            // 
            this.FadeCheckBox.AutoSize = true;
            this.FadeCheckBox.Location = new System.Drawing.Point(7, 66);
            this.FadeCheckBox.Name = "FadeCheckBox";
            this.FadeCheckBox.Size = new System.Drawing.Size(149, 17);
            this.FadeCheckBox.TabIndex = 1;
            this.FadeCheckBox.Text = "Fade effect on notification";
            this.FadeCheckBox.UseVisualStyleBackColor = true;
            // 
            // HideInTraybarCheckBox
            // 
            this.HideInTraybarCheckBox.AutoSize = true;
            this.HideInTraybarCheckBox.Location = new System.Drawing.Point(7, 44);
            this.HideInTraybarCheckBox.Name = "HideInTraybarCheckBox";
            this.HideInTraybarCheckBox.Size = new System.Drawing.Size(171, 17);
            this.HideInTraybarCheckBox.TabIndex = 0;
            this.HideInTraybarCheckBox.Text = "Hide in traybar when minimized";
            this.HideInTraybarCheckBox.UseVisualStyleBackColor = true;
            // 
            // NotificationSoundGroup
            // 
            this.NotificationSoundGroup.Controls.Add(this.SetSoundButton);
            this.NotificationSoundGroup.Controls.Add(this.UseCustomSoundCheckBox);
            this.NotificationSoundGroup.Controls.Add(this.CustomSoundPathTextBox);
            this.NotificationSoundGroup.Controls.Add(this.DefaultSoundLabel);
            this.NotificationSoundGroup.Controls.Add(this.DefaultSoundComboBox);
            this.NotificationSoundGroup.Location = new System.Drawing.Point(203, 15);
            this.NotificationSoundGroup.Name = "NotificationSoundGroup";
            this.NotificationSoundGroup.Size = new System.Drawing.Size(192, 91);
            this.NotificationSoundGroup.TabIndex = 3;
            this.NotificationSoundGroup.TabStop = false;
            this.NotificationSoundGroup.Text = "Notification sound";
            // 
            // DefaultSoundComboBox
            // 
            this.DefaultSoundComboBox.FormattingEnabled = true;
            this.DefaultSoundComboBox.Location = new System.Drawing.Point(84, 18);
            this.DefaultSoundComboBox.Name = "DefaultSoundComboBox";
            this.DefaultSoundComboBox.Size = new System.Drawing.Size(97, 21);
            this.DefaultSoundComboBox.TabIndex = 0;
            // 
            // DefaultSoundLabel
            // 
            this.DefaultSoundLabel.AutoSize = true;
            this.DefaultSoundLabel.Location = new System.Drawing.Point(5, 23);
            this.DefaultSoundLabel.Name = "DefaultSoundLabel";
            this.DefaultSoundLabel.Size = new System.Drawing.Size(73, 13);
            this.DefaultSoundLabel.TabIndex = 1;
            this.DefaultSoundLabel.Text = "Default sound";
            // 
            // CustomSoundPathTextBox
            // 
            this.CustomSoundPathTextBox.Location = new System.Drawing.Point(8, 63);
            this.CustomSoundPathTextBox.Name = "CustomSoundPathTextBox";
            this.CustomSoundPathTextBox.Size = new System.Drawing.Size(142, 20);
            this.CustomSoundPathTextBox.TabIndex = 2;
            // 
            // UseCustomSoundCheckBox
            // 
            this.UseCustomSoundCheckBox.AutoSize = true;
            this.UseCustomSoundCheckBox.Location = new System.Drawing.Point(8, 45);
            this.UseCustomSoundCheckBox.Name = "UseCustomSoundCheckBox";
            this.UseCustomSoundCheckBox.Size = new System.Drawing.Size(117, 17);
            this.UseCustomSoundCheckBox.TabIndex = 3;
            this.UseCustomSoundCheckBox.Text = "Use custom sound:";
            this.UseCustomSoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // SetSoundButton
            // 
            this.SetSoundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetSoundButton.Location = new System.Drawing.Point(159, 63);
            this.SetSoundButton.Name = "SetSoundButton";
            this.SetSoundButton.Size = new System.Drawing.Size(22, 20);
            this.SetSoundButton.TabIndex = 42;
            this.SetSoundButton.TabStop = false;
            this.SetSoundButton.Text = "...";
            this.SetSoundButton.UseVisualStyleBackColor = true;
            // 
            // ShowOnMapGroup
            // 
            this.ShowOnMapGroup.Controls.Add(this.MapTextLabel);
            this.ShowOnMapGroup.Controls.Add(this.MapTextColorPicker);
            this.ShowOnMapGroup.Controls.Add(this.OnMapTypeCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapAttsCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapLevelCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapTimeCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapDesignerCheckBox);
            this.ShowOnMapGroup.Location = new System.Drawing.Point(9, 134);
            this.ShowOnMapGroup.Name = "ShowOnMapGroup";
            this.ShowOnMapGroup.Size = new System.Drawing.Size(188, 158);
            this.ShowOnMapGroup.TabIndex = 3;
            this.ShowOnMapGroup.TabStop = false;
            this.ShowOnMapGroup.Text = "Show on Map";
            // 
            // OnMapLevelCheckBox
            // 
            this.OnMapLevelCheckBox.AutoSize = true;
            this.OnMapLevelCheckBox.Location = new System.Drawing.Point(7, 39);
            this.OnMapLevelCheckBox.Name = "OnMapLevelCheckBox";
            this.OnMapLevelCheckBox.Size = new System.Drawing.Size(81, 17);
            this.OnMapLevelCheckBox.TabIndex = 2;
            this.OnMapLevelCheckBox.Text = "Level name";
            this.OnMapLevelCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnMapTimeCheckBox
            // 
            this.OnMapTimeCheckBox.AutoSize = true;
            this.OnMapTimeCheckBox.Location = new System.Drawing.Point(7, 108);
            this.OnMapTimeCheckBox.Name = "OnMapTimeCheckBox";
            this.OnMapTimeCheckBox.Size = new System.Drawing.Size(99, 17);
            this.OnMapTimeCheckBox.TabIndex = 1;
            this.OnMapTimeCheckBox.Text = "Battle\'s time left";
            this.OnMapTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnMapDesignerCheckBox
            // 
            this.OnMapDesignerCheckBox.AutoSize = true;
            this.OnMapDesignerCheckBox.Location = new System.Drawing.Point(7, 62);
            this.OnMapDesignerCheckBox.Name = "OnMapDesignerCheckBox";
            this.OnMapDesignerCheckBox.Size = new System.Drawing.Size(68, 17);
            this.OnMapDesignerCheckBox.TabIndex = 0;
            this.OnMapDesignerCheckBox.Text = "Designer";
            this.OnMapDesignerCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnMapAttsCheckBox
            // 
            this.OnMapAttsCheckBox.AutoSize = true;
            this.OnMapAttsCheckBox.Location = new System.Drawing.Point(7, 131);
            this.OnMapAttsCheckBox.Name = "OnMapAttsCheckBox";
            this.OnMapAttsCheckBox.Size = new System.Drawing.Size(106, 17);
            this.OnMapAttsCheckBox.TabIndex = 3;
            this.OnMapAttsCheckBox.Text = "Battle\'s attributes";
            this.OnMapAttsCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnMapTypeCheckBox
            // 
            this.OnMapTypeCheckBox.AutoSize = true;
            this.OnMapTypeCheckBox.Location = new System.Drawing.Point(7, 85);
            this.OnMapTypeCheckBox.Name = "OnMapTypeCheckBox";
            this.OnMapTypeCheckBox.Size = new System.Drawing.Size(76, 17);
            this.OnMapTypeCheckBox.TabIndex = 4;
            this.OnMapTypeCheckBox.Text = "Battle type";
            this.OnMapTypeCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShowOnTopCheckBox
            // 
            this.ShowOnTopCheckBox.AutoSize = true;
            this.ShowOnTopCheckBox.Location = new System.Drawing.Point(7, 88);
            this.ShowOnTopCheckBox.Name = "ShowOnTopCheckBox";
            this.ShowOnTopCheckBox.Size = new System.Drawing.Size(86, 17);
            this.ShowOnTopCheckBox.TabIndex = 3;
            this.ShowOnTopCheckBox.Text = "Show on top";
            this.ShowOnTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // MapTextColorPicker
            // 
            this.MapTextColorPicker.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.MapTextColorPicker.FormattingEnabled = true;
            this.MapTextColorPicker.Location = new System.Drawing.Point(125, 17);
            this.MapTextColorPicker.Name = "MapTextColorPicker";
            this.MapTextColorPicker.Size = new System.Drawing.Size(52, 21);
            this.MapTextColorPicker.TabIndex = 43;
            // 
            // MapTextLabel
            // 
            this.MapTextLabel.AutoSize = true;
            this.MapTextLabel.Location = new System.Drawing.Point(6, 20);
            this.MapTextLabel.Name = "MapTextLabel";
            this.MapTextLabel.Size = new System.Drawing.Size(104, 13);
            this.MapTextLabel.TabIndex = 44;
            this.MapTextLabel.Text = "Text over map color:";
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShowOnMapGroup);
            this.Controls.Add(this.NotificationSoundGroup);
            this.Controls.Add(this.GeneralSettingsGroup);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(413, 297);
            this.GeneralSettingsGroup.ResumeLayout(false);
            this.GeneralSettingsGroup.PerformLayout();
            this.NotificationSoundGroup.ResumeLayout(false);
            this.NotificationSoundGroup.PerformLayout();
            this.ShowOnMapGroup.ResumeLayout(false);
            this.ShowOnMapGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GeneralSettingsGroup;
        private System.Windows.Forms.GroupBox NotificationSoundGroup;
        private System.Windows.Forms.Label DefaultSoundLabel;
        private System.Windows.Forms.Button SetSoundButton;
        private System.Windows.Forms.GroupBox ShowOnMapGroup;
        private System.Windows.Forms.Label MapTextLabel;
        private System.Windows.Forms.ComboBox MapTextColorPicker;
        public System.Windows.Forms.CheckBox OnMapLevelCheckBox;
        public System.Windows.Forms.CheckBox OnMapTimeCheckBox;
        public System.Windows.Forms.CheckBox OnMapDesignerCheckBox;
        public System.Windows.Forms.CheckBox OnMapTypeCheckBox;
        public System.Windows.Forms.CheckBox OnMapAttsCheckBox;
        public System.Windows.Forms.CheckBox ShowOnTopCheckBox;
        public System.Windows.Forms.CheckBox StartupCheckBox;
        public System.Windows.Forms.CheckBox FadeCheckBox;
        public System.Windows.Forms.CheckBox HideInTraybarCheckBox;
        public System.Windows.Forms.TextBox CustomSoundPathTextBox;
        public System.Windows.Forms.ComboBox DefaultSoundComboBox;
        public System.Windows.Forms.CheckBox UseCustomSoundCheckBox;
    }
}
