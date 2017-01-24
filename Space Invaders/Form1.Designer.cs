namespace Space_Invaders
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.highScoreButton = new System.Windows.Forms.Button();
            this.playGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameEngine
            // 
            this.gameEngine.Interval = 16;
            this.gameEngine.Tick += new System.EventHandler(this.gameEngine_Tick);
            // 
            // highScoreButton
            // 
            this.highScoreButton.BackColor = System.Drawing.Color.Black;
            this.highScoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreButton.ForeColor = System.Drawing.Color.White;
            this.highScoreButton.Location = new System.Drawing.Point(279, 519);
            this.highScoreButton.Margin = new System.Windows.Forms.Padding(2);
            this.highScoreButton.Name = "highScoreButton";
            this.highScoreButton.Size = new System.Drawing.Size(203, 37);
            this.highScoreButton.TabIndex = 3;
            this.highScoreButton.Text = "HIGH SCORES";
            this.highScoreButton.UseVisualStyleBackColor = false;
            this.highScoreButton.Click += new System.EventHandler(this.highScoreButton_Click);
            // 
            // playGameButton
            // 
            this.playGameButton.BackColor = System.Drawing.Color.Black;
            this.playGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playGameButton.ForeColor = System.Drawing.Color.White;
            this.playGameButton.Location = new System.Drawing.Point(279, 478);
            this.playGameButton.Margin = new System.Windows.Forms.Padding(2);
            this.playGameButton.Name = "playGameButton";
            this.playGameButton.Size = new System.Drawing.Size(203, 37);
            this.playGameButton.TabIndex = 2;
            this.playGameButton.Text = "PLAY GAME";
            this.playGameButton.UseVisualStyleBackColor = false;
            this.playGameButton.Click += new System.EventHandler(this.playGameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(766, 706);
            this.Controls.Add(this.highScoreButton);
            this.Controls.Add(this.playGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Button highScoreButton;
        private System.Windows.Forms.Button playGameButton;
    }
}

