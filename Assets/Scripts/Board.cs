using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Camera mainCam;
    public GameObject tile;
    public List<List<GameObject>> BoardArray = new List<List<GameObject>>();
    public bool hidden = true;
    public Transform b;
    public List<GameObject> ships;
    List<GameObject> currentShips = new List<GameObject>();
    public int size;
    public int liveShips;
    public bool isP1 = false;
    public GameObject pc;
    void Start() //creates board when instantiated
    {
        CreateBoard();
    }
    void CreateBoard() //creates all the tiles of the board
    {
        for (int x = 1; x <= size; x++)
        {
            BoardArray.Add(new List<GameObject>());
            for (int y = 1; y <= size; y++)
            {
                GameObject i = Instantiate(tile,(new Vector3((-15 + x * 1.5f), 0, (-15 + y * 1.5f)) + transform.position),Quaternion.identity,b);
                i.GetComponent<Tile>().y = y;
                i.GetComponent<Tile>().x = x;
                BoardArray[x-1].Add(i);
            }
        }
        GameObject.Find("GameManager").GetComponent<Manager>().P1Go();
    }

    public void SpawnShips(bool setup) // spawns all the ships
    {
        if (currentShips != null)
        {
            foreach (GameObject ship in currentShips)
            {
                Destroy(ship);
            }
        }

        foreach (List<GameObject> list in BoardArray)
        {
            foreach (GameObject tile in list)
            {
                tile.GetComponent<Tile>().occupied = false;
            }
        }

        DeHighlightAll(setup);
        for (int i=0; i < ships.Count; i++)
        {
            if (isP1)currentShips.Add(Instantiate(ships[i], new Vector3(-20, 0, 6 - 2 * i), Quaternion.identity));
            else currentShips.Add(Instantiate(ships[i], new Vector3(25, 0, 6 - 2 * i), Quaternion.identity));
            liveShips = 17;
        }
    }

    public void Fire(int x, int y) // shoots when called by playercontroller
    {
        if (BoardArray[x-1][y-1].GetComponent<Tile>().Targeted())
        {
            liveShips -= 1;
        }
    }

    public void Switch(bool setup) // switches turn when called by playercontroller
    {
        if(!setup)
        {
            if(currentShips != null) {ToggleShips();}
            DeHighlightAll(setup);
        }
        foreach (List<GameObject> x in BoardArray)
        {
            foreach (GameObject y in x)
            {
                y.GetComponent<Tile>().Switch();
            }
        }  
    }

    public void ToggleShips() // destroys ship assets after setup
    {
        foreach(GameObject y in currentShips)
        {
            Destroy(y);
        }
    }

    public void PlaceShip(int x, int y, int size, bool horizontal) // changes state of tiles with ships placed on them
    {
        for(int i = 0; i<size; i++)
        {
            if(horizontal)
            {
                BoardArray[x-1+i][y-1].GetComponent<Tile>().Place();
            }
            else
            {
                BoardArray[x-1][y-1+i].GetComponent<Tile>().Place();
            }
        }
    }

    public void HighlightSquare(int x, int y, Color colour) // highlights squares
    {
        BoardArray[x-1][y-1].GetComponent<Tile>().Highlight(colour);
    }

    public void DeHighlightAll(bool setup) // unhilights all squares
    {
        foreach(List<GameObject> x in BoardArray)
        {
            foreach(GameObject y in x)
            {
                if(!y.GetComponent<Tile>().Friendly()||setup)
                {
                    y.GetComponent<Tile>().Highlight(Color.white);
                }
            }
        }
    }
}