using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootTargeting : MonoBehaviour
{
    //two of the boots movement scripts
    public BootJump bootLeft, bootRight;

    //the ground collider
    public Collider2D border;

    private void Update()
    {
        //mouse position returns pixel position, 
        //we want to convert the position to world position (reletive to gameObjects)
        Vector2 point =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (border.bounds.Contains(point))
        {
            if(Input.GetButtonDown("Fire1"))
                if(!bootLeft.isMoving)
                    bootLeft.Jump(point);

            if (Input.GetButtonDown("Fire2"))
                if(!bootRight.isMoving)
                    bootRight.Jump(point);

        }
    }
}
