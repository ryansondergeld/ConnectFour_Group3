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

            ///////////////////////////////////////////////////
            /// DEBUG STUFF
            ///////////////////////////////////////////////////
            Cell[,] debug_cells = {
                { new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(1) },
                { new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(1),new Cell(0) },
                { new Cell(1),new Cell(0),new Cell(0),new Cell(0),new Cell(1),new Cell(0),new Cell(0) },
                { new Cell(1),new Cell(0),new Cell(0),new Cell(1),new Cell(0),new Cell(0),new Cell(0) },
                { new Cell(1),new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(0) },
                { new Cell(1),new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(0),new Cell(0) }
            };
            Board debug_board = new Board(debug_cells);

            debug_board.debug__print();

            System.Diagnostics.Debug.WriteLine(debug_board.checkWin(4,0,1)); // Ycolumn Xrow
            ///////////////////////////////////////////////////







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
        public int getCellState() 
        { 
            return cell_state; 
        }

        //Setter Functions
        public void setCellState(int new_cell_state) 
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
        public Cell[,] getCells() 
        { 
            return cell_matrix; 
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

        public void setCell(Cell new_cell,int row, int column) { 

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

        /// ///////////////////////////////////////
        // Game Logic
        /// ///////////////////////////////////////


        ////////////////////////////////////////
        /*  Sean Kearney:
                Added the checkWin function.
                Works by taking in the coordinate of where the newest piece
                was put in along with the team number, and checks in four different
                directions if this caused a win or not.

                The directions were able to be cut down from 8 to 4 because of 
                up never being possible and the other directions being reverses of
                eachother.

                It currently scans:
                Down-Up
                Left-Right
                Diagonal Left Downward-Diagonal Right Upward
                Diagonal Right Downward-Diagonal Left Upward

                If a direction is ended early, it will jump backwards however many spaces 
                it has left and continue forward.  Allowing Up, Right, and two diagonals to
                be redundant.

                I don't have to time to re-check everything, so last minute code
                cleanups I just commeneted out incase they're needed for any edge cases.

        */
        ////////////////////////////////////////



        // after someone makes a move, game will check if that move has made a win.
        public bool checkWin(int column, int row, int team)  // team 0 = empty, team 1 = player 1, team 2 = player 2
        {
            int row_offset = 0;          // offset for row which is the X axis
            int column_offset = 0;       // offset for column which is the Y axis
            int player_points = 0;       // counter for points in a line
            bool restarted_line = false; // this is used for checking a line when starting in the middle. EX: player wins by dropping a piece in between two others in a line.
            bool line_restarted_this_iteration = false;


            // tabbed in ones shouldn't be needed due to the code jumping backwards to check behind the line.
            // tabbed in ones were scrapped (^%^)



            //the first offset checker for row and column is most likely useless.




            // 0 = down                     Works
            // 1 = left                     Works
            // *2
            // 2 = diagonal left downward   Works
            // 3 = diagonal right downard   Works

                    // *2 = right                    Works
                    // *5 = diagonal left upward     Works
                    // *6 = diagonal right upward    Works
            //

            //this checks in the four direction above.
            for (int i = 0; i < 4; i++) // i < 7 (^%^)
            {
                //reset values
                row_offset = 0;
                column_offset = 0;
                restarted_line = false;

                //System.Diagnostics.Debug.WriteLine("\ni = "+i+"\n");

                //iterates 4 times per direction to see if it can find a valid line.
                for (int q = 0; q < 4; q++) 
                {
                    //resets this variable every single time because it is used as a checker to bypass parts of the function
                    // when the code hits a dead end but can still go back and check the other direction.
                    line_restarted_this_iteration = false;


                    ///////////////////////////////////////////////////////////////
                    // checks the coords for valid point.
                    ///////////////////////////////////////////////////////////////
                    System.Diagnostics.Debug.WriteLine("q == "+q);
                    System.Diagnostics.Debug.WriteLine("CELL (" + (column + column_offset) + "," + (row + row_offset) + ") == " + cell_matrix[column, row].getCellState() + ", points == " + player_points);



                    // checks if the current cell is a valid option in the line.
                    if (cell_matrix[column + column_offset, row + row_offset].getCellState() == team)
                    {

                        player_points++;
                        if (player_points >= 4)
                        {
                            System.Diagnostics.Debug.WriteLine("PLAYER HAS WON!!!!");
                            return true;
                        }
                    }

                    // if the option is not valid and a skip has been made for this direction,
                    // it will move on to the next direction
                    else if (restarted_line == true) 
                    {
                        System.Diagnostics.Debug.WriteLine("CELL == " + cell_matrix[column + column_offset, row + row_offset].getCellState() + ", while team == " + team);
                        player_points = 0;
                        q = 4; // skips to the next phase
                    }
                    // if the option is not valid and a skip hasn't been made yet for this direction,
                    // it will activate code below to jump back and check the other direction of the line.
                    else
                    {
                        line_restarted_this_iteration = true;
                    }

                    ///////////////////////////////////////////////////////////////







                    ///////////////////////////////////////////////////////////////
                    // updates column offset
                    ///////////////////////////////////////////////////////////////

                    if (i != 1) // not directions left or right      //  && i != 2 (^%^)
                    {

                        //if (i == 0 || i == 2 || i == 3) // down, left diagonal down, right diagonal down     // 3 is now 2, 4 is now 3 (^%^) 
                        //{
                        //    column_offset++;
                        //}
                        //else //left diagonal up, right diagonal up
                        //{
                        //    column_offset--;
                        //}


                        column_offset++;


                        //System.Diagnostics.Debug.WriteLine("(i = " + i + ")i == 0 || i == 3 || i == 4");





                        // if the column is out of bounds, either jump back and check the other direction,
                        // or move on to the next direction.

                       
                        if (column + column_offset < 0 || column + column_offset > 5) //6-1 because indexes starts at 0
                        {
                            // commented out code is useless
                            //System.Diagnostics.Debug.WriteLine("column + offset is out of bounds!!!");
                            //if (line_restarted_this_iteration && restarted_line) {
                            //    player_points = 0;
                            //    q = 4; // skips to the next phase
                            //}
                            //else
                            //{
                                line_restarted_this_iteration = true;
                            //}
                        }

                    }

                    ///////////////////////////////////////////////////////////////
                    // updates row offset
                    ///////////////////////////////////////////////////////////////
                    
                    if (i != 0) // left, right
                    {

                        if (i == 1 || i == 2) // left // 3 is now 2, 5 is now 4,  || i == 4 (^%^)
                        {
                            row_offset--;
                        }
                        else // right
                        {
                            row_offset++;
                        }
                        if (row + row_offset < 0 || row + row_offset > 6)  //7-1 because indexes starts at 0
                        {
                            // commented out code is useless
                            //if (line_restarted_this_iteration && restarted_line) {
                            //    System.Diagnostics.Debug.WriteLine("row + offset is out of bounds!!!");
                            //    player_points = 0;
                            //    q = 4; // skips to the next phase
                            //}
                            //else
                            //{
                                line_restarted_this_iteration = true;
                            //}
                        }
                    }




                    // goes backwards onthe line to see if there is any more valid points in that direction.
                    if (line_restarted_this_iteration)
                    {
                        System.Diagnostics.Debug.WriteLine("RESTARTED LINE!!!");
                        restarted_line = true;
                        line_restarted_this_iteration = false;



                        //column validation

                        //the 5 in (5-player_points) is not 4 to account for 0.

                        if ((i == 0 || i == 2 || i == 3) && column - (4 - player_points) >= 0) // column validation for 0,3,4 // 3 is now 2, 4 is now 3 (^%^)
                        {
                            q--;
                            column_offset = -1 * (4 - player_points); 
                            System.Diagnostics.Debug.WriteLine("column_offset == " + column_offset);
                        }
                        // no longer used.
                        //else if ((i == 4 || i == 5) && column + (4 - player_points) < 6) // column validation for 5,6 // 5 is now 4, 6 is now 5 (^%^)
                        //{
                        //    q--;
                        //    column_offset = (4 - player_points);
                        //    System.Diagnostics.Debug.WriteLine("column_offset == " + column_offset);
                        //}





                        // row validation


                        if ((i == 3) && row - (4 - player_points) < 6) // row validation for 5,6 // i == 2 ||  4 is now 3, 6 is now 5,  || i == 5 (^%^)
                        {
                            q--;
                            row_offset = -1 * (4 - player_points); // added extra to account for +1 later down
                            System.Diagnostics.Debug.WriteLine("row_offset == " + row_offset);
                        }

                        else if ((i == 1 || i == 2) && row + (4 - player_points) >= 0) // row validation for 1,3,5 //  3 is now 2, 5 is now 4,  || i == 4 (^%^)
                        {
                            q--;
                            row_offset = (4 - player_points);
                            System.Diagnostics.Debug.WriteLine("row_offset == " + row_offset);
                        }
                        if (row + row_offset < 0 || row + row_offset > 6 || column + column_offset < 0 || column + column_offset > 5)
                        {
                            player_points = 0;
                            q = 4; // skips to the next phase
                        }
                    }
                }
            }
            return false;
        }






        public void playerTurn(bool isPlayer1, bool isBotGame)
        {


        }

        // checks to see if th4e player can make a move in that column, (column might be full)
        public bool validInput()
        {

            return false;
        }








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




}