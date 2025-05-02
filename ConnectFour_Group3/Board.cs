using System.Data.Common;
using System.Diagnostics.Metrics;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection;

namespace ConnectFour_Group3;

class Board
{
    private const int Rows = 6;
    private const int Columns = 7;

    //connect four grid is 7 wide and 6 tall.
    private Cell[,] cell_matrix = new Cell[Columns, Rows];

    public Board()
    {
        // Create a blank board
        cell_matrix = new Cell[Columns, Rows];
            
        // Here we need to add all cell components so they are not null - assume blank value
        for (int c = 0; c < Columns; c++)
        {
            for (int r = 0; r < Rows; r++)
            {
                cell_matrix[c, r] = new Cell();
            }
        }
    }

    public Board(Cell[,] init_cells)
    {
        cell_matrix = init_cells;
    }

    //Getter Functions
    public Cell[,] getCells() 
    { 
        return cell_matrix; 
    }

    public Cell GetCell(int column, int row)
    {
        return cell_matrix[column, row];
    }

    public Cell[] getRow(int row)  // Might be used for AI or win validation, thought to add just in case.
    {

        int row_size = 6;
        Cell[] cell_row = new Cell[6];

        if (row >= 0 && row < row_size)
        {
            for (int i = 0; i < row_size; i++)
            {
                cell_row[i] = cell_matrix[row,i];
            }

            return cell_row;
        }
        return cell_row;
    }

    public int GetRowAvailable(int column)
    {
        int row = -1;
        // We want to look at the column passed in and get the lowest row
        for (int r = 0; r < 6; r++)
        {
            // Get the Cell
            Cell c = GetCell(column, r);
                
            // If the next cell is empty, set row to that cell
            if (c.getCellState() == 0)
            {
                row = r;
            }
        }

        return row;
    }

    public Cell[] getColumn(int column)  // Might be used for AI or win validation, thought to add just in case.
    {
        int column_size = 7;
        Cell[] cell_column = new Cell[6];

        if (column >= 0 && column < column_size)
        {
            for (int i = 0; i < column_size; i++)
            {
                cell_column[i] = cell_matrix[i, column];
            }

            return cell_column;
        }
        return cell_column;
    }

    //Setter Functions

    public void setBoard(Cell[,] new_cell_matrix) 
    { 
        cell_matrix = new_cell_matrix; 
    }

    public void setCell(Cell new_cell,int row, int column) 
    { 
        if (row < 0 || row > 6) { row = 0; }

        if (column < 0 || column > 6) { column = 0; }

        cell_matrix[row, column] = new_cell;
    }

    public void SetCell(int column, int row, int value)
    {
        cell_matrix[column, row].setCellState(value);
    }

    /// ///////////////////////////////////////
    // Game Logic
    /// ///////////////////////////////////////


    public int AiTurn(int team) // accepts team for checking possible wins and blocks.
    {
        for (int i = 0; i < 7;i++) {  // scans over each column and checks if it can win.
            if (CheckWin(i, GetRowAvailable(i), team, true))
            {
                return i;
            }
        }
        return -1;
    }


    public int AiStrat()
    {
        int cur_highest = 0;
        int highest_index = 0;
        int new_highest = 0;
        int row = 0;
        for (int i = 0; i < 7;i++)
        {
            row = GetRowAvailable(i);
            if (row != -1)
            {
                new_highest = CheckWinHighest(i, row, 2);
            }
            

            if (new_highest > cur_highest)
            {
                cur_highest = new_highest;
                highest_index = i;
            }
        }

        if (highest_index <= 1)
        {
            Random rand = new Random();
            return rand.Next(0, 6);
        }

        return highest_index;
    }



    //---------------------------------------------------------------------
    // Updated function - other goes out of bounds
    public bool CheckWin(int column, int row, int team, bool isAI)
    {
        if (column == -1 || row == -1) { return false; }
        // Check the row, column, forward diagonal, and reverse diagonal
        if (CheckRow(row, isAI, team)) { return true;}
        if (CheckColumn(column, isAI, team)) { return true;}
        if (CheckReverseDiagonal(isAI, team)) { return true; }
        if (CheckForwardDiagonals(isAI, team)) { return true; }
            
        // Return false by default
        return false;
    }
    //---------------------------------------------------------------------
    public bool CheckColumn(int column, bool isAI, int team)
    {
        // There are 3 possible winning points in a column
        for (int i = 0; i < 3; i++)
        {
            var a = GetCell(column, i).getCellState();
            var b = GetCell(column, i + 1).getCellState();
            var c = GetCell(column, i + 2).getCellState();
            var d = GetCell(column, i + 3).getCellState();
            
            if (team != -1) { a = team; }

            // If the cell states are all the same, return true
            if (a == b && 
                a == c &&
                a == d &&
                a != 0 ) { return true; }
        }

        // By default, return false
        return false;
    }
        
    //---------------------------------------------------------------------
    public bool CheckRow(int row, bool isAI, int team)
    {
        // There are 4 possible winning points in a row
        for (int i = 0; i < 4; i++)
        {
            var a = GetCell(i, row).getCellState();
            var b = GetCell(i + 1, row).getCellState();
            var c = GetCell(i + 2, row).getCellState();
            var d = GetCell(i + 3, row).getCellState();

            if (team != -1) { a = team; }

            // If the cell states are all the same, return true
            if (a == b && 
                a == c &&
                a == d &&
                a != 0) { return true; }
        }

        // By Default, return false
        return false;
    }
    //---------------------------------------------------------------------
    public bool CheckReverseDiagonal(bool isAI, int team)
    {
        for (int column = 0; column < 4; column++)
        {
            for (int row = 0; row < 3; row++)
            {
                var a = GetCell(column, row).getCellState();
                var b = GetCell(column + 1, row + 1).getCellState();
                var c = GetCell(column + 2, row + 2).getCellState();
                var d = GetCell(column + 3, row + 3).getCellState();

                if (team != -1) { a = team; }

                // If the cell states are all the same, return true
                if (a == b &&
                    a == c &&
                    a == d &&
                    a != 0) { return true; }
            }
                
        }
            
        // By Default, return false
        return false;
    }
    //---------------------------------------------------------------------
    public bool CheckForwardDiagonals(bool isAI, int team)
    {
        for (int column = 0; column < 3; column++)
        {
            for (int row = 3; row < 6; row++)
            {
                var a = GetCell(column, row).getCellState();
                var b = GetCell(column + 1, row - 1).getCellState();
                var c = GetCell(column + 2, row - 2).getCellState();
                var d = GetCell(column + 3, row - 3).getCellState();

                if (team != -1) { a = team; }
                
                // If the cell states are all the same, return true
                if (a == b &&
                    a == c &&
                    a == d &&
                    a != 0) { return true; }
            }
                
        }
            
        // By Default, return false
        return false;
    }

    //--------------




    public int CheckWinHighest(int column, int row, int team)
    {
        int cur_highest = 0;
        int column_offset = 0;
        int row_offset = 0;
        int points = 0;

        for (int i = 0; i < 4; i++)
        {

            points = 0;
            column_offset = 0;
            row_offset = 0;
            for (int q = 0; q < 4; q++)
            {
                if (cell_matrix[column + column_offset, row + row_offset].getCellState() == team || q == 0) { points++; }
                else if (cell_matrix[column + column_offset, row + row_offset].getCellState() != 0) { q = 4; points = 0; }

                if (i == 0) { column_offset++; }
                else if (i == 1) { row_offset++; }
                else if (i == 2) { column_offset++; row_offset++; }
                else if (i == 3) { column_offset++; row_offset--; }

                if (column + column_offset > 6) { column_offset = -1 * (4 - points); }
                else if (column + column_offset < 0) { column_offset = (4 - points); }

                if (row + row_offset < 0) { row_offset = (4 - points); }
                else if (row + row_offset > 5) { row_offset = -1 * (4 - points); }


                if (points > cur_highest) { cur_highest = points; }

            }
        }
        return cur_highest;
    }













    //---------------------------------------------------------------------
    public void playerTurn(bool isPlayer1, bool isBotGame)
    {
            
    }
    //---------------------------------------------------------------------
    // checks to see if th4e player can make a move in that column, (column might be full)
    public bool validInput()
    {

        return false;
    }
    //---------------------------------------------------------------------
    /////////////////////////////////////////////////////////////////
    /// DEBUG
    /////////////////////////////////////////////////////////////////
    public void debug__print()
    {
        System.Diagnostics.Debug.WriteLine("=================================");
        for (int i = 0; i < 6;i++)
        {
            for (int q = 0; q < 7;q++)
            {
                System.Diagnostics.Debug.Write(cell_matrix[i,q].getCellState()+", ");
            }
            System.Diagnostics.Debug.Write("\n");
        }
        System.Diagnostics.Debug.WriteLine("=================================");
    }

}