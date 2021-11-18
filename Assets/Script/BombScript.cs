using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    
    private int counter = 100;
    
    private bool isActivated = false;
    
    private bool isDestroyed = false;
    
    private bool kickOff = false;
    
    private float direction = -10f;

    public Animator animator;
    
    public GameObject tile;
    
    public int timer = 100;

    private AudioSource sound;

    private GameObject kicker;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
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
                    sound.Play(0);
                }
                
                animator.SetBool("Active", isActivated);
                animator.SetBool("Explode", isDestroyed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
         if ("Player" == collider.gameObject.tag)
         {
            
            GameObject other = collider.gameObject;

            if((isActivated && isDestroyed) || (kickOff && other != kicker))
            {
               collider.GetComponent<PlayerScript>().takeDamage();
            }
            else if(!kickOff)
            {
                if((int) transform.position.x > (int) collider.transform.position.x)
                {
                    direction = 10f;
                }

                kickOff = true;
                kicker = other;
                collider.GetComponent<PlayerScript>().kickBomb();
            }
         }
    }
}
