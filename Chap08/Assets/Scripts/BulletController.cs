using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("DestroyBullet");
    }
    void Update()
    {

    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
    public void Shoot (Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce (dir);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreManager>().InScore();
            
            Destroy(gameObject, 0.1f);
            
        }
        else if (collision.collider.tag == "Player")
        {
            rb.constraints = RigidbodyConstraints.None;
            Destroy(gameObject, 0.1f);
        }
    }

}
