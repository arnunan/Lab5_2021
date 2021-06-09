using User;
using System;
using System.IO;

namespace Null_Sector
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.settingsButton = new System.Windows.Forms.PictureBox();
            this.loadButton = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.PictureBox();
            this.SaveFileLoader = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.settingsButton);
            this.panel1.Controls.Add(this.loadButton);
            this.panel1.Controls.Add(this.playButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 439);
            this.panel1.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Image = global::Null_Sector.Properties.Resources.exit0;
            this.exitButton.Location = new System.Drawing.Point(0, 330);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(364, 104);
            this.exitButton.TabIndex = 3;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_Enter);
            this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_Leave);
            // 
            // settingsButton
            // 
            this.settingsButton.Image = global::Null_Sector.Properties.Resources.settings0;
            this.settingsButton.Location = new System.Drawing.Point(0, 220);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(552, 104);
            this.settingsButton.TabIndex = 2;
            this.settingsButton.TabStop = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            this.settingsButton.MouseEnter += new System.EventHandler(this.settingsButton_Enter);
            this.settingsButton.MouseLeave += new System.EventHandler(this.settingsButton_Leave);
            // 
            // loadButton
            // 
            this.loadButton.Image = global::Null_Sector.Properties.Resources.load0;
            this.loadButton.Location = new System.Drawing.Point(0, 110);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(560, 104);
            this.loadButton.TabIndex = 1;
            this.loadButton.TabStop = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            this.loadButton.MouseEnter += new System.EventHandler(this.loadButton_Enter);
            this.loadButton.MouseLeave += new System.EventHandler(this.loadButton_Leave);
            // 
            // playButton
            // 
            this.playButton.Image = global::Null_Sector.Properties.Resources.play0;
            this.playButton.Location = new System.Drawing.Point(0, 0);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(404, 104);
            this.playButton.TabIndex = 0;
            this.playButton.TabStop = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_Enter);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_Leave);
            // 
            // SaveFileLoader
            // 
            this.SaveFileLoader.Filter = "Save files|*.save";
            this.SaveFileLoader.InitialDirectory = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Save";
            this.SaveFileLoader.RestoreDirectory = true;
            this.SaveFileLoader.Title = "Save File";
            // 
            // MainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::Null_Sector.Properties.Resources.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainMenu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "NULL-SECTOR";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox playButton;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.PictureBox settingsButton;
        private System.Windows.Forms.PictureBox loadButton;
        private System.Windows.Forms.OpenFileDialog SaveFileLoader;
    }
}

