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
                    sound.Play(0);
                }
                
                animator.SetBool("Active", isActivated);
                animator.SetBool("Explode", isDestroyed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
         //Debug.Log(collider.gameObject.name);
         
         if ("Player" == collider.gameObject.tag)
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
                collider.GetComponent<PlayerScript>().kickBomb();
            }

            //Destroy(gameObject);
         }
    }
}
