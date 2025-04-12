namespace ConnectFour_Group3;

public partial class Game1P : Form
{
    public Game1P()
    {
        InitializeComponent();
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}