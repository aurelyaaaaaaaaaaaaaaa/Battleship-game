using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCam;
    bool shipSelected;
    bool horizontal = false;
    int shipSize;
    public bool setup;
    public GameObject manager;
    GameObject currentHeldShip;

    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.gameObject.GetComponent<Tile>() != null) //Checks if hovering tile
            {
                int x = hitInfo.collider.gameObject.GetComponent<Tile>().x;
                int y = hitInfo.collider.gameObject.GetComponent<Tile>().y;

                HoverTile(x, y, hitInfo.collider.gameObject);

                if (Input.GetMouseButtonDown(0))
                {
                    ClickOptions(x, y, hitInfo.collider.gameObject);
                }
            }
            else
            {
                manager.GetComponent<Manager>().DeHighlight();
            }

            if (hitInfo.collider.gameObject.GetComponent<Ship>() != null && Input.GetMouseButtonDown(0)) //Checks if clicking ship
            {
                PickShip(hitInfo.collider.gameObject);
            }
        }
    }

    void HoverTile(int x, int y, GameObject tile) //Checks what tiles to highlight and color
    {
        if (!tile.GetComponent<Tile>().Friendly() && !tile.GetComponent<Tile>().Shot() && !setup)
        {
            manager.GetComponent<Manager>().HighlightAtPosition(x, y, Color.red);
        }

        if (tile.GetComponent<Tile>().Friendly() && !tile.GetComponent<Tile>().Occupied() && setup && shipSelected)
        {
            if (horizontal)
            {
                if (x + shipSize >= 10) //Highlight red if ship placement is out of bounds.
                {
                    for (int i = x; i < 10; i++)
                    {
                        manager.GetComponent<Manager>().HighlightAtPosition(i, y, Color.red);
                    }
                }
                else
                {
                    for (int i = x; i < x + shipSize; i++) //Highlight tiles that already have ships red, else green
                    {
                        if (!tile.GetComponent<Tile>().Occupied())
                        {
                            manager.GetComponent<Manager>().HighlightAtPosition(i, y, Color.green);
                        }
                        else
                        {
                            manager.GetComponent<Manager>().HighlightAtPosition(i, y, Color.red);
                        }
                    }
                }
            }

            else
            {
                if (y + shipSize >= 10)
                {
                    for (int i = y; i < 10; i++)
                    {
                        manager.GetComponent<Manager>().HighlightAtPosition(x, i, Color.red);
                    }
                }
                else
                {
                    for (int i = y; i < y + shipSize; i++)
                    {
                        if (!tile.GetComponent<Tile>().Occupied())
                        {
                            manager.GetComponent<Manager>().HighlightAtPosition(x, i, Color.green);
                        }
                        else
                        {
                            manager.GetComponent<Manager>().HighlightAtPosition(x, i, Color.red);
                        }
                    }
                }
            }
        }
    }

    void PickShip(GameObject ship)
    {
        if (!ship.GetComponent<Ship>().placed && !shipSelected)
        {
            if (currentHeldShip != null) //Unhighlight current ship if a new one is selected.
            {
                currentHeldShip.GetComponent<Ship>().Highlight();
            }
            currentHeldShip = ship;
            shipSize = ship.GetComponent<Ship>().size;
            currentHeldShip.GetComponent<Ship>().Highlight();
        }
    }

    void ClickOptions(int x, int y, GameObject tile) //Does something on click based on stuff
    {
        if (!tile.GetComponent<Tile>().Friendly() && !tile.GetComponent<Tile>().Shot() && !setup)
        {
            manager.GetComponent<Manager>().Shoot(x, y);
        }

        if (tile.GetComponent<Tile>().Friendly() && setup && shipSelected)
        {
            if (CanPlace(x, y))
            {
                manager.GetComponent<Manager>().PlaceShip(x, y, shipSize, horizontal);
            }
        }
    }

    bool CanPlace(int x, int y) //Check if requested placement is valid.
    {
        if (horizontal && x + shipSize >= 10)
        {
            return false;
        }
        else if (!horizontal && y + shipSize >= 10)
        {
            return false;
        }
        else return true;
    }
}