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

    void Update()
    {
        
    }

    public bool Targeted()
    {
        shot = true;
        if (occupied)
        {
            Highlight(Color.magenta);
            return true;
        }
        else
        {
            Highlight(Color.red);
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

    public void Switch() {friendly = !friendly;}
}
