using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject board;
    public List<Board> boards = new List<Board>();
    public bool p1Turn = true;
    public GameObject ScreenHider;
    public Animator animator;
    public Camera mainCam;
    Vector3 finalCamPos = new Vector3((float)1.75, 17, 0);
    bool gogogo=false;
    public int shipsPlaced;
    public PlayerController pc;
    public GameObject nextplayer;
    public GameObject hs;
    public GameObject blocker;

    //Everything goes through the manager first for all player input.
    //The board objects don't need to know if the game is in setup or firing mode.
    //This is because when the player clicks it first goes to this class that does know and this will act accordingly.
    //E.g. Player class clicks Tile > Tile returns coordinates > Player gives it to Manager class > Manager gives appropriate instruction to Board class based on above variables.
    private void Start() //At scene creation the boards are set and the ships are set up
    {
        InstantiateBoards();
        SetUpShips(0);
    }

    public void P1Go() //Makes sure that the correct player is selected
    {
        if(!gogogo)
        {boards[0].Switch(pc.setup);gogogo=true;} 
    }

    void InstantiateBoards() //Instantiate 2 boards side by side.
    {
        GameObject board1 = Instantiate(board, new Vector3(0, 0, 7), Quaternion.identity) as GameObject;
        boards.Add(board1.GetComponent<Board>());
        board1.GetComponent<Board>().isP1 = true;

        GameObject board2 = Instantiate(board, new Vector3(17, 0, 7), Quaternion.identity) as GameObject;
        boards.Add(board2.GetComponent<Board>());
    }

    public void SetUpShips(int p) //Spawn ships for set up on board.
    {
        boards[p].SpawnShips(pc.setup);
        shipsPlaced=0;
    }

    public void SwitchState() //Switches boards from visible to none visible depending on who's turn it is.
    {
        hs.SetActive(true);
        blocker.SetActive(true);
        foreach (Board x in boards)
        {
            x.Switch(pc.setup);
        }
        nextplayer.SetActive(true);
        p1Turn = !p1Turn;
    }

    public void HighlightAtPosition(int x, int y, Color colour, bool setup) //Calls board to highlight tiles at coordinates. Highlight multiple squares when holding a ship to place.
    {
        if (setup)
        {
            if (p1Turn)
            {
                boards[0].HighlightSquare(x,y,colour);
            }
            else
            {
                boards[1].HighlightSquare(x,y,colour);
            }
        }
        else
        {
            if (!p1Turn)
            {
                boards[0].HighlightSquare(x,y,colour);
            }
            else
            {
                boards[1].HighlightSquare(x,y,colour);
            }
        }
    }

    public void DeHighlight(bool setup) //Unhiglights all tiles
    {
        boards[0].DeHighlightAll(setup);
        boards[1].DeHighlightAll(setup);
    }

    public void PlaceShip(int x, int y, int size, bool horizontal, GameObject ship) //Calls board to place ship at coordinates.
    {
        if (p1Turn) 
        {
            boards[0].PlaceShip(x,y,size,horizontal);
            if(horizontal)
            {
                ship.transform.rotation = Quaternion.Euler(0,0,0);
                ship.transform.position = boards[0].BoardArray[x-1][y-1].transform.position + new Vector3((size + (size-3)*0.5f)/2,0.5f,0);
            }
            else
            {
                ship.transform.rotation = Quaternion.Euler(0,90,0);
                ship.transform.position = boards[0].BoardArray[x-1][y-1].transform.position + new Vector3(0,0.5f,(size + (size-3)*0.5f)/2);
            }
        }
        else 
        {
            boards[1].PlaceShip(x,y,size,horizontal);
            if(horizontal)
            {
                ship.transform.rotation = Quaternion.Euler(0,0,0);
                ship.transform.position = boards[1].BoardArray[x-1][y-1].transform.position + new Vector3((size + (size-3)*0.5f)/2,0.5f,0);
            }
            else
            {
                ship.transform.rotation = Quaternion.Euler(0,90,0);
                ship.transform.position = boards[1].BoardArray[x-1][y-1].transform.position + new Vector3(0,0.5f,(size + (size-3)*0.5f)/2);
            }
        }
        shipsPlaced += 1;
    }

    public void Shoot(int x, int y) //Fire at board position. Check is done in Player class so no need to do it here.
    {
        if (p1Turn)
        {
            boards[1].Fire(x, y);
        }
        else
        {
            boards[0].Fire(x, y);
        }
        CheckWin();
        SwitchState();
    }

    void CheckWin() //Asks the board to return the number of 'alive' tiles. If its zero then that side loses. Move to win scene.
    {
        if (boards[0].liveShips == 0)
        {
            SceneManager.LoadScene(3);
        }
        else if (boards[1].liveShips == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void MoveCam(Vector3 destination) // Moves camera
    {
        mainCam.transform.position = destination;
    }

    public void animate() //Transitions between player's turns
    {
        hs.SetActive(false);
        blocker.SetActive(false);
        nextplayer.SetActive(false);
    }
}
