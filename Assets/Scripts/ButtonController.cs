using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Manager manager;
    bool P1Turn;
    public PlayerController pc;
    public GameObject button1;
    public GameObject button2;

    private void Update() // make sure that correct player is selected
    {
        P1Turn = manager.p1Turn;
    }
    public void ResetShips() // reset ships if the button is pressed
    {
        if (P1Turn) manager.SetUpShips(0);
        else manager.SetUpShips(1);
    }

    public void NextMode() // give the turn to the next player to set up
    {
        if (P1Turn && manager.shipsPlaced == 5 && pc.setup) 
        {
            manager.SwitchState();
            manager.MoveCam(new Vector3(17, 17, 0));
            manager.SetUpShips(1);
            button1.transform.position = new Vector3(1275, 200, 0);
            button2.transform.position = new Vector3(1275, 75, 0);
        }
        else if (!P1Turn && manager.shipsPlaced == 5 && pc.setup)
        {
            pc.FinishSetup();
            manager.SwitchState();
            manager.MoveCam(new Vector3(1.79f, 18, 0));
            Destroy(button1);
            Destroy(button2);
        }
    }
}
