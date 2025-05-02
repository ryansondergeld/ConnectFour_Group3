//   ___                ___ ___ 
//  / __|__ _ _ __  ___|_  ) _ \
// | (_ / _` | '  \/ -_)/ /|  _/
//  \___\__,_|_|_|_\___/___|_|  
//       
//-----------------------------------------------------------------------------
// Group 3 
// CIS 153
// Sean Kearney
// Ryan Sondergeld
// David Sparks
//-----------------------------------------------------------------------------
namespace ConnectFour_Group3;

public partial class Game2P : Form
{
    // Private vairables
    private Gfx _gfx;
    private Board _board;
    private int _turn;
    private bool _playing;
    
    public Game2P()
    {
        InitializeComponent();
        
        // Initialize Private variables
        _gfx = new Gfx(this);
        _board = new Board();
        _turn = 1;
        _playing = true;
        
        // Create the Mouse events
        CreateMouseEvents();
    }
    //-------------------------------------------------------------------------
    // Functions
    //-------------------------------------------------------------------------
    private void ChangeTurn()
    {
        // Change to other player's turn
        if (_turn == 1) { _turn = 2; }
        else { _turn = 1; }
    }
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
    private void CreateMouseEvents()
    {
        for (var i = 0; i < 42; i++)
        {
            // Set the Column Click and Hover events for each PictureBox
            PictureBox p = _gfx.GetCell(i);
            p.MouseClick += ColumnClick;
            p.MouseEnter += ColumnEnter;  //mouse enter is much more responsive. mouve hover takes a second.
            p.MouseLeave += ColumnLeave;
        }
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
        if (g.GetAction() == "quit") { Close(); }
        //else { Close(); }
    }
    //-------------------------------------------------------------------------
    // Event Handlers
    //-------------------------------------------------------------------------
    private void BackButton_Click(object sender, EventArgs e)
    {
        Close();
    }
    //-------------------------------------------------------------------------
    private void ColumnClick(object sender, EventArgs e)
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

        System.Diagnostics.Debug.WriteLine("c == " + c + ", r == " + r);

        // Guard clause = if the column is full, do nothing on click or hover
        if (r == -1) { return; }
        
        // Otherwise, let's put something in that spot
        _board.SetCell(c, r, _turn);
        
        // And update the board
        _gfx.Update(_board);
        
        // Check if our move caused a win
        if (_board.CheckWin(c, r, -1, false))
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
    private void ColumnEnter(object sender, EventArgs e)
    {
        if (!_playing) { return; }
        // Get the PictureBox
        var p = sender as PictureBox;
        
        // Guard Clause = exit if null
        if (p == null) { return;}
        
        // Get the column location
        var c = (p.Location.X - 16) / 48;

        _gfx.Update(_board);
        _gfx.UpdateCell((p.Location.X - 16) / 48, 0,_turn);
        // Console output for debugging
        //System.Diagnostics.Debug.WriteLine("HOVER " + c);
    }
    //-------------------------------------------------------------------------
    private void ColumnLeave(object sender, EventArgs e)
    {
        _gfx.Update(_board);
    }
    //-------------------------------------------------------------------------
    private void ExitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    //-------------------------------------------------------------------------
    private void ResetButton_Click(object sender, EventArgs e)
    {
        Reset();
    }
    //-------------------------------------------------------------------------
    private void Game2P_Load(object sender, EventArgs e)
    {
        Reset();
    }
    //-------------------------------------------------------------------------


    //--------------------------
    //  Statistics File
    //
    //  Player wins
    //  Ai Wins
    //  Ties
    //  Total Games
    //--------------------------
    public string[] ReadStatsFile()
    {
        return File.ReadAllLines("../../../Statistics.txt");
    }
    //-------------------------------------------------------------------------
    public void WriteStatsFile(string[] new_lines)
    {
        File.WriteAllText("../../../Statistics.txt", "");
        File.WriteAllLines("../../../Statistics.txt", new_lines);
    }
    //-------------------------------------------------------------------------
}