using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumScript : MonoBehaviour
{
    int moveSpeed = 0;
    int fallSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime / 2, -fallSpeed * Time.deltaTime / 2, 0, Space.World);
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
         if ("Player" == collider.gameObject.name)
         {
            collider.GetComponent<PlayerScript>().takeDamage();
         }
         
         fallSpeed = 0;
         moveSpeed = 1;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        fallSpeed = 1;
        moveSpeed = 0;
    }

}
