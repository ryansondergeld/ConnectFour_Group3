using System.ComponentModel;

namespace ConnectFour_Group3;

partial class GameOver
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
        GameOverLabel = new System.Windows.Forms.Label();
        WinnerLabel = new System.Windows.Forms.Label();
        PlayAgainButton = new System.Windows.Forms.Button();
        ExitButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // GameOverLabel
        // 
        GameOverLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        GameOverLabel.Location = new System.Drawing.Point(12, 9);
        GameOverLabel.Name = "GameOverLabel";
        GameOverLabel.Size = new System.Drawing.Size(360, 62);
        GameOverLabel.TabIndex = 0;
        GameOverLabel.Text = "Game Over!";
        GameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // WinnerLabel
        // 
        WinnerLabel.Location = new System.Drawing.Point(12, 71);
        WinnerLabel.Name = "WinnerLabel";
        WinnerLabel.Size = new System.Drawing.Size(360, 23);
        WinnerLabel.TabIndex = 1;
        WinnerLabel.Text = "Player 1 Wins!";
        WinnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // PlayAgainButton
        // 
        PlayAgainButton.Location = new System.Drawing.Point(12, 135);
        PlayAgainButton.Name = "PlayAgainButton";
        PlayAgainButton.Size = new System.Drawing.Size(128, 64);
        PlayAgainButton.TabIndex = 2;
        PlayAgainButton.Text = "Play Again";
        PlayAgainButton.UseVisualStyleBackColor = true;
        PlayAgainButton.Click += PlayAgainButton_Click;
        // 
        // ExitButton
        // 
        ExitButton.Location = new System.Drawing.Point(244, 135);
        ExitButton.Name = "ExitButton";
        ExitButton.Size = new System.Drawing.Size(128, 64);
        ExitButton.TabIndex = 3;
        ExitButton.Text = "Back to Main Menu";
        ExitButton.UseVisualStyleBackColor = true;
        ExitButton.Click += ExitButton_Click;
        // 
        // GameOver
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(384, 211);
        Controls.Add(ExitButton);
        Controls.Add(PlayAgainButton);
        Controls.Add(WinnerLabel);
        Controls.Add(GameOverLabel);
        Text = "GameOver";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button PlayAgainButton;
    private System.Windows.Forms.Button ExitButton;

    private System.Windows.Forms.Label WinnerLabel;

    private System.Windows.Forms.Label GameOverLabel;

    #endregion
}