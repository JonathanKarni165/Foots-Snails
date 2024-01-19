using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAnimation : MonoBehaviour
{
    public Animator animator;
    public StandardMovement stdm;
    public bool changeScale;
    
    void Update()
    {
        animator.SetBool("isMoving", stdm.isMoving);

        //check if the input is colerated to scale
        //negative - same direction
        if ((transform.localScale.x * stdm.rb.velocity.x) > 0)
        {
            stdm.allowedToMove = false;
            animator.SetBool("isTurning", true);
            StartCoroutine("TurningDelay");
        }
    }

    public void ChangeScaleX()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1,
            transform.localScale.y);
        //ending turn anime
        animator.SetBool("isTurning", false);
    }

    IEnumerator TurningDelay()
    {
        yield return new WaitForSeconds(1);
        stdm.allowedToMove = true;
    }
}
