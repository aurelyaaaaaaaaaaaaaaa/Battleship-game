# Battleship Plan

# Game Cycle

## Setup
-Choose size board (5x5, 10x10, 15x15).  

-Two boards of tiles (board has 2D list of tiles).  

-Tiles are instantiated with an (x,y) denoting position in the board, so that when they are clicked they can return position and that can be used when accessing the board class.  

-Start P1 setup.  

-Show P1 board and spawn ships to the side depending on board size.  

-Ships can be clicked and placed on tiles. (Player selects ship, if they click on a tile with a ship selected, call the Board to check if there is space, then place ship and update occupied tiles. Ship asset is then attached tiles.)

-Move already placed ships if needed -> reset occupied Board spaces.

-Confirmation button once all ships are placed.

-Repeat for P2.

## Gameplay

-Hide enemy, show ally (tiles can have visible/invis states?).

-Select tile to shoot.

-Check if it is a valid target -> return error and try again OR confirm shot.

-Play animation depending on result (Miss, Hit, Sunk).
- For sunk animation, we need a way to check if all parts of a ship are destroyed.
- Store tiles that make up a ship in an array -> check if whole array is destroyed.
- OR Ship has a script that can keep track of remaining life. Must be updated when tile is shot, so tiles still need to know what ship is inside of it.

-Update Board with number of live tiles.

-Check if a player has won.

-Repeat.

# Ideas for Classes/Scripts

## Board
-CreateBoard  
- Take size.  
- Instantiate tiles as children in 2D list.  

-Get Tile state (is occupied/has been shot).

-Track/Return remaining ships.

-Fill tiles with ships:
- Orientation and size.
- Check availability of tiles.
- Highlight tiles when attempting to place ship (Red for invalid, Green for valid).
- Remove ships from tiles when the ship is repositioned, don't update number of ships on board  
 (Just keep the number of remaining parts at the max from the start even if the ships haven't been placed yet, as you have to place them all to start anyway.)

-Check if all ships are placed

-Perform shooting:
- Check tile to see if it can be shot.
- Play animation based on result.
- Update board state based on results.
- Confirm successful shot to change turn? Maybe this can be done by GameManager.

## Tile
-Return state (shot/occupied).

-Highlight on mouse over. Overrided when placing ships.

-Return result of shot.

-Return coordinates in board.

-Invis/visible state for ship asset. Also prevent shooting own ships.

## Player
-Place shot.

-Place ship:
- Attach ship to mouse position.
- Get type of selected ship.
- Call board to highlight tiles when attempting to place.
- Rotate ship while selected.

-One class for both players as tiles class prevents shooting own ships so no need to change player, only state of tiles/board.

## Ship
-Highlight on mouse hover.

-Tagged with ship type.

## Game Manager
- Instantiate and Store boards in a size 2 array (P1 Board, P2 Board)
- Check if game is won.
- Call board to change turn after successful shot.