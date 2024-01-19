using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//accesse StandartMovement - speed
public class SnailCollision : MonoBehaviour
{
    public StandardMovement mv;
    UIVariable varUI;
    //3,2,1
    public byte maxHealth;
    public byte health;

    public int addSpeed;

    private void Awake()
    {
        varUI = gameObject.AddComponent<UIVariable>();
        varUI.varName = "snail hp";
        varUI.value = "" + maxHealth;
    }

    void Start()
    {
        health = maxHealth;
    }

    private void GetHit()
    {
        print("hit");
        if(health == 1)
        {
            print("dead");
        }
        health--;
        //speed up
        mv.horizontalSpeed += addSpeed;
        mv.verticalSpeed += addSpeed / 2;
        varUI.value = "" + health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "boot")
        {
            GetHit();
        }
    }
}
