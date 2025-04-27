namespace ConnectFour_Group3;

class Cell
{
    private int _value; //0 Empty, 1 Player1, 2 Player2
        
    public Cell()
    {
        _value = 0;
    }

    public Cell(int value) { _value = value; }
        
    //Getter Functions
    public int getCellState() { return _value; }

    //Setter Functions
    public void setCellState(int value) { _value = value; }
}