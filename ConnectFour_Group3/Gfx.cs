using System.Collections;

namespace ConnectFour_Group3;

class Gfx
{
    private PictureBox _board;
    private List<PictureBox> _cells;
    private int _origin = 16;
    private Form _form;

    public Gfx(Form f)
    {
        // Set the form
        _form = f;
        
        // Create the board and place it
        _board = new PictureBox();
        _board.Parent = _form;
        _board.Image = Properties.Resources.Board;
        _board.Location = new Point(8, 8);
        _board.Size = new Size(365, 309);
        _board.Refresh();

        // Create the cells and place them
        _cells = new List<PictureBox>();

        // Create each cell picture
        for (var i = 0; i < 42; i++)
        {
            // Determine the row and column
            var r = _origin + (i / 7) * 48;
            var c = _origin + (i % 7) * 48;

            // Create a new PictureBox at that row / column
            var p = new PictureBox();
            p.BackColor = Color.Transparent;
            p.Parent = _board;
            p.Size = new Size(35, 35);
            p.Location = new Point(c, r);
            p.Image = Properties.Resources.BlankPiece;
            p.Refresh();

            // Add the new PictureBox to the list
            _cells.Add(p);
        }
    }

    public PictureBox GetBoard()
    {
        return _board;
    }

    public PictureBox GetCell(int i)
    {
        return _cells[i];
    }
    
    private void UpdateCell(int column, int row, int value)
    {
        // Update formula for list of cells
        var i = row * 7 + column;
        var c = _cells[i];

        switch (value)
        {
            case 1:
                c.Image = Properties.Resources.Player1Piece;
                break;
            case 2:
                c.Image = Properties.Resources.Player2Piece;
                break;
            default:
                c.Image = Properties.Resources.BlankPiece;
                break;
        }

        c.Refresh();
    }

    private void UpdateCell(int number, int value)
    {
        var c = _cells[number];
        
        switch (value)
        {
            case 1:
                c.Image = Properties.Resources.Player1Piece;
                break;
            case 2:
                c.Image = Properties.Resources.Player2Piece;
                break;
            default:
                c.Image = Properties.Resources.BlankPiece;
                break;
        }
        
        c.Refresh();
    }

    public void Update(Board board)
    {
        // I need to be able to iterate through each cell here
        Cell[,] cells = board.getCells();
        
        // Iterate through each cell and update graphics
        for (int c = 0; c < 7; c++)
        {
            for (int r = 0; r < 6; r++)
            {
                UpdateCell(c, r, cells[c, r].getCellState());
            }
        }
    }
}