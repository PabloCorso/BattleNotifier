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
            this.HidePrintCheckBox = new System.Windows.Forms.CheckBox();
            this.TransparentCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.StartupCheckBox = new System.Windows.Forms.CheckBox();
            this.FadeCheckBox = new System.Windows.Forms.CheckBox();
            this.HideToTraybarCheckBox = new System.Windows.Forms.CheckBox();
            this.NotificationSoundGroup = new System.Windows.Forms.GroupBox();
            this.SetSoundButton = new System.Windows.Forms.Button();
            this.UseCustomSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.CustomSoundPathTextBox = new System.Windows.Forms.TextBox();
            this.DefaultSoundLabel = new System.Windows.Forms.Label();
            this.DefaultSoundComboBox = new System.Windows.Forms.ComboBox();
            this.ShowOnMapGroup = new System.Windows.Forms.GroupBox();
            this.ColorPicker = new System.Windows.Forms.Button();
            this.b25 = new System.Windows.Forms.Button();
            this.b26 = new System.Windows.Forms.Button();
            this.b27 = new System.Windows.Forms.Button();
            this.b28 = new System.Windows.Forms.Button();
            this.b29 = new System.Windows.Forms.Button();
            this.b30 = new System.Windows.Forms.Button();
            this.b31 = new System.Windows.Forms.Button();
            this.b32 = new System.Windows.Forms.Button();
            this.b13 = new System.Windows.Forms.Button();
            this.b14 = new System.Windows.Forms.Button();
            this.b15 = new System.Windows.Forms.Button();
            this.b16 = new System.Windows.Forms.Button();
            this.b17 = new System.Windows.Forms.Button();
            this.b18 = new System.Windows.Forms.Button();
            this.b19 = new System.Windows.Forms.Button();
            this.b20 = new System.Windows.Forms.Button();
            this.b21 = new System.Windows.Forms.Button();
            this.b22 = new System.Windows.Forms.Button();
            this.b23 = new System.Windows.Forms.Button();
            this.b24 = new System.Windows.Forms.Button();
            this.b9 = new System.Windows.Forms.Button();
            this.b10 = new System.Windows.Forms.Button();
            this.b11 = new System.Windows.Forms.Button();
            this.b12 = new System.Windows.Forms.Button();
            this.b5 = new System.Windows.Forms.Button();
            this.b6 = new System.Windows.Forms.Button();
            this.b7 = new System.Windows.Forms.Button();
            this.b8 = new System.Windows.Forms.Button();
            this.b4 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.MapTextLabel = new System.Windows.Forms.Label();
            this.OnMapTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapAttsCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.OnMapDesignerCheckBox = new System.Windows.Forms.CheckBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ResetLabel = new System.Windows.Forms.Label();
            this.SimulateLabel = new System.Windows.Forms.Label();
            this.NewBattleButton = new System.Windows.Forms.Button();
            this.SoundOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RandomNewBattleCheckBox = new System.Windows.Forms.CheckBox();
            this.GeneralSettingsGroup.SuspendLayout();
            this.NotificationSoundGroup.SuspendLayout();
            this.ShowOnMapGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralSettingsGroup
            // 
            this.GeneralSettingsGroup.Controls.Add(this.HidePrintCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.TransparentCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.ShowOnTopCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.StartupCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.FadeCheckBox);
            this.GeneralSettingsGroup.Controls.Add(this.HideToTraybarCheckBox);
            this.GeneralSettingsGroup.Location = new System.Drawing.Point(9, 15);
            this.GeneralSettingsGroup.Name = "GeneralSettingsGroup";
            this.GeneralSettingsGroup.Size = new System.Drawing.Size(188, 163);
            this.GeneralSettingsGroup.TabIndex = 0;
            this.GeneralSettingsGroup.TabStop = false;
            this.GeneralSettingsGroup.Text = "General settings";
            // 
            // HidePrintCheckBox
            // 
            this.HidePrintCheckBox.AutoSize = true;
            this.HidePrintCheckBox.Location = new System.Drawing.Point(7, 134);
            this.HidePrintCheckBox.Name = "HidePrintCheckBox";
            this.HidePrintCheckBox.Size = new System.Drawing.Size(126, 17);
            this.HidePrintCheckBox.TabIndex = 5;
            this.HidePrintCheckBox.Text = "Hide print map option";
            this.HidePrintCheckBox.UseVisualStyleBackColor = true;
            // 
            // TransparentCheckBox
            // 
            this.TransparentCheckBox.AutoSize = true;
            this.TransparentCheckBox.Location = new System.Drawing.Point(7, 111);
            this.TransparentCheckBox.Name = "TransparentCheckBox";
            this.TransparentCheckBox.Size = new System.Drawing.Size(161, 17);
            this.TransparentCheckBox.TabIndex = 4;
            this.TransparentCheckBox.Text = "Transparent notification style";
            this.TransparentCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShowOnTopCheckBox
            // 
            this.ShowOnTopCheckBox.AutoSize = true;
            this.ShowOnTopCheckBox.Location = new System.Drawing.Point(7, 88);
            this.ShowOnTopCheckBox.Name = "ShowOnTopCheckBox";
            this.ShowOnTopCheckBox.Size = new System.Drawing.Size(145, 17);
            this.ShowOnTopCheckBox.TabIndex = 3;
            this.ShowOnTopCheckBox.Text = "Show notifications on top";
            this.ShowOnTopCheckBox.UseVisualStyleBackColor = true;
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
            // HideToTraybarCheckBox
            // 
            this.HideToTraybarCheckBox.AutoSize = true;
            this.HideToTraybarCheckBox.Location = new System.Drawing.Point(7, 44);
            this.HideToTraybarCheckBox.Name = "HideToTraybarCheckBox";
            this.HideToTraybarCheckBox.Size = new System.Drawing.Size(175, 17);
            this.HideToTraybarCheckBox.TabIndex = 0;
            this.HideToTraybarCheckBox.Text = "Hide to tray bar when minimized";
            this.HideToTraybarCheckBox.UseVisualStyleBackColor = true;
            this.HideToTraybarCheckBox.CheckedChanged += new System.EventHandler(this.HideToTraybarCheckBox_CheckedChanged);
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
            this.SetSoundButton.Click += new System.EventHandler(this.SetSoundButton_Click);
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
            // CustomSoundPathTextBox
            // 
            this.CustomSoundPathTextBox.Location = new System.Drawing.Point(8, 63);
            this.CustomSoundPathTextBox.Name = "CustomSoundPathTextBox";
            this.CustomSoundPathTextBox.Size = new System.Drawing.Size(142, 20);
            this.CustomSoundPathTextBox.TabIndex = 2;
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
            // DefaultSoundComboBox
            // 
            this.DefaultSoundComboBox.FormattingEnabled = true;
            this.DefaultSoundComboBox.Items.AddRange(new object[] {
            "apple",
            "flower",
            "wroom",
            "deaded"});
            this.DefaultSoundComboBox.Location = new System.Drawing.Point(84, 18);
            this.DefaultSoundComboBox.Name = "DefaultSoundComboBox";
            this.DefaultSoundComboBox.Size = new System.Drawing.Size(97, 21);
            this.DefaultSoundComboBox.TabIndex = 0;
            // 
            // ShowOnMapGroup
            // 
            this.ShowOnMapGroup.Controls.Add(this.ColorPicker);
            this.ShowOnMapGroup.Controls.Add(this.b25);
            this.ShowOnMapGroup.Controls.Add(this.b26);
            this.ShowOnMapGroup.Controls.Add(this.b27);
            this.ShowOnMapGroup.Controls.Add(this.b28);
            this.ShowOnMapGroup.Controls.Add(this.b29);
            this.ShowOnMapGroup.Controls.Add(this.b30);
            this.ShowOnMapGroup.Controls.Add(this.b31);
            this.ShowOnMapGroup.Controls.Add(this.b32);
            this.ShowOnMapGroup.Controls.Add(this.b13);
            this.ShowOnMapGroup.Controls.Add(this.b14);
            this.ShowOnMapGroup.Controls.Add(this.b15);
            this.ShowOnMapGroup.Controls.Add(this.b16);
            this.ShowOnMapGroup.Controls.Add(this.b17);
            this.ShowOnMapGroup.Controls.Add(this.b18);
            this.ShowOnMapGroup.Controls.Add(this.b19);
            this.ShowOnMapGroup.Controls.Add(this.b20);
            this.ShowOnMapGroup.Controls.Add(this.b21);
            this.ShowOnMapGroup.Controls.Add(this.b22);
            this.ShowOnMapGroup.Controls.Add(this.b23);
            this.ShowOnMapGroup.Controls.Add(this.b24);
            this.ShowOnMapGroup.Controls.Add(this.b9);
            this.ShowOnMapGroup.Controls.Add(this.b10);
            this.ShowOnMapGroup.Controls.Add(this.b11);
            this.ShowOnMapGroup.Controls.Add(this.b12);
            this.ShowOnMapGroup.Controls.Add(this.b5);
            this.ShowOnMapGroup.Controls.Add(this.b6);
            this.ShowOnMapGroup.Controls.Add(this.b7);
            this.ShowOnMapGroup.Controls.Add(this.b8);
            this.ShowOnMapGroup.Controls.Add(this.b4);
            this.ShowOnMapGroup.Controls.Add(this.b3);
            this.ShowOnMapGroup.Controls.Add(this.b2);
            this.ShowOnMapGroup.Controls.Add(this.b1);
            this.ShowOnMapGroup.Controls.Add(this.MapTextLabel);
            this.ShowOnMapGroup.Controls.Add(this.OnMapTypeCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapAttsCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapLevelCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapTimeCheckBox);
            this.ShowOnMapGroup.Controls.Add(this.OnMapDesignerCheckBox);
            this.ShowOnMapGroup.Location = new System.Drawing.Point(203, 112);
            this.ShowOnMapGroup.Name = "ShowOnMapGroup";
            this.ShowOnMapGroup.Size = new System.Drawing.Size(192, 158);
            this.ShowOnMapGroup.TabIndex = 3;
            this.ShowOnMapGroup.TabStop = false;
            this.ShowOnMapGroup.Text = "Show on Map";
            // 
            // ColorPicker
            // 
            this.ColorPicker.BackColor = System.Drawing.Color.Black;
            this.ColorPicker.BackgroundImage = global::BattleNotifier.Properties.Resources.color_picker;
            this.ColorPicker.FlatAppearance.BorderSize = 0;
            this.ColorPicker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ColorPicker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ColorPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorPicker.Location = new System.Drawing.Point(125, 17);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(52, 21);
            this.ColorPicker.TabIndex = 78;
            this.ColorPicker.UseVisualStyleBackColor = false;
            this.ColorPicker.Click += new System.EventHandler(this.ColorPicker_Click);
            // 
            // b25
            // 
            this.b25.BackColor = System.Drawing.Color.Purple;
            this.b25.FlatAppearance.BorderSize = 0;
            this.b25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b25.Location = new System.Drawing.Point(164, 129);
            this.b25.Name = "b25";
            this.b25.Size = new System.Drawing.Size(13, 13);
            this.b25.TabIndex = 76;
            this.b25.TabStop = false;
            this.b25.UseVisualStyleBackColor = false;
            this.b25.Visible = false;
            // 
            // b26
            // 
            this.b26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.b26.FlatAppearance.BorderSize = 0;
            this.b26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b26.Location = new System.Drawing.Point(151, 129);
            this.b26.Name = "b26";
            this.b26.Size = new System.Drawing.Size(13, 13);
            this.b26.TabIndex = 75;
            this.b26.TabStop = false;
            this.b26.UseVisualStyleBackColor = false;
            this.b26.Visible = false;
            // 
            // b27
            // 
            this.b27.BackColor = System.Drawing.Color.Fuchsia;
            this.b27.FlatAppearance.BorderSize = 0;
            this.b27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b27.Location = new System.Drawing.Point(138, 129);
            this.b27.Name = "b27";
            this.b27.Size = new System.Drawing.Size(13, 13);
            this.b27.TabIndex = 74;
            this.b27.TabStop = false;
            this.b27.UseVisualStyleBackColor = false;
            this.b27.Visible = false;
            // 
            // b28
            // 
            this.b28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.b28.FlatAppearance.BorderSize = 0;
            this.b28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b28.Location = new System.Drawing.Point(125, 129);
            this.b28.Name = "b28";
            this.b28.Size = new System.Drawing.Size(13, 13);
            this.b28.TabIndex = 73;
            this.b28.TabStop = false;
            this.b28.UseVisualStyleBackColor = false;
            this.b28.Visible = false;
            // 
            // b29
            // 
            this.b29.BackColor = System.Drawing.Color.Navy;
            this.b29.FlatAppearance.BorderSize = 0;
            this.b29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b29.Location = new System.Drawing.Point(164, 116);
            this.b29.Name = "b29";
            this.b29.Size = new System.Drawing.Size(13, 13);
            this.b29.TabIndex = 72;
            this.b29.TabStop = false;
            this.b29.UseVisualStyleBackColor = false;
            this.b29.Visible = false;
            // 
            // b30
            // 
            this.b30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.b30.FlatAppearance.BorderSize = 0;
            this.b30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b30.Location = new System.Drawing.Point(151, 116);
            this.b30.Name = "b30";
            this.b30.Size = new System.Drawing.Size(13, 13);
            this.b30.TabIndex = 71;
            this.b30.TabStop = false;
            this.b30.UseVisualStyleBackColor = false;
            this.b30.Visible = false;
            // 
            // b31
            // 
            this.b31.BackColor = System.Drawing.Color.Blue;
            this.b31.FlatAppearance.BorderSize = 0;
            this.b31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b31.Location = new System.Drawing.Point(138, 116);
            this.b31.Name = "b31";
            this.b31.Size = new System.Drawing.Size(13, 13);
            this.b31.TabIndex = 70;
            this.b31.TabStop = false;
            this.b31.UseVisualStyleBackColor = false;
            this.b31.Visible = false;
            // 
            // b32
            // 
            this.b32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.b32.FlatAppearance.BorderSize = 0;
            this.b32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b32.Location = new System.Drawing.Point(125, 116);
            this.b32.Name = "b32";
            this.b32.Size = new System.Drawing.Size(13, 13);
            this.b32.TabIndex = 69;
            this.b32.TabStop = false;
            this.b32.UseVisualStyleBackColor = false;
            this.b32.Visible = false;
            // 
            // b13
            // 
            this.b13.BackColor = System.Drawing.Color.Teal;
            this.b13.FlatAppearance.BorderSize = 0;
            this.b13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b13.Location = new System.Drawing.Point(164, 103);
            this.b13.Name = "b13";
            this.b13.Size = new System.Drawing.Size(13, 13);
            this.b13.TabIndex = 68;
            this.b13.TabStop = false;
            this.b13.UseVisualStyleBackColor = false;
            this.b13.Visible = false;
            // 
            // b14
            // 
            this.b14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.b14.FlatAppearance.BorderSize = 0;
            this.b14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b14.Location = new System.Drawing.Point(151, 103);
            this.b14.Name = "b14";
            this.b14.Size = new System.Drawing.Size(13, 13);
            this.b14.TabIndex = 67;
            this.b14.TabStop = false;
            this.b14.UseVisualStyleBackColor = false;
            this.b14.Visible = false;
            // 
            // b15
            // 
            this.b15.BackColor = System.Drawing.Color.Aqua;
            this.b15.FlatAppearance.BorderSize = 0;
            this.b15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b15.Location = new System.Drawing.Point(138, 103);
            this.b15.Name = "b15";
            this.b15.Size = new System.Drawing.Size(13, 13);
            this.b15.TabIndex = 66;
            this.b15.TabStop = false;
            this.b15.UseVisualStyleBackColor = false;
            this.b15.Visible = false;
            // 
            // b16
            // 
            this.b16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.b16.FlatAppearance.BorderSize = 0;
            this.b16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b16.Location = new System.Drawing.Point(125, 103);
            this.b16.Name = "b16";
            this.b16.Size = new System.Drawing.Size(13, 13);
            this.b16.TabIndex = 65;
            this.b16.TabStop = false;
            this.b16.UseVisualStyleBackColor = false;
            this.b16.Visible = false;
            // 
            // b17
            // 
            this.b17.BackColor = System.Drawing.Color.Green;
            this.b17.FlatAppearance.BorderSize = 0;
            this.b17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b17.Location = new System.Drawing.Point(164, 90);
            this.b17.Name = "b17";
            this.b17.Size = new System.Drawing.Size(13, 13);
            this.b17.TabIndex = 64;
            this.b17.TabStop = false;
            this.b17.UseVisualStyleBackColor = false;
            this.b17.Visible = false;
            // 
            // b18
            // 
            this.b18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.b18.FlatAppearance.BorderSize = 0;
            this.b18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b18.Location = new System.Drawing.Point(151, 90);
            this.b18.Name = "b18";
            this.b18.Size = new System.Drawing.Size(13, 13);
            this.b18.TabIndex = 63;
            this.b18.TabStop = false;
            this.b18.UseVisualStyleBackColor = false;
            this.b18.Visible = false;
            // 
            // b19
            // 
            this.b19.BackColor = System.Drawing.Color.Lime;
            this.b19.FlatAppearance.BorderSize = 0;
            this.b19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b19.Location = new System.Drawing.Point(138, 90);
            this.b19.Name = "b19";
            this.b19.Size = new System.Drawing.Size(13, 13);
            this.b19.TabIndex = 62;
            this.b19.TabStop = false;
            this.b19.UseVisualStyleBackColor = false;
            this.b19.Visible = false;
            // 
            // b20
            // 
            this.b20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.b20.FlatAppearance.BorderSize = 0;
            this.b20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b20.Location = new System.Drawing.Point(125, 90);
            this.b20.Name = "b20";
            this.b20.Size = new System.Drawing.Size(13, 13);
            this.b20.TabIndex = 61;
            this.b20.TabStop = false;
            this.b20.UseVisualStyleBackColor = false;
            this.b20.Visible = false;
            // 
            // b21
            // 
            this.b21.BackColor = System.Drawing.Color.Olive;
            this.b21.FlatAppearance.BorderSize = 0;
            this.b21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b21.Location = new System.Drawing.Point(164, 77);
            this.b21.Name = "b21";
            this.b21.Size = new System.Drawing.Size(13, 13);
            this.b21.TabIndex = 60;
            this.b21.TabStop = false;
            this.b21.UseVisualStyleBackColor = false;
            this.b21.Visible = false;
            // 
            // b22
            // 
            this.b22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.b22.FlatAppearance.BorderSize = 0;
            this.b22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b22.Location = new System.Drawing.Point(151, 77);
            this.b22.Name = "b22";
            this.b22.Size = new System.Drawing.Size(13, 13);
            this.b22.TabIndex = 59;
            this.b22.TabStop = false;
            this.b22.UseVisualStyleBackColor = false;
            this.b22.Visible = false;
            // 
            // b23
            // 
            this.b23.BackColor = System.Drawing.Color.Yellow;
            this.b23.FlatAppearance.BorderSize = 0;
            this.b23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b23.Location = new System.Drawing.Point(138, 77);
            this.b23.Name = "b23";
            this.b23.Size = new System.Drawing.Size(13, 13);
            this.b23.TabIndex = 58;
            this.b23.TabStop = false;
            this.b23.UseVisualStyleBackColor = false;
            this.b23.Visible = false;
            // 
            // b24
            // 
            this.b24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.b24.FlatAppearance.BorderSize = 0;
            this.b24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b24.Location = new System.Drawing.Point(125, 77);
            this.b24.Name = "b24";
            this.b24.Size = new System.Drawing.Size(13, 13);
            this.b24.TabIndex = 57;
            this.b24.TabStop = false;
            this.b24.UseVisualStyleBackColor = false;
            this.b24.Visible = false;
            // 
            // b9
            // 
            this.b9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.b9.FlatAppearance.BorderSize = 0;
            this.b9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b9.Location = new System.Drawing.Point(164, 64);
            this.b9.Name = "b9";
            this.b9.Size = new System.Drawing.Size(13, 13);
            this.b9.TabIndex = 56;
            this.b9.TabStop = false;
            this.b9.UseVisualStyleBackColor = false;
            this.b9.Visible = false;
            // 
            // b10
            // 
            this.b10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.b10.FlatAppearance.BorderSize = 0;
            this.b10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b10.Location = new System.Drawing.Point(151, 64);
            this.b10.Name = "b10";
            this.b10.Size = new System.Drawing.Size(13, 13);
            this.b10.TabIndex = 55;
            this.b10.TabStop = false;
            this.b10.UseVisualStyleBackColor = false;
            this.b10.Visible = false;
            // 
            // b11
            // 
            this.b11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.b11.FlatAppearance.BorderSize = 0;
            this.b11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b11.Location = new System.Drawing.Point(138, 64);
            this.b11.Name = "b11";
            this.b11.Size = new System.Drawing.Size(13, 13);
            this.b11.TabIndex = 54;
            this.b11.TabStop = false;
            this.b11.UseVisualStyleBackColor = false;
            this.b11.Visible = false;
            // 
            // b12
            // 
            this.b12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.b12.FlatAppearance.BorderSize = 0;
            this.b12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b12.Location = new System.Drawing.Point(125, 64);
            this.b12.Name = "b12";
            this.b12.Size = new System.Drawing.Size(13, 13);
            this.b12.TabIndex = 53;
            this.b12.TabStop = false;
            this.b12.UseVisualStyleBackColor = false;
            this.b12.Visible = false;
            // 
            // b5
            // 
            this.b5.BackColor = System.Drawing.Color.Maroon;
            this.b5.FlatAppearance.BorderSize = 0;
            this.b5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b5.Location = new System.Drawing.Point(164, 51);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(13, 13);
            this.b5.TabIndex = 52;
            this.b5.TabStop = false;
            this.b5.UseVisualStyleBackColor = false;
            this.b5.Visible = false;
            // 
            // b6
            // 
            this.b6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.b6.FlatAppearance.BorderSize = 0;
            this.b6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b6.Location = new System.Drawing.Point(151, 51);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(13, 13);
            this.b6.TabIndex = 51;
            this.b6.TabStop = false;
            this.b6.UseVisualStyleBackColor = false;
            this.b6.Visible = false;
            // 
            // b7
            // 
            this.b7.BackColor = System.Drawing.Color.Red;
            this.b7.FlatAppearance.BorderSize = 0;
            this.b7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b7.Location = new System.Drawing.Point(138, 51);
            this.b7.Name = "b7";
            this.b7.Size = new System.Drawing.Size(13, 13);
            this.b7.TabIndex = 50;
            this.b7.TabStop = false;
            this.b7.UseVisualStyleBackColor = false;
            this.b7.Visible = false;
            // 
            // b8
            // 
            this.b8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.b8.FlatAppearance.BorderSize = 0;
            this.b8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b8.Location = new System.Drawing.Point(125, 51);
            this.b8.Name = "b8";
            this.b8.Size = new System.Drawing.Size(13, 13);
            this.b8.TabIndex = 49;
            this.b8.TabStop = false;
            this.b8.UseVisualStyleBackColor = false;
            this.b8.Visible = false;
            // 
            // b4
            // 
            this.b4.BackColor = System.Drawing.Color.Black;
            this.b4.FlatAppearance.BorderSize = 0;
            this.b4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b4.Location = new System.Drawing.Point(164, 38);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(13, 13);
            this.b4.TabIndex = 48;
            this.b4.TabStop = false;
            this.b4.UseVisualStyleBackColor = false;
            this.b4.Visible = false;
            // 
            // b3
            // 
            this.b3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.b3.FlatAppearance.BorderSize = 0;
            this.b3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b3.Location = new System.Drawing.Point(151, 38);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(13, 13);
            this.b3.TabIndex = 47;
            this.b3.TabStop = false;
            this.b3.UseVisualStyleBackColor = false;
            this.b3.Visible = false;
            // 
            // b2
            // 
            this.b2.BackColor = System.Drawing.Color.Gray;
            this.b2.FlatAppearance.BorderSize = 0;
            this.b2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b2.Location = new System.Drawing.Point(138, 38);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(13, 13);
            this.b2.TabIndex = 46;
            this.b2.TabStop = false;
            this.b2.UseVisualStyleBackColor = false;
            this.b2.Visible = false;
            // 
            // b1
            // 
            this.b1.BackColor = System.Drawing.Color.White;
            this.b1.FlatAppearance.BorderSize = 0;
            this.b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b1.Location = new System.Drawing.Point(125, 38);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(13, 13);
            this.b1.TabIndex = 45;
            this.b1.TabStop = false;
            this.b1.UseVisualStyleBackColor = false;
            this.b1.Visible = false;
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
            // OnMapTypeCheckBox
            // 
            this.OnMapTypeCheckBox.AutoSize = true;
            this.OnMapTypeCheckBox.Location = new System.Drawing.Point(7, 84);
            this.OnMapTypeCheckBox.Name = "OnMapTypeCheckBox";
            this.OnMapTypeCheckBox.Size = new System.Drawing.Size(76, 17);
            this.OnMapTypeCheckBox.TabIndex = 4;
            this.OnMapTypeCheckBox.Text = "Battle type";
            this.OnMapTypeCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnMapAttsCheckBox
            // 
            this.OnMapAttsCheckBox.AutoSize = true;
            this.OnMapAttsCheckBox.Location = new System.Drawing.Point(7, 130);
            this.OnMapAttsCheckBox.Name = "OnMapAttsCheckBox";
            this.OnMapAttsCheckBox.Size = new System.Drawing.Size(106, 17);
            this.OnMapAttsCheckBox.TabIndex = 3;
            this.OnMapAttsCheckBox.Text = "Battle\'s attributes";
            this.OnMapAttsCheckBox.UseVisualStyleBackColor = true;
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
            this.OnMapTimeCheckBox.Location = new System.Drawing.Point(7, 107);
            this.OnMapTimeCheckBox.Name = "OnMapTimeCheckBox";
            this.OnMapTimeCheckBox.Size = new System.Drawing.Size(99, 17);
            this.OnMapTimeCheckBox.TabIndex = 1;
            this.OnMapTimeCheckBox.Text = "Battle\'s time left";
            this.OnMapTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // OnMapDesignerCheckBox
            // 
            this.OnMapDesignerCheckBox.AutoSize = true;
            this.OnMapDesignerCheckBox.Location = new System.Drawing.Point(7, 61);
            this.OnMapDesignerCheckBox.Name = "OnMapDesignerCheckBox";
            this.OnMapDesignerCheckBox.Size = new System.Drawing.Size(68, 17);
            this.OnMapDesignerCheckBox.TabIndex = 0;
            this.OnMapDesignerCheckBox.Text = "Designer";
            this.OnMapDesignerCheckBox.UseVisualStyleBackColor = true;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(10, 243);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(53, 23);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ResetLabel
            // 
            this.ResetLabel.Location = new System.Drawing.Point(69, 243);
            this.ResetLabel.Name = "ResetLabel";
            this.ResetLabel.Size = new System.Drawing.Size(128, 27);
            this.ResetLabel.TabIndex = 5;
            this.ResetLabel.Text = "Click this button to reset all settings to default.";
            // 
            // SimulateLabel
            // 
            this.SimulateLabel.AutoSize = true;
            this.SimulateLabel.Location = new System.Drawing.Point(22, 181);
            this.SimulateLabel.Name = "SimulateLabel";
            this.SimulateLabel.Size = new System.Drawing.Size(165, 13);
            this.SimulateLabel.TabIndex = 6;
            this.SimulateLabel.Text = "Simulate a new battle notification ";
            // 
            // NewBattleButton
            // 
            this.NewBattleButton.Location = new System.Drawing.Point(67, 197);
            this.NewBattleButton.Name = "NewBattleButton";
            this.NewBattleButton.Size = new System.Drawing.Size(75, 23);
            this.NewBattleButton.TabIndex = 7;
            this.NewBattleButton.Text = "New battle";
            this.NewBattleButton.UseVisualStyleBackColor = true;
            this.NewBattleButton.Click += new System.EventHandler(this.NewBattleButton_Click);
            // 
            // SoundOpenFileDialog
            // 
            this.SoundOpenFileDialog.Filter = "All Supported Audio | *.mp3; *.wma | MP3s | *.mp3 | WMAs | *.wma";
            // 
            // RandomNewBattleCheckBox
            // 
            this.RandomNewBattleCheckBox.AutoSize = true;
            this.RandomNewBattleCheckBox.Location = new System.Drawing.Point(16, 200);
            this.RandomNewBattleCheckBox.Name = "RandomNewBattleCheckBox";
            this.RandomNewBattleCheckBox.Size = new System.Drawing.Size(47, 17);
            this.RandomNewBattleCheckBox.TabIndex = 8;
            this.RandomNewBattleCheckBox.Text = "rand";
            this.RandomNewBattleCheckBox.UseVisualStyleBackColor = true;
            this.RandomNewBattleCheckBox.Visible = false;
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NewBattleButton);
            this.Controls.Add(this.RandomNewBattleCheckBox);
            this.Controls.Add(this.SimulateLabel);
            this.Controls.Add(this.ResetLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ShowOnMapGroup);
            this.Controls.Add(this.NotificationSoundGroup);
            this.Controls.Add(this.GeneralSettingsGroup);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(413, 297);
            this.Click += new System.EventHandler(this.SettingsPanel_Click);
            this.GeneralSettingsGroup.ResumeLayout(false);
            this.GeneralSettingsGroup.PerformLayout();
            this.NotificationSoundGroup.ResumeLayout(false);
            this.NotificationSoundGroup.PerformLayout();
            this.ShowOnMapGroup.ResumeLayout(false);
            this.ShowOnMapGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GeneralSettingsGroup;
        private System.Windows.Forms.GroupBox NotificationSoundGroup;
        private System.Windows.Forms.Label DefaultSoundLabel;
        private System.Windows.Forms.Button SetSoundButton;
        private System.Windows.Forms.GroupBox ShowOnMapGroup;
        private System.Windows.Forms.Label MapTextLabel;
        public System.Windows.Forms.CheckBox OnMapLevelCheckBox;
        public System.Windows.Forms.CheckBox OnMapTimeCheckBox;
        public System.Windows.Forms.CheckBox OnMapDesignerCheckBox;
        public System.Windows.Forms.CheckBox OnMapTypeCheckBox;
        public System.Windows.Forms.CheckBox OnMapAttsCheckBox;
        public System.Windows.Forms.CheckBox ShowOnTopCheckBox;
        public System.Windows.Forms.CheckBox StartupCheckBox;
        public System.Windows.Forms.CheckBox FadeCheckBox;
        public System.Windows.Forms.CheckBox HideToTraybarCheckBox;
        public System.Windows.Forms.TextBox CustomSoundPathTextBox;
        public System.Windows.Forms.ComboBox DefaultSoundComboBox;
        public System.Windows.Forms.CheckBox UseCustomSoundCheckBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label ResetLabel;
        public System.Windows.Forms.CheckBox TransparentCheckBox;
        public System.Windows.Forms.CheckBox HidePrintCheckBox;
        private System.Windows.Forms.Label SimulateLabel;
        private System.Windows.Forms.Button NewBattleButton;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b4;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b25;
        private System.Windows.Forms.Button b26;
        private System.Windows.Forms.Button b27;
        private System.Windows.Forms.Button b28;
        private System.Windows.Forms.Button b29;
        private System.Windows.Forms.Button b30;
        private System.Windows.Forms.Button b31;
        private System.Windows.Forms.Button b32;
        private System.Windows.Forms.Button b13;
        private System.Windows.Forms.Button b14;
        private System.Windows.Forms.Button b15;
        private System.Windows.Forms.Button b16;
        private System.Windows.Forms.Button b17;
        private System.Windows.Forms.Button b18;
        private System.Windows.Forms.Button b19;
        private System.Windows.Forms.Button b20;
        private System.Windows.Forms.Button b21;
        private System.Windows.Forms.Button b22;
        private System.Windows.Forms.Button b23;
        private System.Windows.Forms.Button b24;
        private System.Windows.Forms.Button b9;
        private System.Windows.Forms.Button b10;
        private System.Windows.Forms.Button b11;
        private System.Windows.Forms.Button b12;
        private System.Windows.Forms.Button b5;
        private System.Windows.Forms.Button b6;
        private System.Windows.Forms.Button b7;
        private System.Windows.Forms.Button b8;
        public System.Windows.Forms.Button ColorPicker;
        private System.Windows.Forms.OpenFileDialog SoundOpenFileDialog;
        private System.Windows.Forms.CheckBox RandomNewBattleCheckBox;
    }
}
