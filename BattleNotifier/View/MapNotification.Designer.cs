namespace BattleNotifier.View
{
    partial class MapNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapNotification));
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.AttributesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(320, 240);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.TypeLabel.Location = new System.Drawing.Point(12, 149);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(61, 13);
            this.TypeLabel.TabIndex = 1;
            this.TypeLabel.Text = "Battle Type";
            this.TypeLabel.Visible = false;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.HeaderLabel.Location = new System.Drawing.Point(12, 115);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HeaderLabel.Size = new System.Drawing.Size(145, 13);
            this.HeaderLabel.TabIndex = 2;
            this.HeaderLabel.Text = "Level001 by Kuski Nickname";
            this.HeaderLabel.Visible = false;
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimerLabel.Location = new System.Drawing.Point(12, 75);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(34, 13);
            this.TimerLabel.TabIndex = 3;
            this.TimerLabel.Text = "60:00";
            this.TimerLabel.Visible = false;
            // 
            // AttributesLabel
            // 
            this.AttributesLabel.AutoSize = true;
            this.AttributesLabel.BackColor = System.Drawing.Color.Transparent;
            this.AttributesLabel.Location = new System.Drawing.Point(12, 9);
            this.AttributesLabel.Name = "AttributesLabel";
            this.AttributesLabel.Size = new System.Drawing.Size(278, 13);
            this.AttributesLabel.TabIndex = 4;
            this.AttributesLabel.Text = "Others shown, allow started, one wheel, no brake, no volt";
            this.AttributesLabel.Visible = false;
            // 
            // MapNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.AttributesLabel);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapNotification";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapNotification_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Label AttributesLabel;
    }
}