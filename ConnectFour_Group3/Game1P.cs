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
using System;

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
        if(_turn == 1) { 
            g.SetText("Player 1 Wins!");

        }
        else { 
            g.SetText("Computer Wins!");
        }
        
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
            p.MouseEnter += ColumnEnter;  //mouse enter is much more responsive. mouve hover takes a second.
            p.MouseLeave += ColumnLeave;
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
        bool did_ai_win = false;
        bool did_player_win = false;
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

        did_player_win = _board.CheckWin(c, r, -1, false);
        // logic for Ai's turn
        if (did_player_win == false)
        {
            did_ai_win = AiTurn();
        }
        

        // And update the board
        _gfx.Update(_board);

        // Check if our move caused a win
        
        if (did_player_win || did_ai_win)
        {
            if (did_ai_win && did_player_win == false)
            {
                _turn = 2;
            }
            // Game over Condition here
            _playing = false;

            CreateGameOverScreen();
            
        }
        else
        {
            //ChangeTurn();
        }


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























    public bool AiTurn()
    {
        int possible_win_row = _board.AiTurn(2);
        int possible_block_row = _board.AiTurn(1);
        int strat_row = _board.AiStrat();



        if (possible_win_row != -1) // can I win?
        {
            System.Diagnostics.Debug.WriteLine("I can win!!!");
            _board.SetCell(possible_win_row, _board.GetRowAvailable(possible_win_row), 2);
            return _board.CheckWin(possible_win_row, _board.GetRowAvailable(possible_win_row), -1, false);
        }
        else if (possible_block_row != -1)  // can I stop player win?
        {
            System.Diagnostics.Debug.WriteLine("I can block!!!");
            _board.SetCell(possible_block_row, _board.GetRowAvailable(possible_block_row), 2);
            return _board.CheckWin(possible_block_row, _board.GetRowAvailable(possible_block_row), -1, false);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Strat!!!   ");
            _board.SetCell(strat_row, _board.GetRowAvailable(strat_row), 2);
            return _board.CheckWin(strat_row, _board.GetRowAvailable(strat_row), -1, false);
        }
    }

    public void ColumnEnter(object sender, EventArgs e)
    {
        if (!_playing) { return; }
        // Get the PictureBox
        var p = sender as PictureBox;

        // Guard Clause = exit if null
        if (p == null) { return; }

        // Get the column location
        var c = (p.Location.X - 16) / 48;

        _gfx.Update(_board);
        _gfx.UpdateCell((p.Location.X - 16) / 48, 0, 1);
        // Console output for debugging
        //System.Diagnostics.Debug.WriteLine("HOVER " + c);

    }

    public void ColumnLeave(object sender, EventArgs e)
    {
        _gfx.Update(_board);
    }
    //-------------------------------------------------------------------------
    private void ResetButton_Click(object sender, EventArgs e)
    {
        Reset();
    }
    //-------------------------------------------------------------------------
}