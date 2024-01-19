using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootJump : MonoBehaviour
{
    public BootTargeting bootTargeting;

    // y = J * (-X^2 + Bx)
    public float jumpSpeed = 20, fallSpeed = 30, stretchFunction = 0.008f;
    private float B, J, x, y, direction;
    public bool isMoving;

    //movement phases
    private bool isOnParabulaRoute, isFalling, isJumping;
    Vector2 startingPosition, targetPos;

    private static readonly double MINJ = 0.006, MAXJ = 0.1;
    private static readonly double MINB = 10, MAXB = 150;


    public void Jump(Vector3 mousePosition)
    {
        isMoving = true;
        targetPos = mousePosition;

        float deltaX = mousePosition.x - transform.position.x;
        B = deltaX;
        direction = deltaX > 0 ? 1 : -1;

        J = NormalizedJ(Math.Abs(B), stretchFunction);

        x = 0;
        y = 0;

        isJumping = true;
    }

    private void Update()
    {
        //going up until reaching sky
        if(isJumping)
        {
            transform.Translate(0, jumpSpeed * Time.deltaTime, 0);

            if (!bootTargeting.border.bounds.Contains(transform.position))
            {
                startingPosition = transform.position;

                isJumping = false;
                isOnParabulaRoute = true;
            }
        }

        //generate parabula y = -x^2 + Bx
        if (isOnParabulaRoute)
        {
            x += Time.deltaTime * jumpSpeed * direction;
            y = J * (-(float)Math.Pow(x, 2) + B * x);

            transform.position = new Vector2(startingPosition.x + x, startingPosition.y + y);

            float posX = transform.position.x;
            if ((posX > targetPos.x && direction > 0) || (posX < targetPos.x && direction < 0))
            {
                isOnParabulaRoute = false;
                isFalling = true;
            }
        }

        //going down until reaching target
        if(isFalling)
        {
            transform.Translate(0, -fallSpeed * Time.deltaTime, 0);

            if (transform.position.y < targetPos.y)
            {
                isFalling = false;
                isMoving = false;
            }
        }
    }

    //determine J value in comperison to B value
    //bigger B smaler J and vice-versa
    // J = -mB + b
    public static float NormalizedJ(float currentB, float baseJ)
    {
        double normalizedB = Math.Abs((currentB - MINB) / (MAXB - MINB));
        return (float)(baseJ / normalizedB);
    }
}
