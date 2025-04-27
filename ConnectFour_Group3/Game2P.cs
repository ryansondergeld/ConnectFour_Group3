namespace ConnectFour_Group3;

public partial class Game2P : Form
{
    public Game2P()
    {
        InitializeComponent();
    }
    //-------------------------------------------------------------------------
    private void BackButton_Click(object sender, EventArgs e)
    {
        Close();
    }
    //-------------------------------------------------------------------------
    private void ExitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    //-------------------------------------------------------------------------
}