using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private float hMove = 0f;

    private bool jump = false;

    private bool inAir = false;

    private bool crouch = false;

    private int life = 3;

    private float invulnerable = 0;

    public float playerSpeed = 40f;
    
    public Animator animator;
    
    public CharacterController2D controller;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        invulnerable = 0;

        for (int i = 1; i < 4; ++i)
        {
            GameObject heart = GameObject.Find("life0" + i);
            heart.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal") * playerSpeed;
        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(invulnerable > 0)
        {
            invulnerable -= 1 * Time.fixedDeltaTime;
        }
    }

    void FixedUpdate() 
    {
        if(GameScript.gameOver)
        {
            animator.SetBool("IsHurt", true);
            transform.Translate(0, -1 * Time.deltaTime / 2, 0, Space.World);
        }
        else
        {
            controller.Move(hMove * Time.fixedDeltaTime, crouch, jump);
            
            if (jump)
            {
                animator.SetBool("IsJumping", true);
            }

            jump = false;
            crouch = false;
        }
    }

    /*void OnTriggerEnter2D(Collider2D collider) 
    {
         Debug.Log(collider.gameObject.name);
         
         if(collider.gameObject.name == "Coin")
         {
            Destroy(collider.gameObject);
         }
         Destroy(collider.gameObject);
         
    }*/

    public void takeDamage()
    {
        
        if(invulnerable > 0)
        {
            return;
        }

        invulnerable = 1.5f;
        animator.SetBool("IsHurt", true);
        animator.SetBool("IsJumping", false);
        
        GameObject heart = GameObject.Find("life0" + life);
        heart.SetActive(false);
        --life;

        if(life == 0)
        {
            GameScript.gameOver = true;
        }
    }

    public void OnLanding()
    {
         inAir = !inAir;
         if (inAir)
         {
            animator.SetBool("IsJumping", false);
         }

    }
}
