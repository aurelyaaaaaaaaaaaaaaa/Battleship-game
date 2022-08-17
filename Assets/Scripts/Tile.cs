using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private MeshRenderer render;
    Color tempcolour;
    public bool occupied = false;
    private bool shot = false;
    public bool friendly = false;
    public int x;
    public int y;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    public bool Targeted()
    {
        if (occupied)
        {
            Highlight(Color.magenta);
            shot = true;
            return true;
        }
        else
        {
            Highlight(Color.red);
            shot = true;
            return false;
        }
    }

    public bool Friendly() { return friendly; }

    public bool Shot() { return shot; }

    public bool Occupied() { return occupied; }

    public void Highlight(Color colour) 
    { 
        if (!shot) render.material.color = colour; 
    }

    public void Place() {occupied = !occupied;}

    public void Switch() {friendly = !friendly;ReHighlight();}

    void ReHighlight()
    {
        if (Occupied()&&!shot)
        {
            render.material.color = Color.green;
        }
    }
}
