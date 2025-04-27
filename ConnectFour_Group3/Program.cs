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
    
}