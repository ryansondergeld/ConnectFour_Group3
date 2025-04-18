using System.ComponentModel;

namespace ConnectFour_Group3;

partial class Game2P
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
        BackButton = new Button();
        ExitButton = new Button();
        pictureBox1 = new PictureBox();
        ((ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // BackButton
        // 
        BackButton.Location = new Point(484, 12);
        BackButton.Name = "BackButton";
        BackButton.Size = new Size(128, 64);
        BackButton.TabIndex = 0;
        BackButton.Text = "Back To Main";
        BackButton.UseVisualStyleBackColor = true;
        BackButton.Click += BackButton_Click;
        // 
        // ExitButton
        // 
        ExitButton.Location = new Point(484, 245);
        ExitButton.Name = "ExitButton";
        ExitButton.Size = new Size(128, 64);
        ExitButton.TabIndex = 1;
        ExitButton.Text = "Exit";
        ExitButton.UseVisualStyleBackColor = true;
        ExitButton.Click += ExitButton_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = Properties.Resources.Board;
        pictureBox1.Location = new Point(8, 8);
        pictureBox1.Margin = new Padding(2);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(365, 309);
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // Game2P
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(624, 321);
        Controls.Add(pictureBox1);
        Controls.Add(ExitButton);
        Controls.Add(BackButton);
        Name = "Game2P";
        Text = "Game2P";
        ((ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button BackButton;
    private System.Windows.Forms.Button ExitButton;

    #endregion

    private PictureBox pictureBox1;
}