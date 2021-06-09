
using System;

namespace Null_Sector
{
    partial class SettingsWindow
    {
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

        #region

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackButton = new System.Windows.Forms.PictureBox();
            this.Slider = new System.Windows.Forms.PictureBox();
            this.musicQuieter = new System.Windows.Forms.PictureBox();
            this.musicLouder = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicQuieter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicLouder)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.Image = global::Null_Sector.Properties.Resources.back0;
            this.BackButton.Location = new System.Drawing.Point(24, 24);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(92, 92);
            this.BackButton.TabIndex = 0;
            this.BackButton.TabStop = false;
            this.BackButton.Click += new System.EventHandler(this.backButton_Click);
            this.BackButton.MouseEnter += new System.EventHandler(this.backButton_Enter);
            this.BackButton.MouseLeave += new System.EventHandler(this.backButton_Leave);
            // 
            // Slider
            // 
            this.Slider.BackColor = System.Drawing.Color.Transparent;
            this.Slider.Image = global::Null_Sector.Properties.Resources.slider;
            this.Slider.Location = new System.Drawing.Point(404, 176);
            this.Slider.Name = "Slider";
            this.Slider.Size = new System.Drawing.Size(23, 36);
            this.Slider.TabIndex = 2;
            this.Slider.TabStop = false;
            // 
            // musicQuieter
            // 
            this.musicQuieter.BackColor = System.Drawing.Color.Transparent;
            this.musicQuieter.Image = global::Null_Sector.Properties.Resources.minus0;
            this.musicQuieter.Location = new System.Drawing.Point(372, 164);
            this.musicQuieter.Name = "musicQuieter";
            this.musicQuieter.Size = new System.Drawing.Size(32, 60);
            this.musicQuieter.TabIndex = 3;
            this.musicQuieter.TabStop = false;
            this.musicQuieter.Click += new System.EventHandler(this.musicQuieter_Click);
            this.musicQuieter.MouseEnter += new System.EventHandler(this.musicQuieter_Enter);
            this.musicQuieter.MouseLeave += new System.EventHandler(this.musicQuieter_Leave);
            // 
            // musicLouder
            // 
            this.musicLouder.BackColor = System.Drawing.Color.Transparent;
            this.musicLouder.Image = global::Null_Sector.Properties.Resources.plus0;
            this.musicLouder.Location = new System.Drawing.Point(736, 164);
            this.musicLouder.Name = "musicLouder";
            this.musicLouder.Size = new System.Drawing.Size(32, 60);
            this.musicLouder.TabIndex = 4;
            this.musicLouder.TabStop = false;
            this.musicLouder.Click += new System.EventHandler(this.musicLouder_Click);
            this.musicLouder.MouseEnter += new System.EventHandler(this.musicLouder_Enter);
            this.musicLouder.MouseLeave += new System.EventHandler(this.musicLouder_Leave);
            // 
            // SettingsWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::Null_Sector.Properties.Resources.settingsBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.musicLouder);
            this.Controls.Add(this.musicQuieter);
            this.Controls.Add(this.Slider);
            this.Controls.Add(this.BackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsWindow";
            this.Text = "NULL-SECTOR : Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicQuieter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicLouder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.PictureBox Slider;
        private System.Windows.Forms.PictureBox musicQuieter;
        private System.Windows.Forms.PictureBox musicLouder;
    }
}