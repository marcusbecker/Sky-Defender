﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
