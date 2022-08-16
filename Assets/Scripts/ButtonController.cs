using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Manager manager;
    bool P1Turn;

    private void Update()
    {
        P1Turn = manager.p1Turn;
    }
    public void ResetShips()
    {
        if (P1Turn) manager.SetUpShips(0);
        else manager.SetUpShips(1);
    }

    public void NextMode()
    {
        if (P1Turn && manager.shipsPlaced == 5) 
        {
            manager.p1Turn = false;
            manager.SwitchState();
            StartCoroutine(manager.MoveCam(new Vector3((float)18.2, 17, 0)));
            manager.SetUpShips(1);
        }
    }
}
