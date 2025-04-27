using System.Collections;

namespace ConnectFour_Group3;

class GameEvents
{
    private Form _form;
    private string _type;

    GameEvents(string type, Form form)
    {
        // Set the type
        _type = type;

        // Based on the type, class the form
        if (type == "1P")
        {
            _form = form as Game1P;
        }
        else if (_type == "2P")
        {
            _form = form as Game2P;
        }
        else
        {
            _form = form;
        }
    }
    public static void ColumnClick(object sender, EventArgs e)
    {
        // Get the PictureBox
        var p = sender as PictureBox;
        
        // Guard Clause = exit if null
        if (p == null) { return;}
        
        // Get the column location
        var c = (p.Location.X - 16) / 48;
        
        // Console output for debugging
        Console.WriteLine("Column clicked : " + c.ToString());
    }

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
}