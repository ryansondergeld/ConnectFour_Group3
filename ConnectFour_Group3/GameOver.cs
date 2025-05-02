namespace ConnectFour_Group3;

public partial class GameOver : Form
{
    private string _text;
    private string _action;
    
    public GameOver()
    {
        InitializeComponent();
        _text = "nobody wins";
        _action = "";
    }
    //-------------------------------------------------------------------------
    // Functions
    //-------------------------------------------------------------------------
    public void SetText(string text)
    {
        _text = text;
        UpdateLabels();
    }
    //-------------------------------------------------------------------------
    private void UpdateLabels()
    {
        WinnerLabel.Text = _text;
    }
    //-------------------------------------------------------------------------
    public string GetAction()
    {
        return _action;
    }
    //-------------------------------------------------------------------------
    // Event Handlers
    //-------------------------------------------------------------------------
    private void PlayAgainButton_Click(object sender, EventArgs e)
    {
        // Play Again
        _action = "play";
        Close();
    }
    //-------------------------------------------------------------------------
    private void ExitButton_Click(object sender, EventArgs e)
    {
        // Quit to Main Menu
        _action = "quit";
        Close();
    }
    //-------------------------------------------------------------------------
}