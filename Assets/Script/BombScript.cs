using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    
    public Animator animator;
    public GameObject tile; 
    public int timer = 100;
    private int counter = 100;
    private bool isActivated = false;
    private bool isDestroyed = false;
    private bool kickOff = false;
    private float direction = -10f;

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
        if(kickOff)
        {
            if(transform.position.x < -40 || transform.position.x > 70)
            {
                Destroy(gameObject);
            }
            else 
            {
                transform.Translate(direction * 2 * Time.fixedDeltaTime, 0, 0, Space.World);
            }
        }
        else
        {
            //Time.fixedDeltaTime
            //animator.SetBool("IsJumping", true);
            //Debug.Log(Time.fixedDeltaTime);
            timer -= 1;

            if(timer <= 0)
            {

                if(isActivated && isDestroyed)
                {
                    GameScript.destroyTile(tile);
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
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
         //Debug.Log(collider.gameObject.name);
         
         if ("Player" == collider.gameObject.name)
         {
            if(isActivated && isDestroyed)
            {
               collider.GetComponent<PlayerScript>().takeDamage();
            }
            else
            {
                if((int) transform.position.x > (int) collider.transform.position.x)
                {
                    direction = 10f;
                }

                kickOff = true;
            }

            //Destroy(gameObject);
         }
    }
}
