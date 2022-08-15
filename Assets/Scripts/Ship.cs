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
        render = GetComponent<MeshRenderer>();
        transform.localScale = new Vector3((size + (size-1)*0.5f), 1, 1);
    }

    public int returnSize()
    {
        return size;
    }

    public void placeOrReset() //Switches ship to placed when put down or resets it to not placed if changing placement.
    {
        placed = !placed;
    }

    public void Highlight(Color colour)
    {
        render.material.color = colour;
    }
}