using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletController2 : MonoBehaviour
{
    Rigidbody rb;
    int count;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            count++;
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreManager>().InScore();
            Destroy(gameObject, 0.2f);
            if (count >= 3)
            {
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
