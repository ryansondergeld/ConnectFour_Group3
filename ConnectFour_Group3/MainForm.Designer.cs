namespace ConnectFour_Group3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            Game1PButton = new System.Windows.Forms.Button();
            Game2PButton = new System.Windows.Forms.Button();
            StatisticsButton = new System.Windows.Forms.Button();
            ExitButton = new System.Windows.Forms.Button();
            TitlePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)TitlePictureBox).BeginInit();
            SuspendLayout();
            // 
            // Game1PButton
            // 
            Game1PButton.Location = new System.Drawing.Point(484, 12);
            Game1PButton.Name = "Game1PButton";
            Game1PButton.Size = new System.Drawing.Size(128, 64);
            Game1PButton.TabIndex = 0;
            Game1PButton.Text = "Play vs CPU";
            Game1PButton.UseVisualStyleBackColor = true;
            Game1PButton.Click += Game1PButton_Click;
            // 
            // Game2PButton
            // 
            Game2PButton.Location = new System.Drawing.Point(484, 82);
            Game2PButton.Name = "Game2PButton";
            Game2PButton.Size = new System.Drawing.Size(128, 64);
            Game2PButton.TabIndex = 1;
            Game2PButton.Text = "2 Player Game";
            Game2PButton.UseVisualStyleBackColor = true;
            Game2PButton.Click += Game2PButton_Click;
            // 
            // StatisticsButton
            // 
            StatisticsButton.Location = new System.Drawing.Point(484, 152);
            StatisticsButton.Name = "StatisticsButton";
            StatisticsButton.Size = new System.Drawing.Size(128, 64);
            StatisticsButton.TabIndex = 2;
            StatisticsButton.Text = "Statistics";
            StatisticsButton.UseVisualStyleBackColor = true;
            StatisticsButton.Click += StatisticsButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new System.Drawing.Point(484, 222);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new System.Drawing.Size(128, 64);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // TitlePictureBox
            // 
            TitlePictureBox.Image = global::ConnectFour_Group3.Properties.Resources.Title;
            TitlePictureBox.InitialImage = global::ConnectFour_Group3.Properties.Resources.Title;
            TitlePictureBox.Location = new System.Drawing.Point(140, 49);
            TitlePictureBox.Name = "TitlePictureBox";
            TitlePictureBox.Size = new System.Drawing.Size(200, 195);
            TitlePictureBox.TabIndex = 4;
            TitlePictureBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 321);
            Controls.Add(TitlePictureBox);
            Controls.Add(ExitButton);
            Controls.Add(StatisticsButton);
            Controls.Add(Game2PButton);
            Controls.Add(Game1PButton);
            Text = "Main Menu";
            Move += MainForm_Move;
            ((System.ComponentModel.ISupportInitialize)TitlePictureBox).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox TitlePictureBox;

        private System.Windows.Forms.Button Game1PButton;
        private System.Windows.Forms.Button Game2PButton;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.Button ExitButton;

        #endregion
    }
}
