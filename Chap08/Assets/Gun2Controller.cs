using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2Controller : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir;
        dir = player.transform.position - this.transform.position;
        transform.rotation = Quaternion.LookRotation(-1 * dir);
    }
}
