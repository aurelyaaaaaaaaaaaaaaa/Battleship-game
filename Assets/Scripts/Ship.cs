using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int size;
    public bool placed = false;
    MeshRenderer render;
    Color tempcolour;

    private void Start() 
    {
        render = GetComponent<MeshRenderer>(); // gets renderer to change colour
        transform.localScale = new Vector3((size + (size-1)*0.5f), 1, 1); // changes the size of the ship to fit with how long of a space it takes up
    }

    public void Highlight(Color colour) // changes the colour of the ship
    {
        render.material.color = colour;
    }
}