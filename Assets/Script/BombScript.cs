﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    
    public Animator animator;
    
    public int timer = 100;
    private int counter = 100;

    private bool isActivated = false;

    private bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        //Time.fixedDeltaTime
        //animator.SetBool("IsJumping", true);
        //Debug.Log(Time.fixedDeltaTime);
        timer -= 1;

        if(timer <= 0)
        {
            
            if(isActivated && isDestroyed)
            {
                Destroy(gameObject);
                return;
            }
            
            if (!isActivated)
            {
                isActivated = true;
                timer = counter;
            }
            else
            {
                isDestroyed = true;
                timer = counter / 2;
            }
            
            animator.SetBool("Active", isActivated);
            animator.SetBool("Explode", isDestroyed);
        }

    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
         Debug.Log(collider.gameObject.name);
         
         if ("Player" == collider.gameObject.name)
         {
            Destroy(gameObject);
         }
        
    }       
}
