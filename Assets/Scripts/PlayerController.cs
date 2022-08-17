using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCam;
    bool shipSelected;
    bool horizontal = true;
    int shipSize;
    public bool setup;
    GameObject currentHeldShip;
    public Manager manager;

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
            else if (hitInfo.collider.gameObject.GetComponent<Ship>() != null && Input.GetMouseButtonDown(0)) //Checks if clicking ship
            {
                PickShip(hitInfo.collider.gameObject);
            }
            else //Unhilights all tiles
            {
                manager.DeHighlight(setup);
            }            
        }
        //change to button script

        if (Input.GetButtonDown("rotateship") && shipSelected)
        {
            horizontal = !horizontal;
            manager.DeHighlight(setup);
        }
    }

    void HoverTile(int x, int y, GameObject tile) //Checks what tiles to highlight and color
    {
        if (!tile.GetComponent<Tile>().Friendly() && !tile.GetComponent<Tile>().Shot() && !setup)
        {
            manager.HighlightAtPosition(x, y, Color.red, setup);
        }

        if (tile.GetComponent<Tile>().Friendly() && !tile.GetComponent<Tile>().Occupied() && setup && shipSelected)
        {
            if (horizontal)
            {
                if (x + shipSize-2 >= 10) //Highlight red if ship placement is out of bounds.
                {
                    for (int i = x; i <= 10; i++)
                    {
                        manager.HighlightAtPosition(i, y, Color.red, setup);
                    }
                }
                else
                {
                    for (int i = x; i < x + shipSize; i++) //Highlight tiles that already have ships red, else green
                    {
                        manager.HighlightAtPosition(i, y, Color.green, setup);
                    }
                }
            }

            else
            {
                if (y + shipSize-2 >= 10)
                {
                    for (int i = y; i <= 10; i++)
                    {
                        manager.HighlightAtPosition(x, i, Color.red,setup);
                    }
                }
                else
                {
                    for (int i = y; i < y + shipSize; i++)
                    {
                        if (!tile.GetComponent<Tile>().Occupied())
                        {
                            manager.HighlightAtPosition(x, i, Color.green,setup);
                        }
                        else
                        {
                            manager.HighlightAtPosition(x, i, Color.red,setup);
                        }
                    }
                }
            }
        }
    }

    void PickShip(GameObject ship)
    {
        if (!ship.GetComponent<Ship>().placed)
        {
            if (currentHeldShip != null) //Unhighlight current ship if a new one is selected.
            {
                currentHeldShip.GetComponent<Ship>().Highlight(Color.white);
            }
            currentHeldShip = ship;
            shipSize = ship.GetComponent<Ship>().size;
            currentHeldShip.GetComponent<Ship>().Highlight(Color.green);
            shipSelected = true;
        }
    }

    void ClickOptions(int x, int y, GameObject tile) //Does something on click based on stuff
    {
        if (!tile.GetComponent<Tile>().Friendly() && !tile.GetComponent<Tile>().Shot() && !setup)
        {
            manager.Shoot(x, y);
        }
        if (tile.GetComponent<Tile>().Friendly() && setup && shipSelected)
        {
            if (CanPlace(x, y))
            {
                manager.PlaceShip(x, y, shipSize, horizontal, currentHeldShip);
                currentHeldShip.GetComponent<Ship>().placed = true;
                shipSelected = false;
                currentHeldShip = null;
            }
        }
    }

    bool CanPlace(int x, int y) //Check if requested placement is valid.
    {
        if (!currentHeldShip.GetComponent<Ship>().placed)
        {
            if (horizontal && x + shipSize - 2 >= 10)
            {
                return false;
            }
            else if (!horizontal && y + shipSize - 2 >= 10)
            {
                return false;
            }
            else
            {
                for (int i = 1; i<shipSize; i++)
                {
                    if (horizontal)
                    {
                        if (manager.p1Turn)
                        {
                            if(manager.boards[0].GetComponent<Board>().BoardArray[x+i-1][y-1].GetComponent<Tile>().Occupied())
                            {
                                return false;
                            } 
                        }
                        else
                        {
                            if(manager.boards[1].GetComponent<Board>().BoardArray[x+i-1][y-1].GetComponent<Tile>().Occupied())
                            {
                                return false;
                            } 
                        }
                    }
                    else
                    {
                        if (manager.p1Turn)
                        {
                            if(manager.boards[0].GetComponent<Board>().BoardArray[x-1][y+i-1].GetComponent<Tile>().Occupied())
                            {
                                return false;
                            } 
                        }
                        else
                        {
                            if(manager.boards[1].GetComponent<Board>().BoardArray[x-1][y+i-1].GetComponent<Tile>().Occupied())
                            {
                                return false;
                            } 
                        }
                    }
                }
                return true;
            }
        }
        else return false;
    }

    public void FinishSetup()
    {
        setup = false;
        manager.boards[0].GetComponent<Board>().ToggleShips();
    }
}