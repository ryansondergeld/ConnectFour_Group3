using System.Diagnostics;

namespace ConnectFour_Group3;

public partial class Game1P : Form
{
    private Gfx _gfx;
    private Board _board;
    private int _turn;
    
    public Game1P()
    {
        InitializeComponent();
        
        // Create graphics here
        _gfx = new Gfx(this);
        _board = new Board();
        _turn = 1;
        
        // Create Events
        CreateMouseEvents();
        
        // Call this to update the graphics
        _gfx.Update(_board);

    }
    //-------------------------------------------------------------------------
    private void Reset()
    {
        // Generate a new board
        _board = new Board();

        // Upatte the graphics
        _gfx.Update(_board);
        
        // Set turn back to 1st player
        _turn = 1;
    }
    //-------------------------------------------------------------------------
    private void ChangeTurn()
    {
        if (_turn == 1) { _turn = 2; }
        else { _turn = 1; }
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
    private void Game1P_Load(object sender, EventArgs e)
    {
        Reset();
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
    public void ColumnClick(object sender, EventArgs e)
    {
        // Get the PictureBox
        var p = sender as PictureBox;
        
        // Guard Clause = exit if null
        if (p == null) { return;}
        
        // Get the column location
        var c = (p.Location.X - 16) / 48;
        
        // Get the row available to put a piece in
        var r = _board.GetRowAvailable(c);

        // Guard clause = if the column is full, do nothing on click or hover
        if (r == -1) { return;}
        
        // Otherwise, let's put something in that spot
        _board.SetCell(c, r, _turn);
        
        // And update the board
        _gfx.Update(_board);
        
        // Check if our move caused a win
        bool win = _board.CheckWin(c, r);
        Console.WriteLine(win);
        
        // If there is no win, change the turn
        ChangeTurn();

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