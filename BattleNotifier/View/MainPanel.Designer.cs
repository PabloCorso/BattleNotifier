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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPanel));
            this.DesignersLabel = new System.Windows.Forms.Label();
            this.NotificationDurationTrackBar = new System.Windows.Forms.TrackBar();
            this.StartNotificationButton = new System.Windows.Forms.Button();
            this.DesignersChListBox = new System.Windows.Forms.CheckedListBox();
            this.BattleTypesLabel = new System.Windows.Forms.Label();
            this.BattleTypesChListBox = new System.Windows.Forms.CheckedListBox();
            this.SearchDesignerTextBox = new System.Windows.Forms.TextBox();
            this.AddDesignerButton = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.NotificationLabel = new System.Windows.Forms.Label();
            this.ShowMapCheckBox = new System.Windows.Forms.CheckBox();
            this.PlaySoundCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowBattleCheckBox = new System.Windows.Forms.CheckBox();
            this.CloseDialogNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CloseDialogTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.CloseDialogTimeLabel1 = new System.Windows.Forms.Label();
            this.CloseDialogTimeLabel2 = new System.Windows.Forms.Label();
            this.BlackListChListBox = new System.Windows.Forms.CheckedListBox();
            this.BlackListLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.MapSizeDomainUpDown = new System.Windows.Forms.DomainUpDown();
            this.mapSizeLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DisplayScreenLabel = new System.Windows.Forms.Label();
            this.DisplayScreenButton = new System.Windows.Forms.Button();
            this.ShowCurrentButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.ShowCurrentHotkeyTextBox = new BattleNotifier.View.Controls.HotkeyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NotificationDurationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseDialogNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DesignersLabel
            // 
            this.DesignersLabel.AutoSize = true;
            this.DesignersLabel.Location = new System.Drawing.Point(3, 10);
            this.DesignersLabel.Name = "DesignersLabel";
            this.DesignersLabel.Size = new System.Drawing.Size(77, 13);
            this.DesignersLabel.TabIndex = 31;
            this.DesignersLabel.Text = "Filter designers";
            this.ToolTip.SetToolTip(this.DesignersLabel, resources.GetString("DesignersLabel.ToolTip"));
            // 
            // NotificationDurationTrackBar
            // 
            this.NotificationDurationTrackBar.Location = new System.Drawing.Point(142, 243);
            this.NotificationDurationTrackBar.Name = "NotificationDurationTrackBar";
            this.NotificationDurationTrackBar.Size = new System.Drawing.Size(277, 45);
            this.NotificationDurationTrackBar.TabIndex = 3;
            this.ToolTip.SetToolTip(this.NotificationDurationTrackBar, "Set a timer to stop notifying. Time is shown on Start button.\r\nFirst value of the" +
        " track bar means no timer is set.");
            this.NotificationDurationTrackBar.ValueChanged += new System.EventHandler(this.NotificationDurationTrackBar_ValueChanged);
            // 
            // StartNotificationButton
            // 
            this.StartNotificationButton.Location = new System.Drawing.Point(6, 243);
            this.StartNotificationButton.Name = "StartNotificationButton";
            this.StartNotificationButton.Size = new System.Drawing.Size(120, 45);
            this.StartNotificationButton.TabIndex = 2;
            this.StartNotificationButton.Text = "▶ Start";
            this.ToolTip.SetToolTip(this.StartNotificationButton, "\r\nStart battle notifications! Ctrl+R shortcut for start/restart.");
            this.StartNotificationButton.UseVisualStyleBackColor = true;
            this.StartNotificationButton.Click += new System.EventHandler(this.StartNotificationButton_Click);
            // 
            // DesignersChListBox
            // 
            this.DesignersChListBox.CheckOnClick = true;
            this.DesignersChListBox.FormattingEnabled = true;
            this.DesignersChListBox.IntegralHeight = false;
            this.DesignersChListBox.Location = new System.Drawing.Point(6, 61);
            this.DesignersChListBox.Name = "DesignersChListBox";
            this.DesignersChListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.DesignersChListBox.Size = new System.Drawing.Size(120, 80);
            this.DesignersChListBox.TabIndex = 27;
            this.DesignersChListBox.TabStop = false;
            this.ToolTip.SetToolTip(this.DesignersChListBox, "Press right click over a kuski to move him from this list to the black \r\nlist and" +
        " viceversa. Press middle click over a kuski to remove him.");
            this.DesignersChListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DesignersChListBox_MouseDown);
            // 
            // BattleTypesLabel
            // 
            this.BattleTypesLabel.AutoSize = true;
            this.BattleTypesLabel.Location = new System.Drawing.Point(149, 10);
            this.BattleTypesLabel.Name = "BattleTypesLabel";
            this.BattleTypesLabel.Size = new System.Drawing.Size(86, 13);
            this.BattleTypesLabel.TabIndex = 21;
            this.BattleTypesLabel.Text = "Filter battle types";
            // 
            // BattleTypesChListBox
            // 
            this.BattleTypesChListBox.CheckOnClick = true;
            this.BattleTypesChListBox.FormattingEnabled = true;
            this.BattleTypesChListBox.Location = new System.Drawing.Point(152, 36);
            this.BattleTypesChListBox.Name = "BattleTypesChListBox";
            this.BattleTypesChListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.BattleTypesChListBox.Size = new System.Drawing.Size(120, 184);
            this.BattleTypesChListBox.TabIndex = 20;
            this.BattleTypesChListBox.TabStop = false;
            this.ToolTip.SetToolTip(this.BattleTypesChListBox, "Only checked battle types will be notificated unless \"All battle types\"\r\nis check" +
        "ed, in that case all battle types will be taken into account.");
            this.BattleTypesChListBox.Click += new System.EventHandler(this.BattleTypesChListBox_Click);
            // 
            // SearchDesignerTextBox
            // 
            this.SearchDesignerTextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "-Nico-o",
            "-Tony-",
            "5tr1k3r",
            "8-ball",
            "Abula",
            "adi",
            "AKB",
            "Ali",
            "Alma",
            "alvin",
            "ANATOLIY",
            "anpdad",
            "Apelgam",
            "Are",
            "astral-r",
            "axxu",
            "badyl",
            "barryp",
            "BarTek",
            "Bbl Bce CyKu",
            "bEAT",
            "BENNY",
            "Bismuth",
            "Bjenn",
            "Bludek",
            "BoneLESS",
            "Boomer",
            "Cap",
            "Cfilorvy",
            "Chaza",
            "Chip",
            "Coco",
            "CSabi",
            "DaFred",
            "Dariuz",
            "Dash",
            "DCEM",
            "Dead One",
            "Death",
            "Ded",
            "Domi",
            "DRACON",
            "Drakula",
            "DreamHunter",
            "Dynamo",
            "dz",
            "Ecchi",
            "Eddi",
            "Elfy",
            "ElrondMcBong",
            "epp",
            "error",
            "ExTeC",
            "fabio",
            "Fanatico",
            "Fecal",
            "finman",
            "Fredrik",
            "Giancarlo",
            "gimp",
            "GraduS",
            "Grindelwald",
            "GRob",
            "Haruhi",
            "hehe",
            "Honza",
            "Hosp",
            "Ice",
            "igge",
            "inf3rno",
            "infected",
            "Inferno",
            "Ismo",
            "Ithal",
            "J-sim",
            "Jalli",
            "Jamppa",
            "Jappe2",
            "Jarkko",
            "jaytea",
            "jblaze",
            "Jeppe",
            "John",
            "Johnny",
            "jonsta",
            "jonsykkel",
            "JSmith",
            "Juish",
            "juka",
            "Juzam",
            "k0en",
            "k00",
            "kabii",
            "Kazan",
            "kd",
            "Kejebra",
            "kestas",
            "Kiiwi",
            "Kingy",
            "Koopa",
            "Kopaka",
            "Kostyak",
            "Kowal",
            "kuchitsu",
            "Kuper",
            "Kuri",
            "Labs",
            "LazY",
            "Leek",
            "Lousku",
            "Lukazz",
            "Lumen",
            "Luther",
            "Maala",
            "MadMad",
            "Madness",
            "Magb",
            "magicman",
            "Marian",
            "Markku",
            "Mats",
            "Mawane",
            "Max",
            "Maximus",
            "mcleod",
            "Memphis",
            "MicroGen",
            "Mielz",
            "Mika",
            "mikl",
            "milagros",
            "MJXII",
            "Mochi",
            "Morgan",
            "Moszat",
            "MP",
            "Mpq",
            "mr",
            "Mrrrr",
            "Munkki",
            "NaDiRu",
            "Nekit",
            "nick-o-matic",
            "NightMar",
            "niN",
            "nobody",
            "noni",
            "nozkey",
            "ofta",
            "Old_Bjorn",
            "onla",
            "Orcc",
            "p-skript",
            "Pab",
            "Pascal",
            "Pawq",
            "Peacemaker",
            "Pek",
            "PELUSON27",
            "Phillip",
            "PJ",
            "Player",
            "Player1",
            "Polarix",
            "proDigy",
            "Punxer",
            "Quantz",
            "Raane",
            "Ramone",
            "Ramzi",
            "Rasken",
            "Rast",
            "Raven",
            "ribot",
            "robbla",
            "romy4",
            "Rooker",
            "roope",
            "Ropelli",
            "Salsa",
            "SCASI",
            "schiz",
            "schnon",
            "Schumi",
            "semyr",
            "SIC",
            "Sick_Mambo",
            "Sienna",
            "skint0r",
            "sla",
            "Smibu",
            "snajdig",
            "SORIN283",
            "Souza",
            "Staar",
            "stefankivb",
            "Stini",
            "Suharice",
            "SveinR",
            "talli",
            "tamugol1",
            "TarGEnoR",
            "tatujka",
            "teajay",
            "terb0",
            "ThanaTos",
            "The OooO",
            "Thunder",
            "Tigro",
            "Tisk",
            "TL",
            "Tm",
            "totem",
            "trew",
            "TTechnik",
            "TuA",
            "tubby",
            "Ulaanaa",
            "umiz",
            "Uncle Milty",
            "undi",
            "VALDO",
            "veezay",
            "Ves",
            "ville_j",
            "Virus",
            "VT",
            "Wacco",
            "wazsi",
            "Weep",
            "wjelo",
            "Xhomaz",
            "Xiphias",
            "xonii",
            "YEAHS",
            "yohanu",
            "Yoni",
            "yoosef",
            "yOwie",
            "yuno uno",
            "zebra",
            "zelterboij",
            "Zero",
            "Zerox",
            "Zid",
            "Zox",
            "Zweq",
            "zwor"});
            this.SearchDesignerTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SearchDesignerTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchDesignerTextBox.Location = new System.Drawing.Point(6, 36);
            this.SearchDesignerTextBox.Name = "SearchDesignerTextBox";
            this.SearchDesignerTextBox.Size = new System.Drawing.Size(92, 20);
            this.SearchDesignerTextBox.TabIndex = 1;
            this.ToolTip.SetToolTip(this.SearchDesignerTextBox, "\r\nWrite a kuski name and press enter or + button to add him to the list.");
            this.SearchDesignerTextBox.Enter += new System.EventHandler(this.SearchDesignerTextBox_Enter);
            this.SearchDesignerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchDesignerTextBox_KeyDown);
            // 
            // AddDesignerButton
            // 
            this.AddDesignerButton.Location = new System.Drawing.Point(104, 36);
            this.AddDesignerButton.Name = "AddDesignerButton";
            this.AddDesignerButton.Size = new System.Drawing.Size(22, 20);
            this.AddDesignerButton.TabIndex = 2;
            this.AddDesignerButton.Text = "+";
            this.ToolTip.SetToolTip(this.AddDesignerButton, "\r\n");
            this.AddDesignerButton.UseVisualStyleBackColor = true;
            this.AddDesignerButton.Click += new System.EventHandler(this.AddDesignerButton_Click);
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
            this.NotificationLabel.Size = new System.Drawing.Size(65, 13);
            this.NotificationLabel.TabIndex = 26;
            this.NotificationLabel.Text = "Notifications";
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
            this.ToolTip.SetToolTip(this.ShowMapCheckBox, "Show battle\'s map at notifications with the desired size.\r\nTip: middle click over" +
        " it to close or right click too see more options.");
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
            this.ToolTip.SetToolTip(this.PlaySoundCheckBox, "\r\nPlay a sound at notifications. See settings to select the sound.");
            this.PlaySoundCheckBox.UseVisualStyleBackColor = true;
            this.PlaySoundCheckBox.CheckedChanged += new System.EventHandler(this.PlaySoundCheckBox_CheckedChanged);
            // 
            // ShowBattleCheckBox
            // 
            this.ShowBattleCheckBox.AutoSize = true;
            this.ShowBattleCheckBox.Location = new System.Drawing.Point(297, 36);
            this.ShowBattleCheckBox.Name = "ShowBattleCheckBox";
            this.ShowBattleCheckBox.Size = new System.Drawing.Size(102, 17);
            this.ShowBattleCheckBox.TabIndex = 38;
            this.ShowBattleCheckBox.TabStop = false;
            this.ShowBattleCheckBox.Text = "Show battle info";
            this.ToolTip.SetToolTip(this.ShowBattleCheckBox, "Show battle\'s information window at notifications.\r\nTip: click the level\'s name t" +
        "o see the battle on elmaoline.");
            this.ShowBattleCheckBox.UseVisualStyleBackColor = true;
            this.ShowBattleCheckBox.CheckedChanged += new System.EventHandler(this.ShowBattleCheckBox_CheckedChanged);
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
            this.ToolTip.SetToolTip(this.CloseDialogNumericUpDown, "\r\nClose notifications after a choosen amount of seconds.");
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
            this.ToolTip.SetToolTip(this.CloseDialogTimeCheckBox, "\r\nClose notifications after a chosen amount of seconds.");
            this.CloseDialogTimeCheckBox.UseVisualStyleBackColor = true;
            this.CloseDialogTimeCheckBox.CheckedChanged += new System.EventHandler(this.CloseDialogTimeCheckBox_CheckedChanged);
            // 
            // CloseDialogTimeLabel1
            // 
            this.CloseDialogTimeLabel1.AutoSize = true;
            this.CloseDialogTimeLabel1.Location = new System.Drawing.Point(300, 147);
            this.CloseDialogTimeLabel1.Name = "CloseDialogTimeLabel1";
            this.CloseDialogTimeLabel1.Size = new System.Drawing.Size(28, 13);
            this.CloseDialogTimeLabel1.TabIndex = 44;
            this.CloseDialogTimeLabel1.Text = "after";
            this.ToolTip.SetToolTip(this.CloseDialogTimeLabel1, "\r\nClose notifications after a choosen amount of seconds.");
            // 
            // CloseDialogTimeLabel2
            // 
            this.CloseDialogTimeLabel2.AutoSize = true;
            this.CloseDialogTimeLabel2.Location = new System.Drawing.Point(367, 147);
            this.CloseDialogTimeLabel2.Name = "CloseDialogTimeLabel2";
            this.CloseDialogTimeLabel2.Size = new System.Drawing.Size(29, 13);
            this.CloseDialogTimeLabel2.TabIndex = 45;
            this.CloseDialogTimeLabel2.Text = "secs";
            this.ToolTip.SetToolTip(this.CloseDialogTimeLabel2, "\r\nClose notifications after a choosen amount of seconds.");
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
            this.ToolTip.SetToolTip(this.BlackListChListBox, "Checked kuskis on the blacklist won\'t be taken into account for \r\nnotifications, " +
        "even when \"All designers\" is checked.");
            this.BlackListChListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BlackListChListBox_MouseDown);
            // 
            // BlackListLabel
            // 
            this.BlackListLabel.AutoSize = true;
            this.BlackListLabel.Location = new System.Drawing.Point(3, 143);
            this.BlackListLabel.Name = "BlackListLabel";
            this.BlackListLabel.Size = new System.Drawing.Size(46, 13);
            this.BlackListLabel.TabIndex = 47;
            this.BlackListLabel.Text = "Blacklist";
            this.ToolTip.SetToolTip(this.BlackListLabel, "Kuskis on the black list wont be taken into account for \r\nnotifications, even whe" +
        "n \"All designers\" is checked.");
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
            this.MapSizeDomainUpDown.Items.Add("huge");
            this.MapSizeDomainUpDown.Items.Add("big");
            this.MapSizeDomainUpDown.Items.Add("norm");
            this.MapSizeDomainUpDown.Items.Add("small");
            this.MapSizeDomainUpDown.Items.Add("tiny");
            this.MapSizeDomainUpDown.Location = new System.Drawing.Point(348, 78);
            this.MapSizeDomainUpDown.Name = "MapSizeDomainUpDown";
            this.MapSizeDomainUpDown.ReadOnly = true;
            this.MapSizeDomainUpDown.Size = new System.Drawing.Size(44, 20);
            this.MapSizeDomainUpDown.TabIndex = 49;
            this.MapSizeDomainUpDown.TabStop = false;
            this.ToolTip.SetToolTip(this.MapSizeDomainUpDown, "\r\nShow battle\'s map on notifications and choose it\'s size.");
            // 
            // mapSizeLabel
            // 
            this.mapSizeLabel.AutoSize = true;
            this.mapSizeLabel.Location = new System.Drawing.Point(300, 80);
            this.mapSizeLabel.Name = "mapSizeLabel";
            this.mapSizeLabel.Size = new System.Drawing.Size(48, 13);
            this.mapSizeLabel.TabIndex = 50;
            this.mapSizeLabel.Text = "map size";
            this.ToolTip.SetToolTip(this.mapSizeLabel, "\r\nShow battle\'s map on notifications and choose it\'s size.");
            // 
            // ToolTip
            // 
            this.ToolTip.Active = false;
            this.ToolTip.AutoPopDelay = 32000;
            this.ToolTip.InitialDelay = 32000;
            this.ToolTip.ReshowDelay = 100;
            // 
            // DisplayScreenLabel
            // 
            this.DisplayScreenLabel.AutoSize = true;
            this.DisplayScreenLabel.Location = new System.Drawing.Point(294, 173);
            this.DisplayScreenLabel.Name = "DisplayScreenLabel";
            this.DisplayScreenLabel.Size = new System.Drawing.Size(76, 13);
            this.DisplayScreenLabel.TabIndex = 52;
            this.DisplayScreenLabel.Text = "Display screen";
            this.ToolTip.SetToolTip(this.DisplayScreenLabel, "\r\nChoose in which screen notifications will be shown.");
            // 
            // DisplayScreenButton
            // 
            this.DisplayScreenButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DisplayScreenButton.FlatAppearance.BorderSize = 0;
            this.DisplayScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisplayScreenButton.Location = new System.Drawing.Point(370, 171);
            this.DisplayScreenButton.Name = "DisplayScreenButton";
            this.DisplayScreenButton.Size = new System.Drawing.Size(24, 20);
            this.DisplayScreenButton.TabIndex = 53;
            this.DisplayScreenButton.TabStop = false;
            this.DisplayScreenButton.Text = "0";
            this.ToolTip.SetToolTip(this.DisplayScreenButton, "\r\nChoose in which screen notifications will be shown.");
            this.DisplayScreenButton.UseVisualStyleBackColor = false;
            this.DisplayScreenButton.Click += new System.EventHandler(this.DisplayScreenButton_Click);
            // 
            // ShowCurrentButton
            // 
            this.ShowCurrentButton.Location = new System.Drawing.Point(297, 197);
            this.ShowCurrentButton.Name = "ShowCurrentButton";
            this.ShowCurrentButton.Size = new System.Drawing.Size(97, 21);
            this.ShowCurrentButton.TabIndex = 54;
            this.ShowCurrentButton.Text = "Show/hide battle";
            this.ToolTip.SetToolTip(this.ShowCurrentButton, "Click to notificate the last started battle (filters don\'t matter) or to close \r\n" +
        "current notification. Won\'t show anything if never started to notify.");
            this.ShowCurrentButton.UseVisualStyleBackColor = true;
            this.ShowCurrentButton.Click += new System.EventHandler(this.ShowCurrentButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.BackgroundImage = global::BattleNotifier.Properties.Resources.about_icon;
            this.AboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AboutButton.FlatAppearance.BorderSize = 0;
            this.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutButton.Location = new System.Drawing.Point(378, 10);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(14, 14);
            this.AboutButton.TabIndex = 56;
            this.AboutButton.TabStop = false;
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ShowCurrentHotkeyTextBox
            // 
            this.ShowCurrentHotkeyTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowCurrentHotkeyTextBox.Hotkey = System.Windows.Forms.Keys.None;
            this.ShowCurrentHotkeyTextBox.HotkeyModifiers = System.Windows.Forms.Keys.None;
            this.ShowCurrentHotkeyTextBox.Location = new System.Drawing.Point(298, 221);
            this.ShowCurrentHotkeyTextBox.Name = "ShowCurrentHotkeyTextBox";
            this.ShowCurrentHotkeyTextBox.Size = new System.Drawing.Size(96, 20);
            this.ShowCurrentHotkeyTextBox.TabIndex = 55;
            this.ShowCurrentHotkeyTextBox.TabStop = false;
            this.ShowCurrentHotkeyTextBox.Text = "None";
            this.ToolTip.SetToolTip(this.ShowCurrentHotkeyTextBox, "Set a global hotkey to show/hide battle. Click the field and press \r\nthe desired " +
        "hotkey. Click outside the field once your hotkey is set.");
            this.ShowCurrentHotkeyTextBox.Enter += new System.EventHandler(this.ShowCurrentHotkeyTextBox_Enter);
            this.ShowCurrentHotkeyTextBox.Leave += new System.EventHandler(this.ShowCurrentHotkeyTextBox_Leave);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.ShowCurrentHotkeyTextBox);
            this.Controls.Add(this.ShowCurrentButton);
            this.Controls.Add(this.DisplayScreenButton);
            this.Controls.Add(this.DisplayScreenLabel);
            this.Controls.Add(this.mapSizeLabel);
            this.Controls.Add(this.MapSizeDomainUpDown);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.BlackListLabel);
            this.Controls.Add(this.BlackListChListBox);
            this.Controls.Add(this.CloseDialogTimeLabel2);
            this.Controls.Add(this.CloseDialogTimeLabel1);
            this.Controls.Add(this.CloseDialogTimeCheckBox);
            this.Controls.Add(this.CloseDialogNumericUpDown);
            this.Controls.Add(this.ShowBattleCheckBox);
            this.Controls.Add(this.PlaySoundCheckBox);
            this.Controls.Add(this.ShowMapCheckBox);
            this.Controls.Add(this.AddDesignerButton);
            this.Controls.Add(this.DesignersLabel);
            this.Controls.Add(this.NotificationDurationTrackBar);
            this.Controls.Add(this.StartNotificationButton);
            this.Controls.Add(this.DesignersChListBox);
            this.Controls.Add(this.NotificationLabel);
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
        private System.Windows.Forms.Label BattleTypesLabel;
        private System.Windows.Forms.Button AddDesignerButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label NotificationLabel;
        private System.Windows.Forms.Label CloseDialogTimeLabel1;
        private System.Windows.Forms.Label CloseDialogTimeLabel2;
        public System.Windows.Forms.CheckBox ShowMapCheckBox;
        public System.Windows.Forms.CheckBox PlaySoundCheckBox;
        public System.Windows.Forms.CheckBox ShowBattleCheckBox;
        public System.Windows.Forms.NumericUpDown CloseDialogNumericUpDown;
        public System.Windows.Forms.CheckBox CloseDialogTimeCheckBox;
        public System.Windows.Forms.TrackBar NotificationDurationTrackBar;
        public System.Windows.Forms.CheckedListBox DesignersChListBox;
        public System.Windows.Forms.CheckedListBox BattleTypesChListBox;
        public System.Windows.Forms.CheckedListBox BlackListChListBox;
        private System.Windows.Forms.Label BlackListLabel;
        internal System.Windows.Forms.TextBox SearchDesignerTextBox;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label mapSizeLabel;
        public System.Windows.Forms.DomainUpDown MapSizeDomainUpDown;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label DisplayScreenLabel;
        public System.Windows.Forms.Button DisplayScreenButton;
        private System.Windows.Forms.Button ShowCurrentButton;
        public Controls.HotkeyTextBox ShowCurrentHotkeyTextBox;
        private System.Windows.Forms.Button AboutButton;
    }
}
