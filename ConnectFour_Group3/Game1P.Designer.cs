using System.ComponentModel;

namespace ConnectFour_Group3;

partial class Game1P
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
        BoardPictureBox = new PictureBox();
        P1PictureBox01 = new PictureBox();
        P1PictureBox02 = new PictureBox();
        P2PictureBox01 = new PictureBox();
        P2PictureBox02 = new PictureBox();
        ((ISupportInitialize)BoardPictureBox).BeginInit();
        ((ISupportInitialize)P1PictureBox01).BeginInit();
        ((ISupportInitialize)P1PictureBox02).BeginInit();
        ((ISupportInitialize)P2PictureBox01).BeginInit();
        ((ISupportInitialize)P2PictureBox02).BeginInit();
        SuspendLayout();
        // 
        // BackButton
        // 
        BackButton.Location = new Point(484, 12);
        BackButton.Name = "BackButton";
        BackButton.Size = new Size(128, 64);
        BackButton.TabIndex = 0;
        BackButton.Text = "Back to Main";
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
        // BoardPictureBox
        // 
        BoardPictureBox.Image = Properties.Resources.Board;
        BoardPictureBox.Location = new Point(8, 8);
        BoardPictureBox.Margin = new Padding(2);
        BoardPictureBox.Name = "BoardPictureBox";
        BoardPictureBox.Size = new Size(365, 309);
        BoardPictureBox.TabIndex = 2;
        BoardPictureBox.TabStop = false;
        // 
        // P1PictureBox01
        // 
        P1PictureBox01.Image = Properties.Resources.Player1Piece;
        P1PictureBox01.Location = new Point(24, 24);
        P1PictureBox01.Name = "P1PictureBox01";
        P1PictureBox01.Size = new Size(35, 35);
        P1PictureBox01.TabIndex = 3;
        P1PictureBox01.TabStop = false;
        // 
        // P1PictureBox02
        // 
        P1PictureBox02.Image = Properties.Resources.Player1Piece;
        P1PictureBox02.Location = new Point(72, 72);
        P1PictureBox02.Name = "P1PictureBox02";
        P1PictureBox02.Size = new Size(35, 35);
        P1PictureBox02.TabIndex = 4;
        P1PictureBox02.TabStop = false;
        // 
        // P2PictureBox01
        // 
        P2PictureBox01.Image = Properties.Resources.Player2Piece;
        P2PictureBox01.Location = new Point(312, 264);
        P2PictureBox01.Name = "P2PictureBox01";
        P2PictureBox01.Size = new Size(35, 35);
        P2PictureBox01.TabIndex = 5;
        P2PictureBox01.TabStop = false;
        // 
        // P2PictureBox02
        // 
        P2PictureBox02.Image = Properties.Resources.Player2Piece;
        P2PictureBox02.Location = new Point(264, 216);
        P2PictureBox02.Name = "P2PictureBox02";
        P2PictureBox02.Size = new Size(35, 35);
        P2PictureBox02.TabIndex = 6;
        P2PictureBox02.TabStop = false;
        // 
        // Game1P
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(624, 321);
        Controls.Add(P2PictureBox02);
        Controls.Add(P2PictureBox01);
        Controls.Add(P1PictureBox02);
        Controls.Add(P1PictureBox01);
        Controls.Add(BoardPictureBox);
        Controls.Add(ExitButton);
        Controls.Add(BackButton);
        Name = "Game1P";
        Text = "Game1P";
        Load += Game1P_Load;
        ((ISupportInitialize)BoardPictureBox).EndInit();
        ((ISupportInitialize)P1PictureBox01).EndInit();
        ((ISupportInitialize)P1PictureBox02).EndInit();
        ((ISupportInitialize)P2PictureBox01).EndInit();
        ((ISupportInitialize)P2PictureBox02).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button BackButton;
    private System.Windows.Forms.Button ExitButton;

    #endregion

    private PictureBox BoardPictureBox;
    private PictureBox P1PictureBox01;
    private PictureBox P1PictureBox02;
    private PictureBox P2PictureBox01;
    private PictureBox P2PictureBox02;
}