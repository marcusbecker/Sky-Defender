using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    
    public float playerSpeed = 40f;
    
    public Animator animator;
    
    public CharacterController2D controller;
    
    private float hMove = 0f;

    private bool jump = false;

    private bool inAir = false;

    private bool crouch = false;

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

    public void takeDamage()
    {
        animator.SetBool("IsHurt", true);
        animator.SetBool("IsJumping", false);
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
