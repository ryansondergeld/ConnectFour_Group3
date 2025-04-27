//   ___                _ ___ 
//  / __|__ _ _ __  ___/ | _ \
// | (_ / _` | '  \/ -_) |  _/
//  \___\__,_|_|_|_\___|_|_|  
//                            
//-----------------------------------------------------------------------------
// Group 3 
// CIS 153
// Sean Kearney
// Ryan Sondergeld
// David Sparks
//-----------------------------------------------------------------------------
namespace ConnectFour_Group3;

public partial class Game1P : Form
{
    private Gfx _gfx;
    private Board _board;
    private int _turn;
    private bool _playing;
    
    public Game1P()
    {
        InitializeComponent();
        
        // Create graphics here
        _gfx = new Gfx(this);
        _board = new Board();
        _turn = 1;
        _playing = true;
        
        // Create Events
        CreateMouseEvents();
    }
    //-------------------------------------------------------------------------
    // Functions
    //-------------------------------------------------------------------------
    private void Reset()
    {
        // Generate a new board, update the graphics, and set the turn
        _board = new Board();
        _gfx.Update(_board);
        _turn = 1;
        _playing = true;
    }
    //-------------------------------------------------------------------------
    private void ChangeTurn()
    {
        if (_turn == 1) { _turn = 2; }
        else { _turn = 1; }
    }
    //-------------------------------------------------------------------------
    private void CreateGameOverScreen()
    {
        // Create game over pop-up
        GameOver g = new GameOver();
            
        // Set the text
        if(_turn == 1) { g.SetText("Player 1 Wins!");}
        else { g.SetText("Player 2 Wins!");}
        
        // Set the location
        g.StartPosition = FormStartPosition.Manual;
        g.Location = Location;

        g.ShowDialog();
        
        // Get the action
        if (g.GetAction() == "play") { Reset(); }
        else { Close(); }
    }
    //-------------------------------------------------------------------------
    private void CreateMouseEvents()
    {
        for (var i = 0; i < 42; i++)
        {
            PictureBox p = _gfx.GetCell(i);
            p.MouseClick += ColumnClick;
            p.MouseHover += ColumnHover;
        }
    }
    //-------------------------------------------------------------------------
    // Event Handlers
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
    private void Game1P_Load(object sender, EventArgs e)
    {
        Reset();
    }
    //-------------------------------------------------------------------------
    public void ColumnClick(object sender, EventArgs e)
    {
        // Guard Clause - Check if we are playing
        if (!_playing) { return; }
        
        // Get the PictureBox
        var p = sender as PictureBox;
        
        // Guard Clause = exit if null
        if (p == null) { return; }
        
        // Get the column location
        var c = (p.Location.X - 16) / 48;
        
        // Get the row available to put a piece in
        var r = _board.GetRowAvailable(c);

        // Guard clause = if the column is full, do nothing on click or hover
        if (r == -1) { return; }
        
        // Otherwise, let's put something in that spot
        _board.SetCell(c, r, _turn);
        
        // And update the board
        _gfx.Update(_board);
        
        // Check if our move caused a win
        if (_board.CheckWin(c, r))
        {
            // Game over Condition here
            _playing = false;

            CreateGameOverScreen();
            
        }
        else
        {
            ChangeTurn();
        }

    }
    //-------------------------------------------------------------------------
    public static void ColumnHover(object sender, EventArgs e)
    {
        // Get the PictureBox
        var p = sender as PictureBox;
        
        // Guard Clause = exit if null
        if (p == null) { return;}
        
        // Get the column location
        var c = (p.Location.X - 16) / 48;
        
        // Console output for debugging
        Console.WriteLine("Column hover!" + c.ToString());
    }
    //-------------------------------------------------------------------------
    private void ResetButton_Click(object sender, EventArgs e)
    {
        Reset();
    }
    //-------------------------------------------------------------------------
}