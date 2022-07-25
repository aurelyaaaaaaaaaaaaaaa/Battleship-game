using UnityEngine;

public class main : MonoBehaviour
{  
    public GameObject o;
    public Player p1 = new Player();
    public Player p2 = new Player();
    public Transform c;
    private int shipsplaced = 0;
    private bool horizontal = false;
    void Start()
    {
        for(int j = 0; j<10; j++)
        {
            for(int i = 0; i<10; i++)
            {
                Instantiate(o, new Vector3(719 + 52*i,- 52*j + 799, 0), Quaternion.identity, c);
                o.GetComponent<clicker>().x = i; o.GetComponent<clicker>().y = j;
            }
        }
    }
    public void place(int x, int y, Player player)
    {
        while (shipsplaced <= 4)
        {
            if (horizontal)
            {
                switch (shipsplaced)
                {
                    case 0:
                    
                    break;
                    case 1:
                    break;
                    case 2:
                    break;
                    case 3:
                    break;
                    case 4:
                    break;
                }
            }
        }
    }
    public void shot(int x, int y)
    {
        if (p1.board[x,y] == 0){Debug.Log("miss");p1.board[x,y]=2;}
        else if (p1.board[x,y] == 1){Debug.Log("hit");p1.board[x,y]=3;}
        else {Debug.Log("already shot there");}
    }
}

public class Player
{
    public int shots;
    public int[,] board = new int [10,10];
}