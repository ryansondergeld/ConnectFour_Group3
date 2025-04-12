﻿using System.ComponentModel;

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
        BackButton = new System.Windows.Forms.Button();
        ExitButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // BackButton
        // 
        BackButton.Location = new System.Drawing.Point(484, 12);
        BackButton.Name = "BackButton";
        BackButton.Size = new System.Drawing.Size(128, 64);
        BackButton.TabIndex = 0;
        BackButton.Text = "Back to Main";
        BackButton.UseVisualStyleBackColor = true;
        BackButton.Click += BackButton_Click;
        // 
        // ExitButton
        // 
        ExitButton.Location = new System.Drawing.Point(484, 245);
        ExitButton.Name = "ExitButton";
        ExitButton.Size = new System.Drawing.Size(128, 64);
        ExitButton.TabIndex = 1;
        ExitButton.Text = "Exit";
        ExitButton.UseVisualStyleBackColor = true;
        ExitButton.Click += ExitButton_Click;
        // 
        // Game1P
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(624, 321);
        Controls.Add(ExitButton);
        Controls.Add(BackButton);
        Text = "Game1P";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button BackButton;
    private System.Windows.Forms.Button ExitButton;

    #endregion
}