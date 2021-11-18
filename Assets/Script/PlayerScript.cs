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

    public AudioSource jumpSound;

    public AudioSource hurtSound;

    public AudioSource itemSound;

    public AudioSource kickSound;

    public int playerId = 1;

    private string heartPath = "/Player{0}/Lifes/life0{1}";

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        invulnerable = 0;

        for (int i = 1; i < 4; ++i)
        {
            GameObject heart = GameObject.Find(string.Format(heartPath, playerId, life));
            heart.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameScript.gameOver)
        {
            return;
        }
        
        hMove = Input.GetAxisRaw("Horizontal" + playerId) * playerSpeed;
        if (Input.GetButtonDown("Jump" + playerId))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            jumpSound.Play(0);
        }

        animator.SetFloat("Speed", Mathf.Abs(hMove));

        if(invulnerable > 0)
        {
            invulnerable -= 1 * Time.fixedDeltaTime;
        }

        if(transform.position.y < -20)
        {
            if(ScoreScript.score[playerId - 1] > 0)
            {
                ScoreScript.score[playerId - 1] -= ScoreScript.score[playerId - 1] / 2;
            }
            
            GameScript.gameOver = true;
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

    public void kickBomb()
    {
        kickSound.Play(0);
    }

    public void getItem(int points)
    {
        itemSound.Play(0);
        ScoreScript.score[playerId - 1] += points;
    }

    public void takeDamage()
    {
        if(invulnerable > 0)
        {
            return;
        }

        invulnerable = 1.5f;
        animator.SetBool("IsHurt", true);
        animator.SetBool("IsJumping", false);
        hurtSound.Play(0);
        GameObject heart = GameObject.Find(string.Format(heartPath, playerId, life));
        heart.SetActive(false);
        ScoreScript.score[playerId - 1] -= 5;

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
