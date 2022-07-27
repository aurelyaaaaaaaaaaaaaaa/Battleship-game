using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Camera mainCam;
    public GameObject tile;
    private List<GameObject> board;
    Tile tileScript;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int x = 0; x < 3; x++)
            {
                Instantiate(tile, new Vector3((2*(x-1)), 2, 2*(-i+1)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
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

    void FireProjectile()
    {

    }
}
