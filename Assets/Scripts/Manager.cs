using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject board;
    private List<GameObject> boards = new List<GameObject>();
    bool p1Turn = true;

    //Everything goes through the manager first for all player input.
    //The board objects don't need to know if the game is in setup or firing mode.
    //This is because when the player clicks it first goes to this class that does know and this will act accordingly.
    //E.g. Player class clicks Tile > Tile returns coordinates > Player gives it to Manager class > Manager gives appropriate instruction to Board class based on above variables.

    //Will add functions for this as we go.

    private void Start() //At scene creation the boards are set.
    {
        InstantiateBoards();
    }

    void InstantiateBoards() //Instantiate 2 boards side by side.
    {
        GameObject board1 = Instantiate(board, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        boards.Add(board1);
        board1.GetComponent<Board>().hidden = false;

        GameObject board2 = Instantiate(board, new Vector3(0, 0, 50), Quaternion.identity) as GameObject;
        boards.Add(board2);
    }

    void SetUpShips(int p) //Spawn ships for set up on board.
    {
        boards[p].GetComponent<Board>().BeginSetup();
    }

    void SwitchState() //Switches boards from visible to none visible depending on who's turn it is.
    {
        foreach (GameObject x in boards)
        {
            x.GetComponent<Board>().Switch();
        }
    }

    void CheckSpace(int x, int y, int size, bool horizontal) //Checks if ship can be placed at position.
    {

    }

    public void HighlightAtPosition(int x, int y, Color color) //Calls board to highlight tiles at coordinates. Highlight multiple squares when holding a ship to place.
    {

    }

    void PlaceShip(int x, int y, int size, bool horizontal) //Calls board to place ship at coordinates.
    {

    }

    void Shoot(int x, int y) //Fire at board position. Check is done in Player class so no need to do it here.
    {

    }

    void CheckWin() //Asks the board to return the number of 'alive' tiles. If its zero then that side loses. Move to win scene.
    {

    }

    void SwitchTurn() //Switches current player to invisible. 3 second pause. Switch other player to visible.
    {

    }
}
