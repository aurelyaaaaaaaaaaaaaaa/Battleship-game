using UnityEngine;

public class tester : MonoBehaviour
{  
    private int count = 0;
    public GameObject o;
       Player p = new Player();
    void Start()
    {
        foreach(int i in p.board)
        {
            Instantiate(o, new Vector3(25 + 25*count, 25 + 25*count, 0));
            count+=1;
        }
    }
}

public class Player
{
    public int shots;
    public int[,] board = new int [10,10];
}