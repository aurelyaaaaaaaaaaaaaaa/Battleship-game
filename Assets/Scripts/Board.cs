using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Camera mainCam;
    public GameObject tile;
    Tile tileScript;
    public List<List<GameObject>> BoardArray = new List<List<GameObject>>();
    public bool hidden = true;
    public Transform b;
    public List<GameObject> ships;
    public int size;
    public bool isP1;
    void Start()
    {
        CreateBoard();
        SpawnShips();
    }
    void CreateBoard()
    {
        for (int x = 1; x <= size; x++)
        {
            BoardArray.Add(new List<GameObject>());
            for (int y = 1; y <= size; y++)
            {
                GameObject i = GameObject.Instantiate(tile,(new Vector3((-15 + x * 1.5f), 0, (-15 + y * 1.5f)) + transform.position),Quaternion.identity,b);
                i.GetComponent<Tile>().y = y;
                i.GetComponent<Tile>().x = x;
                BoardArray[x-1].Add(i);
            }
        }
        GameObject.Find("GameManager").GetComponent<Manager>().P1Go();
    }

    public void SpawnShips()
    {
        for(int i=0; i<ships.Count; i++)
        {
            GameObject.Instantiate(ships[i], new Vector3(-20,0.5f,10-i), Quaternion.identity);
        }
    }

    void FireProjectile()
    {

    }

    public void Switch()
    {
        foreach (List<GameObject> x in BoardArray)
        {
            foreach (GameObject y in x)
            {
                y.GetComponent<Tile>().Switch();
            }
        }
    }

    void ResetSquares()
    {

    }

    public void PlaceShip(int x, int y, int size, bool horizontal)
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

    public void HighlightSquare(int x, int y, Color colour)
    {
        BoardArray[x-1][y-1].GetComponent<Tile>().Hightlight(colour);
    }

    public void DeHighlightAll()
    {
        foreach(List<GameObject> x in BoardArray)
        {
            foreach(GameObject y in x)
            {
                if(!y.GetComponent<Tile>().Occupied() && !y.GetComponent<Tile>().Shot())
                {
                    y.GetComponent<Tile>().Hightlight(Color.white);
                }
            }
        }
    }
}