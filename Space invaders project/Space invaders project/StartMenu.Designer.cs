
namespace Space_invaders_project
{
    partial class StartMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.startGame = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.storyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.startGame.Location = new System.Drawing.Point(231, 95);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(281, 93);
            this.startGame.TabIndex = 0;
            this.startGame.Text = "Игра";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.exit.Location = new System.Drawing.Point(231, 375);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(281, 93);
            this.exit.TabIndex = 1;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // storyButton
            // 
            this.storyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.storyButton.Location = new System.Drawing.Point(231, 225);
            this.storyButton.Name = "storyButton";
            this.storyButton.Size = new System.Drawing.Size(281, 110);
            this.storyButton.TabIndex = 2;
            this.storyButton.Text = "История";
            this.storyButton.UseVisualStyleBackColor = true;
            this.storyButton.Click += new System.EventHandler(this.storyButton_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.storyButton);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.startGame);
            this.Name = "StartMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button storyButton;
    }
}

