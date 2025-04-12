namespace ConnectFour_Group3;

public partial class Statistics : Form
{
    public Statistics()
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