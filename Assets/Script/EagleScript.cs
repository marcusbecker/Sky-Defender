using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleScript : MonoBehaviour
{
    
    private bool left = false;

    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        left = transform.position.x < 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(left)
        {
            transform.Translate(speed * Time.deltaTime / 2, 0, 0, Space.World);
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime / 2, 0, 0, Space.World);
        }

        if(transform.position.x < -20 || transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
         if ("Player" == collider.gameObject.tag)
         {
            collider.GetComponent<PlayerScript>().takeDamage();
         }
    }
}
