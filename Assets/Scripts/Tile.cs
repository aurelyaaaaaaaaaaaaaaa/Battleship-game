using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private MeshRenderer render;
    Color tempcolour;
    private bool occupied = false;
    private bool shot = false;
    private bool friendly = false;
    public int x;
    public int y;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }

    public bool Friendly() { return friendly; }

    public bool Shot() { return shot; }

    public bool Occupied() { return occupied; }

    public void Hightlight(Color colour)
    {
        render.material.color = colour;
    }
}
