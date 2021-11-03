using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    public float playerSpeed = 40f;
    public Animator animator;
    public CharacterController2D controller;
    
    private float hMove = 0f;

    private bool jump = false;
    private bool crouch = false;

    private bool inAir = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        else if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            //GetComponent<BoxCollider2D> ().enabled = false;
            //GetComponent<CircleCollider2D> ().enabled = false;
        }

        
    }

    void FixedUpdate() 
    {
        controller.Move(hMove * Time.fixedDeltaTime, crouch, jump);
        if (jump)
        {
            animator.SetBool("IsJumping", true);
        }
        jump = false;
        crouch = false;
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

    public void OnLanding()
    {
         inAir = !inAir;
         if (inAir)
         {
            animator.SetBool("IsJumping", false);
         }

    }
}
