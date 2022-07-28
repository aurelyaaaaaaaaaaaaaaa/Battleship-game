using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Camera mainCam;
    public GameObject tile;
    Tile tileScript;
    public int size;
    public Transform thf;
    public List<List<GameObject>> board;
    void Start()
    {
        CreateBoard(size);
    }

    void CreateBoard(int size)
    {
        for (int y = 0; y < size; y++)
        {
            List<GameObject> newList = new List<GameObject>();
            board.Add(newList);
            for (int x = 0; x < size; x++)
            {
                GameObject tilee = Instantiate(tile, new Vector3(2*x-(size-1), 2, 2*y-(size-1)), Quaternion.identity, thf);
                newList.Add(tilee);
                tilee.GetComponent<Tile>().x = x; tilee.GetComponent<Tile>().y = y;
            }
        }
    }
    void Update()
    {
       FireProjectile();
    }
    void FireProjectile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Tile")
                {
                    tileScript = gameObject.GetComponent<Tile>();
                    
                    if (!tileScript.returnState())
                    {
                        FireProjectile();
                    }
                }
            }
        }
    }
}