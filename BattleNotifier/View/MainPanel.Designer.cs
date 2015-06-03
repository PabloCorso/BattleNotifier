namespace BattleNotifier.View
{
    partial class MainPanel
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
            this.components = new System.ComponentModel.Container();
            this.DesignersLabel = new System.Windows.Forms.Label();
            this.NotificationDurationTrackBar = new System.Windows.Forms.TrackBar();
            this.StartNotificationButton = new System.Windows.Forms.Button();
            this.DesignersChListBox = new System.Windows.Forms.CheckedListBox();
            this.ClearBattleTypesButton = new System.Windows.Forms.Button();
            this.BattleTypesLabel = new System.Windows.Forms.Label();
            this.BattleTypesChListBox = new System.Windows.Forms.CheckedListBox();
            this.SearchDesignerTextBox = new System.Windows.Forms.TextBox();
            this.AddDesignerButton = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.NotificationLabel = new System.Windows.Forms.Label();
            this.ShowMapCheckBox = new System.Windows.Forms.CheckBox();
            this.PlaySoundCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowBattleCheckBox = new System.Windows.Forms.CheckBox();
            this.Simulate1Button = new System.Windows.Forms.Button();
            this.SimulateBattle2Button = new System.Windows.Forms.Button();
            this.CloseDialogNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CloseDialogTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BlackListChListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.MapSizeDomainUpDown = new System.Windows.Forms.DomainUpDown();
            this.mapSizeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationDurationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseDialogNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DesignersLabel
            // 
            this.DesignersLabel.AutoSize = true;
            this.DesignersLabel.Location = new System.Drawing.Point(3, 10);
            this.DesignersLabel.Name = "DesignersLabel";
            this.DesignersLabel.Size = new System.Drawing.Size(54, 13);
            this.DesignersLabel.TabIndex = 31;
            this.DesignersLabel.Text = "Designers";
            // 
            // NotificationDurationTrackBar
            // 
            this.NotificationDurationTrackBar.Location = new System.Drawing.Point(142, 243);
            this.NotificationDurationTrackBar.Name = "NotificationDurationTrackBar";
            this.NotificationDurationTrackBar.Size = new System.Drawing.Size(277, 45);
            this.NotificationDurationTrackBar.TabIndex = 3;
            this.NotificationDurationTrackBar.ValueChanged += new System.EventHandler(this.NotificationDurationTrackBar_ValueChanged);
            // 
            // StartNotificationButton
            // 
            this.StartNotificationButton.Location = new System.Drawing.Point(6, 243);
            this.StartNotificationButton.Name = "StartNotificationButton";
            this.StartNotificationButton.Size = new System.Drawing.Size(120, 45);
            this.StartNotificationButton.TabIndex = 2;
            this.StartNotificationButton.Text = "▶ Start";
            this.StartNotificationButton.UseVisualStyleBackColor = true;
            this.StartNotificationButton.Click += new System.EventHandler(this.StartNotificationButton_Click);
            // 
            // DesignersChListBox
            // 
            this.DesignersChListBox.CheckOnClick = true;
            this.DesignersChListBox.FormattingEnabled = true;
            this.DesignersChListBox.IntegralHeight = false;
            this.DesignersChListBox.Location = new System.Drawing.Point(6, 55);
            this.DesignersChListBox.Name = "DesignersChListBox";
            this.DesignersChListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.DesignersChListBox.Size = new System.Drawing.Size(120, 80);
            this.DesignersChListBox.TabIndex = 27;
            this.DesignersChListBox.TabStop = false;
            this.DesignersChListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DesignersChListBox_MouseDown);
            // 
            // ClearBattleTypesButton
            // 
            this.ClearBattleTypesButton.Location = new System.Drawing.Point(152, 198);
            this.ClearBattleTypesButton.Name = "ClearBattleTypesButton";
            this.ClearBattleTypesButton.Size = new System.Drawing.Size(120, 23);
            this.ClearBattleTypesButton.TabIndex = 23;
            this.ClearBattleTypesButton.TabStop = false;
            this.ClearBattleTypesButton.Text = "Clear selections";
            this.ClearBattleTypesButton.UseVisualStyleBackColor = true;
            this.ClearBattleTypesButton.Click += new System.EventHandler(this.ClearBattleTypesButton_Click);
            // 
            // BattleTypesLabel
            // 
            this.BattleTypesLabel.AutoSize = true;
            this.BattleTypesLabel.Location = new System.Drawing.Point(149, 10);
            this.BattleTypesLabel.Name = "BattleTypesLabel";
            this.BattleTypesLabel.Size = new System.Drawing.Size(62, 13);
            this.BattleTypesLabel.TabIndex = 21;
            this.BattleTypesLabel.Text = "Battle types";
            // 
            // BattleTypesChListBox
            // 
            this.BattleTypesChListBox.CheckOnClick = true;
            this.BattleTypesChListBox.FormattingEnabled = true;
            this.BattleTypesChListBox.Location = new System.Drawing.Point(152, 29);
            this.BattleTypesChListBox.Name = "BattleTypesChListBox";
            this.BattleTypesChListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.BattleTypesChListBox.Size = new System.Drawing.Size(120, 154);
            this.BattleTypesChListBox.TabIndex = 20;
            this.BattleTypesChListBox.TabStop = false;
            this.BattleTypesChListBox.Click += new System.EventHandler(this.BattleTypesChListBox_Click);
            // 
            // SearchDesignerTextBox
            // 
            this.SearchDesignerTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchDesignerTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchDesignerTextBox.Location = new System.Drawing.Point(6, 29);
            this.SearchDesignerTextBox.Name = "SearchDesignerTextBox";
            this.SearchDesignerTextBox.Size = new System.Drawing.Size(92, 20);
            this.SearchDesignerTextBox.TabIndex = 1;
            this.SearchDesignerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchDesignerTextBox_KeyDown);
            // 
            // AddDesignerButton
            // 
            this.AddDesignerButton.Location = new System.Drawing.Point(104, 29);
            this.AddDesignerButton.Name = "AddDesignerButton";
            this.AddDesignerButton.Size = new System.Drawing.Size(22, 20);
            this.AddDesignerButton.TabIndex = 2;
            this.AddDesignerButton.Text = "+";
            this.AddDesignerButton.UseVisualStyleBackColor = true;
            this.AddDesignerButton.Click += new System.EventHandler(this.AddDesignerButton_Click);
            this.AddDesignerButton.Enter += new System.EventHandler(this.AddDesignerButton_Enter);
            this.AddDesignerButton.Leave += new System.EventHandler(this.AddDesignerButton_Leave);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // NotificationLabel
            // 
            this.NotificationLabel.AutoSize = true;
            this.NotificationLabel.Location = new System.Drawing.Point(294, 10);
            this.NotificationLabel.Name = "NotificationLabel";
            this.NotificationLabel.Size = new System.Drawing.Size(60, 13);
            this.NotificationLabel.TabIndex = 26;
            this.NotificationLabel.Text = "Notification";
            // 
            // ShowMapCheckBox
            // 
            this.ShowMapCheckBox.AutoSize = true;
            this.ShowMapCheckBox.Location = new System.Drawing.Point(297, 60);
            this.ShowMapCheckBox.Name = "ShowMapCheckBox";
            this.ShowMapCheckBox.Size = new System.Drawing.Size(101, 17);
            this.ShowMapCheckBox.TabIndex = 36;
            this.ShowMapCheckBox.TabStop = false;
            this.ShowMapCheckBox.Text = "Show level map";
            this.ShowMapCheckBox.UseVisualStyleBackColor = true;
            this.ShowMapCheckBox.CheckedChanged += new System.EventHandler(this.ShowMapCheckBox_CheckedChanged);
            // 
            // PlaySoundCheckBox
            // 
            this.PlaySoundCheckBox.AutoSize = true;
            this.PlaySoundCheckBox.Location = new System.Drawing.Point(297, 104);
            this.PlaySoundCheckBox.Name = "PlaySoundCheckBox";
            this.PlaySoundCheckBox.Size = new System.Drawing.Size(78, 17);
            this.PlaySoundCheckBox.TabIndex = 37;
            this.PlaySoundCheckBox.TabStop = false;
            this.PlaySoundCheckBox.Text = "Play sound";
            this.PlaySoundCheckBox.UseVisualStyleBackColor = true;
            this.PlaySoundCheckBox.CheckedChanged += new System.EventHandler(this.PlaySoundCheckBox_CheckedChanged);
            // 
            // ShowBattleCheckBox
            // 
            this.ShowBattleCheckBox.AutoSize = true;
            this.ShowBattleCheckBox.Enabled = false;
            this.ShowBattleCheckBox.Location = new System.Drawing.Point(297, 36);
            this.ShowBattleCheckBox.Name = "ShowBattleCheckBox";
            this.ShowBattleCheckBox.Size = new System.Drawing.Size(102, 17);
            this.ShowBattleCheckBox.TabIndex = 38;
            this.ShowBattleCheckBox.TabStop = false;
            this.ShowBattleCheckBox.Text = "Show battle info";
            this.ShowBattleCheckBox.UseVisualStyleBackColor = true;
            this.ShowBattleCheckBox.CheckedChanged += new System.EventHandler(this.ShowBattleCheckBox_CheckedChanged);
            // 
            // Simulate1Button
            // 
            this.Simulate1Button.Location = new System.Drawing.Point(294, 214);
            this.Simulate1Button.Name = "Simulate1Button";
            this.Simulate1Button.Size = new System.Drawing.Size(29, 23);
            this.Simulate1Button.TabIndex = 39;
            this.Simulate1Button.TabStop = false;
            this.Simulate1Button.Text = "1";
            this.Simulate1Button.UseVisualStyleBackColor = true;
            this.Simulate1Button.Visible = false;
            this.Simulate1Button.Click += new System.EventHandler(this.Simulate1Button_Click);
            // 
            // SimulateBattle2Button
            // 
            this.SimulateBattle2Button.Location = new System.Drawing.Point(329, 214);
            this.SimulateBattle2Button.Name = "SimulateBattle2Button";
            this.SimulateBattle2Button.Size = new System.Drawing.Size(31, 23);
            this.SimulateBattle2Button.TabIndex = 40;
            this.SimulateBattle2Button.TabStop = false;
            this.SimulateBattle2Button.Text = "2";
            this.SimulateBattle2Button.UseVisualStyleBackColor = true;
            this.SimulateBattle2Button.Visible = false;
            this.SimulateBattle2Button.Click += new System.EventHandler(this.SimulateBattle2Button_Click);
            // 
            // CloseDialogNumericUpDown
            // 
            this.CloseDialogNumericUpDown.Location = new System.Drawing.Point(330, 145);
            this.CloseDialogNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.CloseDialogNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CloseDialogNumericUpDown.Name = "CloseDialogNumericUpDown";
            this.CloseDialogNumericUpDown.Size = new System.Drawing.Size(35, 20);
            this.CloseDialogNumericUpDown.TabIndex = 42;
            this.CloseDialogNumericUpDown.TabStop = false;
            this.CloseDialogNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // CloseDialogTimeCheckBox
            // 
            this.CloseDialogTimeCheckBox.AutoSize = true;
            this.CloseDialogTimeCheckBox.Location = new System.Drawing.Point(297, 127);
            this.CloseDialogTimeCheckBox.Name = "CloseDialogTimeCheckBox";
            this.CloseDialogTimeCheckBox.Size = new System.Drawing.Size(106, 17);
            this.CloseDialogTimeCheckBox.TabIndex = 43;
            this.CloseDialogTimeCheckBox.TabStop = false;
            this.CloseDialogTimeCheckBox.Text = "Close notification";
            this.CloseDialogTimeCheckBox.UseVisualStyleBackColor = true;
            this.CloseDialogTimeCheckBox.CheckedChanged += new System.EventHandler(this.CloseDialogTimeCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "after";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "secs.";
            // 
            // BlackListChListBox
            // 
            this.BlackListChListBox.FormattingEnabled = true;
            this.BlackListChListBox.IntegralHeight = false;
            this.BlackListChListBox.Location = new System.Drawing.Point(6, 156);
            this.BlackListChListBox.Name = "BlackListChListBox";
            this.BlackListChListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.BlackListChListBox.Size = new System.Drawing.Size(120, 64);
            this.BlackListChListBox.TabIndex = 46;
            this.BlackListChListBox.TabStop = false;
            this.BlackListChListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BlackListChListBox_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Black list";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(152, 274);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(263, 13);
            this.ErrorLabel.TabIndex = 48;
            this.ErrorLabel.Text = "With the current settings you will not have notifications";
            this.ErrorLabel.Visible = false;
            // 
            // MapSizeDomainUpDown
            // 
            this.MapSizeDomainUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MapSizeDomainUpDown.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MapSizeDomainUpDown.Items.Add("small");
            this.MapSizeDomainUpDown.Items.Add("norm");
            this.MapSizeDomainUpDown.Items.Add("big");
            this.MapSizeDomainUpDown.Location = new System.Drawing.Point(348, 78);
            this.MapSizeDomainUpDown.Name = "MapSizeDomainUpDown";
            this.MapSizeDomainUpDown.ReadOnly = true;
            this.MapSizeDomainUpDown.Size = new System.Drawing.Size(44, 20);
            this.MapSizeDomainUpDown.TabIndex = 49;
            this.MapSizeDomainUpDown.TabStop = false;
            // 
            // mapSizeLabel
            // 
            this.mapSizeLabel.AutoSize = true;
            this.mapSizeLabel.Location = new System.Drawing.Point(300, 80);
            this.mapSizeLabel.Name = "mapSizeLabel";
            this.mapSizeLabel.Size = new System.Drawing.Size(48, 13);
            this.mapSizeLabel.TabIndex = 50;
            this.mapSizeLabel.Text = "map size";
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapSizeLabel);
            this.Controls.Add(this.MapSizeDomainUpDown);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlackListChListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseDialogTimeCheckBox);
            this.Controls.Add(this.CloseDialogNumericUpDown);
            this.Controls.Add(this.SimulateBattle2Button);
            this.Controls.Add(this.Simulate1Button);
            this.Controls.Add(this.ShowBattleCheckBox);
            this.Controls.Add(this.PlaySoundCheckBox);
            this.Controls.Add(this.ShowMapCheckBox);
            this.Controls.Add(this.AddDesignerButton);
            this.Controls.Add(this.DesignersLabel);
            this.Controls.Add(this.NotificationDurationTrackBar);
            this.Controls.Add(this.StartNotificationButton);
            this.Controls.Add(this.DesignersChListBox);
            this.Controls.Add(this.NotificationLabel);
            this.Controls.Add(this.ClearBattleTypesButton);
            this.Controls.Add(this.BattleTypesLabel);
            this.Controls.Add(this.BattleTypesChListBox);
            this.Controls.Add(this.SearchDesignerTextBox);
            this.Name = "MainPanel";
            this.Size = new System.Drawing.Size(413, 297);
            this.Load += new System.EventHandler(this.MainPanel_Load);
            this.Click += new System.EventHandler(this.MainPanel_Click);
            ((System.ComponentModel.ISupportInitialize)(this.NotificationDurationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseDialogNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DesignersLabel;
        private System.Windows.Forms.Button StartNotificationButton;
        private System.Windows.Forms.Button ClearBattleTypesButton;
        private System.Windows.Forms.Label BattleTypesLabel;
        private System.Windows.Forms.Button AddDesignerButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label NotificationLabel;
        private System.Windows.Forms.Button Simulate1Button;
        private System.Windows.Forms.Button SimulateBattle2Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox ShowMapCheckBox;
        public System.Windows.Forms.CheckBox PlaySoundCheckBox;
        public System.Windows.Forms.CheckBox ShowBattleCheckBox;
        public System.Windows.Forms.NumericUpDown CloseDialogNumericUpDown;
        public System.Windows.Forms.CheckBox CloseDialogTimeCheckBox;
        public System.Windows.Forms.TrackBar NotificationDurationTrackBar;
        public System.Windows.Forms.CheckedListBox DesignersChListBox;
        public System.Windows.Forms.CheckedListBox BattleTypesChListBox;
        public System.Windows.Forms.CheckedListBox BlackListChListBox;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox SearchDesignerTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label mapSizeLabel;
        public System.Windows.Forms.DomainUpDown MapSizeDomainUpDown;
    }
}
