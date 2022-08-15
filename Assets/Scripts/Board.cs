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
    public int size;
    void Start()
    {
        CreateBoard();
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
    }

    public void SpawnShips()
    {
        
    }

    void FireProjectile()
    {

    }

    public void Switch()
    {

    }

    void ResetSquares()
    {

    }

    void PlaceShip()
    {

    }

    public void HighlightSquare(int x, int y, Color colour)
    {
        BoardArray[x-1][y-1].GetComponent<Tile>().Hightlit(colour);
    }

    public void DeHighlightAll()
    {
        foreach(List<GameObject> x in BoardArray)
        {
            foreach(GameObject y in x)
            {
                if(!y.GetComponent<Tile>().Occupied() && !y.GetComponent<Tile>().Shot())
                {
                    y.GetComponent<Tile>().Hightlit(Color.white);
                }
            }
        }
    }
}