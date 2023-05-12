using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControllor : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground")|| collision.CompareTag("Player") || collision.CompareTag("Hole"))
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Destroy");
            Destroy(gameObject, 0.4f);
        }
        
    }
}
