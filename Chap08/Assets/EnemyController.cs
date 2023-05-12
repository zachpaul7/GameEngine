using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 5f;
    [SerializeField]private float moveRate;
    [SerializeField]private float timeAfterMove;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveRate = Random.Range(0, 1.0f);
        timeAfterMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterMove += Time.deltaTime;

        if(timeAfterMove > moveRate)
        {
            float moveWay = Random.Range(-1.0f, 1.0f);
            timeAfterMove = 0;

            if (moveWay > 0 )
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);

                if (this.transform.position.x < -4.0)
                {
                    transform.Translate(Vector3.zero);
                }
            }
            else if (moveWay < 0 )
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);

                if (this.transform.position.x > 4.0)
                {
                    transform.Translate(Vector3.zero);
                }
            }
            else
            {
                transform.Translate(Vector3.zero);
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            GameObject manager = GameObject.Find("ScoreManager");
            if (manager.GetComponent<ScoreManager>().count == 3)
            {
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
