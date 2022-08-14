using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int size;
    public bool placed = false;
    MeshRenderer render;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    public int returnSize()
    {
        return size;
    }

    public void placeOrReset() //Switches ship to placed when put down or resets it to not placed if changing placement.
    {
        placed = !placed;
    }

    public void Highlight()
    {

    }
}