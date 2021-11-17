using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int points;

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

         if ("Player" == collider.gameObject.name)
         {
            collider.GetComponent<PlayerScript>().getItem(points);
            Destroy(gameObject);
         }
        
    }        
}
