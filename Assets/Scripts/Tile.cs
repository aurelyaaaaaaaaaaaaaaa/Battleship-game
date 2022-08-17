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
    void Start() //Get the renderer component to change colours
    {
        render = GetComponent<MeshRenderer>();
    }

    public bool Targeted() //Changes colour when shot
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
    //booleans that can be accessed from outside the function
    public bool Friendly() { return friendly; }

    public bool Shot() { return shot; }

    public bool Occupied() { return occupied; }
    //changes the colour of the tiles
    public void Highlight(Color colour) 
    { 
        if (!shot) render.material.color = colour; 
    }

    public void Place() {occupied = !occupied;} //swaps the state of the tile when a ship is placed on it

    public void Switch() {friendly = !friendly; ReHighlight();} //swaps the state of a tile when the turn changes

    void ReHighlight() //changes colour of your tiles with ships on them to green
    {
        if (Occupied() && !shot)
        {
            render.material.color = Color.green;
        }
    }
}
