using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody playerRd;

    void Start()
    {
        p
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
