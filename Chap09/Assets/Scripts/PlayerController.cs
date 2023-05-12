using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movePower = 1f;
    [SerializeField] private float jumpPower = 1f;
    private int life = 3;
    private int score = 0;

    public GameManager manager;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator animator;
    
    Vector3 movement;

    private bool isJumping = false;
    private float climbSpeed = 3f; // speed of climbing
    private bool isClimbing;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriter = gameObject.GetComponentInChildren<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isJumping == false)
            {
                isJumping = true;
                animator.SetBool("isJumping", true);
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        Move();
        Clibimg();
    }

    void Clibimg()
    {
        if (isClimbing)
        {
            float inputVertical = Input.GetAxis("Vertical");
            animator.SetBool("isClimbing", isClimbing);
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(rigid.velocity.x, inputVertical * climbSpeed);

        }
        else
        {
            animator.SetBool("isClimbing", isClimbing);
            rigid.gravityScale = 1f;
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            animator.SetInteger("Direction", 1);
            spriter.flipX = true;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            animator.SetInteger("Direction", 1);
            spriter.flipX = false;
        }
        else
        {
            animator.SetInteger("Direction", 0);
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        if (!isJumping)
            return;

        //Prevent Velocity amplification.
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            isClimbing = true;
        }
        else if (other.CompareTag("Bomb"))
        {
            life--;
            manager.UpdateLifeIcon(life);
            if(life <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (other.CompareTag("Money"))
        {
            score++;
            manager.UpdateScoreText(score);
            Destroy(other.gameObject);
            if(score >= 13)
            {
                SceneManager.LoadScene("Win");
            }
        }
        else if (other.CompareTag("Hole"))
        {

            SceneManager.LoadScene("GameOver");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            isClimbing = false;
        }
    }

}
