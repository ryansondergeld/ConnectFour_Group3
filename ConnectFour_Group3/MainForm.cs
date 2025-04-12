namespace ConnectFour_Group3
{
    public partial class MainForm : Form
    {
        // Create a list of Forms
        private List<Form> _forms = new List<Form>();
        
        public MainForm()
        {
            InitializeComponent();
            
            // Create all forms use in project
            var g1P = new Game1P();
            var g2P = new Game2P();
            var statistics = new Statistics();
            
            // Add all forms to the list, including this one
            _forms.Add(this);
            _forms.Add(g1P);
            _forms.Add(g2P);
            _forms.Add(statistics);
            
            // Update all Positions
            UpdateFormPositions();
        }

        private void UpdateFormPositions()
        {
            foreach (var f in _forms)
            {
                // Make the same size, location, and start position
                f.StartPosition = FormStartPosition.Manual;
                f.Location = Location;
                f.Size = Size;
            }
        }

        private void ShowForm(int i)
        {
            // Hide main menu
            Hide();
            
            // Show the form
            _forms[i].ShowDialog();
            
            // After the form is closed, update the location
            Location = _forms[i].Location;
            Size = _forms[i].Size;
            
            // Show the main menu again
            Show();
        }

        private void Game1PButton_Click(object sender, EventArgs e)
        {
            ShowForm(1);
        }

        private void Game2PButton_Click(object sender, EventArgs e)
        {
            ShowForm(2);
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            ShowForm(3);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            UpdateFormPositions();
        }
    }
}
