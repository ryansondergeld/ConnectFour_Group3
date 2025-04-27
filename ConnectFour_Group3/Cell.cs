namespace ConnectFour_Group3;

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