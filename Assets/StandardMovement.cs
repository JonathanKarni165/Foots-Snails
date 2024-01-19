using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D border;
    public float horizontalSpeed, verticalSpeed;
    public bool isMoving, allowedToMove;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        allowedToMove = true;

        transform.position = new Vector2(0, 0);
    }

    void Update()
    {
        isMoving = rb.velocity.normalized.magnitude != 0;

        if (allowedToMove)
        {
            Vector2 moveTo = new Vector2(Input.GetAxisRaw("Horizontal") * horizontalSpeed,
            Input.GetAxisRaw("Vertical") * verticalSpeed);

            //check if the snail in on ground
            bool isGrounded = border.bounds.Contains(transform.position);

            if (isGrounded)
                rb.velocity = moveTo;

            else //return to ground
            {
                rb.velocity = new Vector2(0, 0);

                //create a vector directed to the center of the border
                Vector3 dir = border.transform.position - transform.position;

                // Normalize resultant vector to unit Vector.
                dir = dir.normalized;

                transform.position += dir * Time.deltaTime * 5;
            }
        }
        else
            rb.velocity = new Vector2(0, 0);
    }
}
