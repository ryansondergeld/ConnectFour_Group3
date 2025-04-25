namespace ConnectFour_Group3;

public partial class Game1P : Form
{
    public Game1P()
    {
        InitializeComponent();

        // Picture box items

        // The picture box items can become transparent by setting the BackColor property to transparent and
        // Setting the parent as the Board.  
        // 
        // When the Board is set as the parent, the location is relative to the upper-left corner.
        // The first cell is at 16, 16
        //
        // From there, add 48 to get to the other cells:
        // 16, 64, 112, 160, 208, 256, 304

        // Example 1 - top left corner
        P1PictureBox01.BackColor = Color.Transparent;
        P1PictureBox01.Parent = BoardPictureBox;
        P1PictureBox01.Location = new Point(16, 16);

        // Example 2 - diagonal down
        P1PictureBox02.BackColor = Color.Transparent;
        P1PictureBox02.Parent = BoardPictureBox;
        P1PictureBox02.Location = new Point(64, 64);

        // Example 3 - bottom right corner
        P2PictureBox01.BackColor = Color.Transparent;
        P2PictureBox01.Parent = BoardPictureBox;
        P2PictureBox01.Location = new Point(304, 256);

        // Example 4 - diagonal up
        P2PictureBox02.BackColor = Color.Transparent;
        P2PictureBox02.Parent = BoardPictureBox;
        P2PictureBox02.Location = new Point(256, 208);
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Game1P_Load(object sender, EventArgs e)
    {

    }
}