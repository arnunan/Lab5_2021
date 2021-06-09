
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using User;

namespace Null_Sector
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.TerminalWindow = new System.Windows.Forms.TextBox();
            this.Input = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.Metal = new System.Windows.Forms.Panel();
            this.mCount = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.Electronics = new System.Windows.Forms.Panel();
            this.eCount = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Food = new System.Windows.Forms.Panel();
            this.fCount = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Weapon = new System.Windows.Forms.Panel();
            this.wValue = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Charisma = new System.Windows.Forms.Panel();
            this.cValue = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Engineering = new System.Windows.Forms.Panel();
            this.eValue = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.Table = new System.Windows.Forms.TableLayoutPanel();
            this.FieldWindow = new SelectablePanel();
            this.ResourcePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Metal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.Electronics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Food.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.Weapon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.Charisma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.Engineering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.Table.SuspendLayout();
            this.ResourcePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TerminalWindow
            // 
            this.TerminalWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Table.SetColumnSpan(this.TerminalWindow, 2);
            this.TerminalWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TerminalWindow.Location = new System.Drawing.Point(521, 3);
            this.TerminalWindow.Multiline = true;
            this.TerminalWindow.Name = "TerminalWindow";
            this.TerminalWindow.ReadOnly = true;
            this.TerminalWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TerminalWindow.Size = new System.Drawing.Size(276, 486);
            this.TerminalWindow.TabIndex = 1;
            // 
            // Input
            // 
            this.Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Input.Location = new System.Drawing.Point(521, 495);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(253, 22);
            this.Input.TabIndex = 2;
            // 
            // Send
            // 
            this.Send.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Send.Location = new System.Drawing.Point(780, 495);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(17, 21);
            this.Send.TabIndex = 3;
            this.Send.Text = "S";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Metal
            // 
            this.Metal.Controls.Add(this.mCount);
            this.Metal.Controls.Add(this.pic);
            this.Metal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Metal.Location = new System.Drawing.Point(0, 0);
            this.Metal.Margin = new System.Windows.Forms.Padding(0);
            this.Metal.Name = "Metal";
            this.Metal.Size = new System.Drawing.Size(129, 64);
            this.Metal.TabIndex = 0;
            // 
            // mCount
            // 
            this.mCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mCount.AutoSize = true;
            this.mCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mCount.Location = new System.Drawing.Point(67, 16);
            this.mCount.Name = "mCount";
            this.mCount.Size = new System.Drawing.Size(59, 31);
            this.mCount.TabIndex = 1;
            this.mCount.Text = "666";
            // 
            // pic
            // 
            this.pic.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic.Image = global::Null_Sector.Properties.Resources.metal;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Margin = new System.Windows.Forms.Padding(0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(64, 64);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // Electronics
            // 
            this.Electronics.Controls.Add(this.eCount);
            this.Electronics.Controls.Add(this.pictureBox2);
            this.Electronics.Location = new System.Drawing.Point(129, 0);
            this.Electronics.Margin = new System.Windows.Forms.Padding(0);
            this.Electronics.Name = "Electronics";
            this.Electronics.Size = new System.Drawing.Size(129, 64);
            this.Electronics.TabIndex = 1;
            // 
            // eCount
            // 
            this.eCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.eCount.AutoSize = true;
            this.eCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eCount.Location = new System.Drawing.Point(67, 16);
            this.eCount.Name = "eCount";
            this.eCount.Size = new System.Drawing.Size(59, 31);
            this.eCount.TabIndex = 1;
            this.eCount.Text = "666";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::Null_Sector.Properties.Resources.electronic;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Food
            // 
            this.Food.Controls.Add(this.fCount);
            this.Food.Controls.Add(this.pictureBox3);
            this.Food.Location = new System.Drawing.Point(258, 0);
            this.Food.Margin = new System.Windows.Forms.Padding(0);
            this.Food.Name = "Food";
            this.Food.Size = new System.Drawing.Size(129, 64);
            this.Food.TabIndex = 2;
            // 
            // fCount
            // 
            this.fCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fCount.AutoSize = true;
            this.fCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fCount.Location = new System.Drawing.Point(67, 16);
            this.fCount.Name = "fCount";
            this.fCount.Size = new System.Drawing.Size(59, 31);
            this.fCount.TabIndex = 1;
            this.fCount.Text = "666";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = global::Null_Sector.Properties.Resources.food_full;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // Weapon
            // 
            this.Weapon.Controls.Add(this.wValue);
            this.Weapon.Controls.Add(this.pictureBox4);
            this.Weapon.Location = new System.Drawing.Point(387, 0);
            this.Weapon.Margin = new System.Windows.Forms.Padding(0);
            this.Weapon.Name = "Weapon";
            this.Weapon.Size = new System.Drawing.Size(129, 64);
            this.Weapon.TabIndex = 3;
            // 
            // wValue
            // 
            this.wValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.wValue.AutoSize = true;
            this.wValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wValue.Location = new System.Drawing.Point(67, 16);
            this.wValue.Name = "wValue";
            this.wValue.Size = new System.Drawing.Size(59, 31);
            this.wValue.TabIndex = 1;
            this.wValue.Text = "666";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.Image = global::Null_Sector.Properties.Resources.weapon;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 64);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // Charisma
            // 
            this.Charisma.Controls.Add(this.cValue);
            this.Charisma.Controls.Add(this.pictureBox5);
            this.Charisma.Location = new System.Drawing.Point(516, 0);
            this.Charisma.Margin = new System.Windows.Forms.Padding(0);
            this.Charisma.Name = "Charisma";
            this.Charisma.Size = new System.Drawing.Size(129, 64);
            this.Charisma.TabIndex = 4;
            // 
            // cValue
            // 
            this.cValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cValue.AutoSize = true;
            this.cValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cValue.Location = new System.Drawing.Point(67, 16);
            this.cValue.Name = "cValue";
            this.cValue.Size = new System.Drawing.Size(59, 31);
            this.cValue.TabIndex = 1;
            this.cValue.Text = "666";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox5.Image = global::Null_Sector.Properties.Resources.charisma;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 64);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // Engineering
            // 
            this.Engineering.Controls.Add(this.eValue);
            this.Engineering.Controls.Add(this.pictureBox6);
            this.Engineering.Location = new System.Drawing.Point(645, 0);
            this.Engineering.Margin = new System.Windows.Forms.Padding(0);
            this.Engineering.Name = "Engineering";
            this.Engineering.Size = new System.Drawing.Size(129, 64);
            this.Engineering.TabIndex = 5;
            // 
            // eValue
            // 
            this.eValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.eValue.AutoSize = true;
            this.eValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eValue.Location = new System.Drawing.Point(67, 16);
            this.eValue.Name = "eValue";
            this.eValue.Size = new System.Drawing.Size(59, 31);
            this.eValue.TabIndex = 1;
            this.eValue.Text = "666";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox6.Image = global::Null_Sector.Properties.Resources.engeeniring;
            this.pictureBox6.Location = new System.Drawing.Point(0, 0);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(64, 64);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            // 
            // Table
            // 
            this.Table.AutoSize = true;
            this.Table.ColumnCount = 3;
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.75F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.375F));
            this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.738516F));
            this.Table.Controls.Add(this.FieldWindow, 0, 0);
            this.Table.Controls.Add(this.Input, 1, 1);
            this.Table.Controls.Add(this.TerminalWindow, 1, 0);
            this.Table.Controls.Add(this.Send, 2, 1);
            this.Table.Controls.Add(this.ResourcePanel, 0, 2);
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 0);
            this.Table.Name = "Table";
            this.Table.RowCount = 3;
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.16666F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.666667F));
            this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.Table.Size = new System.Drawing.Size(800, 600);
            this.Table.TabIndex = 5;
            // 
            // FieldWindow
            // 
            this.FieldWindow.AutoSize = true;
            this.FieldWindow.BackColor = System.Drawing.Color.Black;
            this.FieldWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldWindow.Location = new System.Drawing.Point(3, 3);
            this.FieldWindow.Name = "FieldWindow";
            this.Table.SetRowSpan(this.FieldWindow, 2);
            this.FieldWindow.Size = new System.Drawing.Size(512, 513);
            this.FieldWindow.TabIndex = 0;
            this.FieldWindow.TabStop = true;
            this.FieldWindow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.KeyPressed);
            // 
            // ResourcePanel
            // 
            this.Table.SetColumnSpan(this.ResourcePanel, 3);
            this.ResourcePanel.Controls.Add(this.Metal);
            this.ResourcePanel.Controls.Add(this.Electronics);
            this.ResourcePanel.Controls.Add(this.Food);
            this.ResourcePanel.Controls.Add(this.Weapon);
            this.ResourcePanel.Controls.Add(this.Charisma);
            this.ResourcePanel.Controls.Add(this.Engineering);
            this.ResourcePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResourcePanel.Location = new System.Drawing.Point(3, 522);
            this.ResourcePanel.Name = "ResourcePanel";
            this.ResourcePanel.Size = new System.Drawing.Size(794, 75);
            this.ResourcePanel.TabIndex = 6;
            // 
            // Game
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Table);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "NULL-SECTOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseGame);
            this.Load += new System.EventHandler(this.Game_Load);
            this.SizeChanged += new System.EventHandler(this.Field_SizeChanged);
            this.Metal.ResumeLayout(false);
            this.Metal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.Electronics.ResumeLayout(false);
            this.Electronics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Food.ResumeLayout(false);
            this.Food.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.Weapon.ResumeLayout(false);
            this.Weapon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.Charisma.ResumeLayout(false);
            this.Charisma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.Engineering.ResumeLayout(false);
            this.Engineering.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.Table.ResumeLayout(false);
            this.Table.PerformLayout();
            this.ResourcePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox TerminalWindow;
        private TextBox Input;
        private Button Send;
        private Panel Metal;
        private PictureBox pic;
        private Label mCount;
        private Panel Electronics;
        private Label eCount;
        private PictureBox pictureBox2;
        private Panel Food;
        private Label fCount;
        private PictureBox pictureBox3;
        private Panel Weapon;
        private Label wValue;
        private PictureBox pictureBox4;
        private Panel Charisma;
        private Label cValue;
        private PictureBox pictureBox5;
        private Panel Engineering;
        private Label eValue;
        private PictureBox pictureBox6;
        private SelectablePanel FieldWindow;
        private TableLayoutPanel Table;
        private FlowLayoutPanel ResourcePanel;
    }
}