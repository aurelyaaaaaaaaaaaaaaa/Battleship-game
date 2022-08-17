using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Manager manager;
    bool P1Turn;
    public PlayerController pc;
    public GameObject button1;
    public GameObject button2;

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
        if (P1Turn && manager.shipsPlaced == 5 && pc.setup) 
        {
            manager.SwitchState();
            StartCoroutine(manager.MoveCam(new Vector3(18, 17, 0)));
            manager.SetUpShips(1);
            button1.transform.position = new Vector3(1725, 250, 0);
            button2.transform.position = new Vector3(1725, 100, 0);
        }
        else if (!P1Turn && manager.shipsPlaced == 5 && pc.setup)
        {
            pc.FinishSetup();
            manager.SwitchState();
            StartCoroutine(manager.MoveCam(new Vector3(1.79f, 17, 0)));
            Destroy(button1);
            Destroy(button2);
        }
    }
}
