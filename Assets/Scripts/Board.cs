using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Camera mainCam;
    public GameObject tile;
    Tile tileScript;
    public Transform thf;
    public List<List<GameObject>> board;
    public bool hidden = true;
    public int size;
    void Start()
    {
        CreateBoard();
    }
    void Update()
    {

    }

    void CreateBoard()
    {
        for (int x = 1; x <= size; x++)
        {
            List<GameObject> column = new List<GameObject>();
            board.Add(column);
            for (int y = 1; y <= size; y++)
            {
                // need to make this vector
                Vector3 v = new Vector3();
                GameObject i = GameObject.Instantiate(tile,v,Quaternion.identity);
                i.GetComponent<Tile>().y = y;
                i.GetComponent<Tile>().x = x;
                column.Add(i);
            }
        }
    }

    public void BeginSetup()
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
}