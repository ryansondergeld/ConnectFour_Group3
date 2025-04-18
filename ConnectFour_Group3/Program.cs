namespace ConnectFour_Group3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }


    /////////////////
    /// Sean Kearney:
    /// 
    ///     Added everything I could think of for right now on what the Cell and Board Class would need.
    ///  I also added a get row and get column functions to the board class. I don't know if we'll need them
    ///   but just in case.
    /// 
    ///     All connect four boards I saw online were 7x6 so that's what I made the board fit.
    /// 
    ///////////////////////


    class Cell
    {
        private int cell_state = 0; //0 Empty, 1 Player1, 2 Player2


        public Cell()
        {
            cell_state = 0;
        }

        public Cell(int init_cell_state)
        {
            cell_state = init_cell_state;
        }


        //Getter Functions
        int getCellState() 
        { 
            return cell_state; 
        }

        //Setter Functions
        void setCellState(int new_cell_state) 
        { 
            cell_state = new_cell_state; 
        }

    }


    class Board 
    {
        //connect four grid is 7 wide and 6 tall.
        private Cell[,] cell_matrix = new Cell[7,6];

        public Board()
        {
            Cell[,] cell_matrix = new Cell[7, 6];
        }

        public Board(Cell[,] init_cells)
        {
            cell_matrix = init_cells;
        }

        //Getter Functions
        Cell[,] getCells() 
        { 
            return cell_matrix; 
        }

        Cell[] getRow(int row)  // Might be used for AI or win validation, thought to add just in case.
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

        Cell[] getColumn(int column)  // Might be used for AI or win validation, thought to add just in case.
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

        void setBoard(Cell[,] new_cell_matrix) 
        { 
            cell_matrix = new_cell_matrix; 
        }

        void setCell(Cell new_cell,int row, int column) { 

            if (row < 0 || row > 6)
            {
                row = 0;
            }

            if (column < 0 || column > 6)
            {
                column = 0;
            }

            cell_matrix[row, column] = new_cell;

        }
    }

}