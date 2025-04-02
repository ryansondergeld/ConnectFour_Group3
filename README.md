# Connect Four Group Project
Group 3

## Summary
You are required to write a connect four program as part of a group.  This program will have at least 4 different forms (possibly more).  The first form is the welcome form that will display 4 different actions, single player, two player, statistics and exit.  Single player will open a new form that allows the user to play against the computer.  At a minimum you need to create a rules based AI.  Do not overthink this!  A rules based AI can perform the following rules: if I can take a win take a win, if I can block you from winning block you, otherwise follow some basic strategy.  Two player will open a new form that allows the player to play against another person.  Statistics will allow the player to see their record against the AI.  Exit will exit the program.  Please note that I want an exit button on each form that closes the entire program not just a single form.  This can be accomplished by using the form exit button in the top right if you would like.  You can make sure this is happening by running your program in visual studio.  If you click the exit button but it is still running you will see the red stop button in visual studio.  When the game board is up we should see a label at the bottom telling the user who’s turn it is as well as an exit button (if you choose).  We should also see the connect four grid and any moves that have been made.  If the user hovers their mouse over the column they want to play it will display what the move will look like, the move will not take place until the user clicks in that column.  Once a move is made we should check for a winner.  If there is a winner or a draw I want you to display a new form.  This form will say who won, show the players statistics against the computer, have an action to play again, have an action to review the game, and have an action to exit.  Play again will close the current form stating who has won and open a new game board form.  Review the game will allow them to see who won and how they won.

## Additional functionality
### A rules based AI
- Make an AI that the user can play against.
- The AI must have 3 rules.  If you want to research different algorithms for your AI to follow, that is perfectly fine but it is not required. (Minimax algorithm would be the easiest to implement.  However the sample size for this algorithm is too large so you would have to optimize). Please do not just copy someone else’s AI algorithm for this.
- Having your AI randomly pick an open cell to play will result in no credit for the AI portion of the points.
### Player Statistics
- The winner form will show the players statistics against the computer.  The welcome form will have an action that will allow the user to see statistics on a new form.
- The statistics should show how many times the player has won, how many times the AI has won, and how many times it was a tie.  It should also show the total number of times the game has been played and win percentages for both the AI and the player.
- This needs to be persistent data.  Therefore, when the game is closed and ran again the player can see their stats from all previous runs.  This can be accomplished by using a simple text file.  You do not have to make this work for multiple players. 
### Classes
- You must include a cell class and a board class.  You must have private members and public functions.  The functionality and design of these classes is determined by you.  However, I will be grading you on you implementation.

## Connect Four board
- 7 columns
- 6 rows

![image](https://github.com/user-attachments/assets/22591938-32bc-4fe6-9581-d7562995fe94)

### Checking Rows for blocks or wins
- All possible row combinations will be 4 sliding windows on each row:

![image](https://github.com/user-attachments/assets/7efe3685-d09c-4819-a76b-b5052ee16363)

### Checking Columns for blocks or wins
- All possible column combinations will be 3 sliding windows on each column:

![image](https://github.com/user-attachments/assets/0cb043f4-7a16-4455-9daf-3839704fe8ce)

### Checking Diagonals
- Diagonals can be checked from the 4 tiles on the left and right - either 3 rows from the top down OR 3 rows from the botom up:

![image](https://github.com/user-attachments/assets/b0a71bec-aa86-4b5f-83fd-83698b848d58)
![image](https://github.com/user-attachments/assets/18f2e153-99da-439c-ad31-c0bea4da3d29)
![image](https://github.com/user-attachments/assets/ecf28e5a-fca1-44aa-8eb5-c6e6d0cee874)


## To Do:
- [x] Create Github
- [ ] Add All users to Github
- [ ] Test that all users are able to pull / push changes
- [ ] Divide responsibilities


## Point Breakdown
- [ ] Main Menu Options (10)
- [ ] Exit completely closes the application (10)
- [ ] Winning conditions (20)
- [ ] Game over form options (10)
- [ ] Hovering functionality (10)
- [ ] Restart Game functionality (10)
- [ ] All forms load at same position (10)
- [ ] Only one form open at a time (10)
- [ ] Review game functionality (20)
- [ ] AI functionality 20)
- [ ] Player statistics (20)
- [ ] Cell class (15)
- [ ] Board class (15)
- [ ] Creative GUI (10)
- [ ] User experience (10)
