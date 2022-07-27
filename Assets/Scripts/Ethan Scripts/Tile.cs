using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private MeshRenderer render;
    private bool occupied = false;
    private bool shot = false;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (!shot)
        {
            render.material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        if (!shot)
        {
            render.material.color = Color.white;
        }
    }

    public bool hit()
    {
        shot = true;
        if (occupied)
        {
            render.material.color = Color.magenta;
            return true;
        }
        else
        {
            render.material.color = Color.gray;
            return false;
        }
    }

    public bool returnState()
    {
        return shot;
    }
}